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
		public abstract string Name { get; }
		public abstract string LangToken { get; }
		public abstract string PickupDescription { get; }
		public abstract string FullDescription { get; }
		public abstract string Lore { get; }

		public abstract GameObject Model { get; }
		public abstract GameObject BodyModel { get; }
		public abstract Sprite Icon { get; }

		public virtual bool CanDrop => true;
		public virtual float Cooldown => 60f;
		public virtual bool EnigmaCompatible => true;
		public virtual bool IsBoss => false;
		public virtual bool IsLunar => false;

		public EquipmentDef def = ScriptableObject.CreateInstance<EquipmentDef>();

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
			LanguageAPI.Add("EQUIPMENT_" + LangToken + "_NAME", Name);
			LanguageAPI.Add("EQUIPMENT_" + LangToken + "_PICKUP", PickupDescription);
			LanguageAPI.Add("EQUIPMENT_" + LangToken + "_DESCRIPTION", FullDescription);
			LanguageAPI.Add("EQUIPMENT_" + LangToken + "_LORE", Lore);
		}

		protected virtual ItemDisplayRuleDict CreateItemDisplayRules() => new();

		protected void CreateItem()
		{
			def.name = "EQUIPMENT_" + LangToken;
			def.nameToken = "EQUIPMENT_" + LangToken + "_NAME";
			def.pickupToken = "EQUIPMENT_" + LangToken + "_PICKUP";
			def.descriptionToken = "EQUIPMENT_" + LangToken + "_DESCRIPTION";
			def.loreToken = "EQUIPMENT_" + LangToken + "_LORE";
			//itemDef.pickupModelPrefab = Main.Assets.LoadAsset<GameObject>(ItemModelPath);
			//itemDef.pickupIconSprite = Main.Assets.LoadAsset<Sprite>(ItemIconPath);
			def.pickupModelPrefab = Model;
			def.pickupIconSprite = Icon;
			def.canDrop = CanDrop;
			def.cooldown = Cooldown;
			def.enigmaCompatible = EnigmaCompatible;
			def.isBoss = IsBoss;
			def.isLunar = IsLunar;

			ItemAPI.Add(new CustomEquipment(def, CreateItemDisplayRules()));
			On.RoR2.EquipmentSlot.PerformEquipmentAction += PerformEquipmentAction;
		}

		protected virtual bool ActivateEquipment(EquipmentSlot slot) => false;

		private bool PerformEquipmentAction(On.RoR2.EquipmentSlot.orig_PerformEquipmentAction orig, EquipmentSlot slot, EquipmentDef equipmentDef)
		{
			if (equipmentDef == this.def)
				return ActivateEquipment(slot);
			else
				return orig(slot, equipmentDef);
		}

		protected virtual void Hooks() { }
	}
}
