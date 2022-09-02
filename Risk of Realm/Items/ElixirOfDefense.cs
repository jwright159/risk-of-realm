using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class ElixirOfDefense : ItemBase<ElixirOfDefense>
	{
		public override string ItemName => "Elixer of Defense";
		public override string ItemLangTokenName => "ELIXIR_OF_DEFENSE";
		public override string ItemPickupDesc => "Gain a small amount of Armor.";
		public override string ItemFullDescription => $"Gain <style=cIsUtility>{armor}</style> <style=cStack>(+{armorPerStack} per stack)</style> Armor.";
		public override string ItemLore =>
			"Take it, kin. You must be strong. If you are stronger than them, they won’t bother you any more.\n\n" +

			"Ah, ah, ah. Do not resist it. The mixture is of bitter root and iron - the taste is strong, but a necessary sacrifice.\n\n" +

			"Feel your skin cement itself. Becoming almost like armor all its own. You can do it, now. You can stand up to them. Make me proud.";

		public override ItemTier Tier => ItemTier.Tier1;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Utility };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float armor;
		public float armorPerStack;

		protected override void CreateConfig(ConfigFile config)
		{
			armor = config.Bind("Item: " + ItemName, "Armor", 4f).Value;
			armorPerStack = config.Bind("Item: " + ItemName, "Armor per Stack", 4f).Value;
		}

		/*
		protected override ItemDisplayRuleDict CreateItemDisplayRules()
		{
			ItemDisplay itemDisplay = ItemBodyModel.AddComponent<ItemDisplay>();
			itemDisplay.rendererInfos = ItemDisplaySetup(ItemBodyModel);

			ItemDisplayRuleDict rules = new(new ItemDisplayRule[]
			{
				new ItemDisplayRule
				{
					ruleType = ItemDisplayRuleType.ParentedPrefab,
					followerPrefab = ItemBodyModel,
					childName = "Chest",
					localPos = new Vector3(0, 0, 0),
					localAngles = new Vector3(0, 0, 0),
					localScale = new Vector3(1, 1, 1),
				}
			});

			return rules;
		}
		*/

		protected override void Hooks()
		{
			RecalculateStatsAPI.GetStatCoefficients += GrantArmor;
		}

		private void GrantArmor(CharacterBody sender, RecalculateStatsAPI.StatHookEventArgs args)
		{
			int count = GetCount(sender);
			if (count > 0)
			{
				args.armorAdd += armor + armorPerStack * (count - 1);
			}
		}
	}
}