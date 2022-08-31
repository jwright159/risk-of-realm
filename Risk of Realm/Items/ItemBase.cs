using BepInEx.Configuration;
using R2API;
using UnityEngine;
using RoR2;
using RiskOfRealm.Utils;
using System.Collections.Generic;
using System;

namespace RiskOfRealm.Items
{
	public abstract class ItemBase<T> : ItemBase where T : ItemBase<T>
	{
		public static T Instance { get; private set; }

		public ItemBase()
		{
			if (Instance != null) throw new InvalidOperationException("Singleton class \"" + typeof(T).Name + "\" inheriting ItemBase was instantiated twice");
			Instance = this as T;
		}
	}

	public abstract class ItemBase
	{
		public abstract string ItemName { get; }
		public abstract string ItemLangTokenName { get; }
		public abstract string ItemPickupDesc { get; }
		public abstract string ItemFullDescription { get; }
		public abstract string ItemLore { get; }

		public abstract ItemTier Tier { get; }
		public virtual ItemTag[] ItemTags { get; } = { };

		//public abstract string ItemModelPath { get; }
		//public abstract string ItemIconPath { get; }

		public abstract GameObject ItemModel { get; }
		public abstract GameObject ItemBodyModel { get; }
		public abstract Sprite ItemIcon { get; }

		public virtual bool CanRemove { get; }
		public virtual bool Hidden { get; }

		public virtual UnlockableDef Unlockable { get; }

		public ItemDef itemDef = ScriptableObject.CreateInstance<ItemDef>();

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
			LanguageAPI.Add("ITEM_" + ItemLangTokenName + "_NAME", ItemName);
			LanguageAPI.Add("ITEM_" + ItemLangTokenName + "_PICKUP", ItemPickupDesc);
			LanguageAPI.Add("ITEM_" + ItemLangTokenName + "_DESCRIPTION", ItemFullDescription);
			LanguageAPI.Add("ITEM_" + ItemLangTokenName + "_LORE", ItemLore);
		}

		protected virtual ItemDisplayRuleDict CreateItemDisplayRules() => new();

		protected void CreateItem()
		{
			itemDef.name = "ITEM_" + ItemLangTokenName;
			itemDef.nameToken = "ITEM_" + ItemLangTokenName + "_NAME";
			itemDef.pickupToken = "ITEM_" + ItemLangTokenName + "_PICKUP";
			itemDef.descriptionToken = "ITEM_" + ItemLangTokenName + "_DESCRIPTION";
			itemDef.loreToken = "ITEM_" + ItemLangTokenName + "_LORE";
			//itemDef.pickupModelPrefab = Main.Assets.LoadAsset<GameObject>(ItemModelPath);
			//itemDef.pickupIconSprite = Main.Assets.LoadAsset<Sprite>(ItemIconPath);
			itemDef.pickupModelPrefab = ItemModel;
			itemDef.pickupIconSprite = ItemIcon;
			itemDef.hidden = Hidden;
			itemDef.tags = ItemTags;
			itemDef.canRemove = CanRemove;
			itemDef.tier = Tier;
			itemDef.unlockableDef = Unlockable;

			ItemAPI.Add(new CustomItem(itemDef, CreateItemDisplayRules()));
		}

		protected virtual void Hooks() { }

		public int GetCount(CharacterBody body)
		{
			if (!body || !body.inventory)
				return 0;

			return body.inventory.GetItemCount(itemDef);
		}

		public int GetCount(CharacterMaster master)
		{
			if (!master || !master.inventory)
				return 0;

			return master.inventory.GetItemCount(itemDef);
		}
	}
}