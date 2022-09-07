using BepInEx.Configuration;
using R2API;
using UnityEngine;
using RoR2;
using RiskOfRealm.Utils;
using System.Collections.Generic;
using System;

namespace RiskOfRealm.Equipment
{
	public abstract class EquipmentBase<T> : EquipmentBase where T : EquipmentBase<T>
	{
		public static T Instance { get; private set; }

		public EquipmentBase()
		{
			if (Instance != null) throw new InvalidOperationException("Singleton class \"" + typeof(T).Name + "\" inheriting EquipmentBase was instantiated twice");
			Instance = this as T;
		}
	}

	public abstract class EquipmentBase
	{
		public abstract string EquipmentName { get; }
		public abstract string EquipmentLangTokenName { get; }
		public abstract string EquipmentPickupDesc { get; }
		public abstract string EquipmentFullDescription { get; }
		public abstract string EquipmentLore { get; }

		public abstract GameObject ItemModel { get; }
		public abstract GameObject ItemBodyModel { get; }
		public abstract Sprite ItemIcon { get; }

		public virtual bool CanDrop => true;
		public virtual float Cooldown => 60f;
		public virtual bool EnigmaCompatible => true;
		public virtual bool IsBoss => false;
		public virtual bool IsLunar => false;

		public EquipmentDef equipmentDef = ScriptableObject.CreateInstance<EquipmentDef>();

		public virtual void Init(ConfigFile config)
		{
			CreateConfig(config);
			CreateItemDisplayRules();
			CreateLang();
			CreateItem();
			Hooks();
		}

		protected virtual void CreateConfig(ConfigFile config) { }

		protected void CreateLang()
		{
			LanguageAPI.Add("EQUIPMENT_" + EquipmentLangTokenName + "_NAME", EquipmentName);
			LanguageAPI.Add("EQUIPMENT_" + EquipmentLangTokenName + "_PICKUP", EquipmentPickupDesc);
			LanguageAPI.Add("EQUIPMENT_" + EquipmentLangTokenName + "_DESCRIPTION", EquipmentFullDescription);
			LanguageAPI.Add("EQUIPMENT_" + EquipmentLangTokenName + "_LORE", EquipmentLore);
		}

		protected virtual ItemDisplayRuleDict CreateItemDisplayRules() => new();

		protected void CreateItem()
		{
			equipmentDef.name = "ITEM_" + EquipmentLangTokenName;
			equipmentDef.nameToken = "ITEM_" + EquipmentLangTokenName + "_NAME";
			equipmentDef.pickupToken = "ITEM_" + EquipmentLangTokenName + "_PICKUP";
			equipmentDef.descriptionToken = "ITEM_" + EquipmentLangTokenName + "_DESCRIPTION";
			equipmentDef.loreToken = "ITEM_" + EquipmentLangTokenName + "_LORE";
			//itemDef.pickupModelPrefab = Main.Assets.LoadAsset<GameObject>(ItemModelPath);
			//itemDef.pickupIconSprite = Main.Assets.LoadAsset<Sprite>(ItemIconPath);
			equipmentDef.pickupModelPrefab = ItemModel;
			equipmentDef.pickupIconSprite = ItemIcon;
			equipmentDef.canDrop = CanDrop;
			equipmentDef.cooldown = Cooldown;
			equipmentDef.enigmaCompatible = EnigmaCompatible;
			equipmentDef.isBoss = IsBoss;
			equipmentDef.isLunar = IsLunar;

			ItemAPI.Add(new CustomEquipment(equipmentDef, CreateItemDisplayRules()));
			On.RoR2.EquipmentSlot.PerformEquipmentAction += PerformEquipmentAction;
		}

		protected virtual bool ActivateEquipment(EquipmentSlot slot) => false;

		private bool PerformEquipmentAction(On.RoR2.EquipmentSlot.orig_PerformEquipmentAction orig, EquipmentSlot slot, EquipmentDef equipmentDef)
		{
			if (equipmentDef == this.equipmentDef)
				return ActivateEquipment(slot);
			else
				return orig(slot, equipmentDef);
		}

		protected virtual void Hooks() { }
	}
}
