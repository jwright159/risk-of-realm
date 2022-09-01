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
		public override string ItemFullDescription => $"Gain <style=cIsUtility>{baseArmor}</style> <style=cStack>(+{armorPerStack} per stack)</style> Armor.";
		public override string ItemLore => "bepis";

		public override ItemTier Tier => ItemTier.Tier1;

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float baseArmor;
		public float armorPerStack;

		protected override void CreateConfig(ConfigFile config)
		{
			baseArmor = config.Bind<float>("Item: " + ItemName, "Armor", 4).Value;
			armorPerStack = config.Bind<float>("Item: " + ItemName, "Armor per Stack", 4).Value;
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
				args.armorAdd += baseArmor + armorPerStack * (count - 1);
			}
		}
	}
}