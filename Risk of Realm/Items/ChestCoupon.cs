using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class ChestCoupon : ItemBase<ChestCoupon>
	{
		public override string ItemName => "Chest Coupon";
		public override string ItemLangTokenName => "CHEST_COUPON";
		public override string ItemPickupDesc => "Duplicate a random chest on each stage.";
		public override string ItemFullDescription => $"{chestBoost} random chest (+{chestBoostPerStack} per stack) will be duplicated per stage";
		public override string ItemLore =>
			"NexUs™ Chest Coupons always come in handy when space is your biggest issue! Buy two !!!!!!!!!!!! chests for 1000 [Shekels] OR THREE chests for 3000 [Shekels]!!!! That’s more money for NexUs™ research and development for the low low price of 3000 [Shekels]!!!! AN ABSOLUTELY ASTOUNDING DEAL!";

		public override ItemTier Tier => ItemTier.Tier2;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Utility };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float chestBoost;
		public float chestBoostPerStack;

		protected override void CreateConfig(ConfigFile config)
		{
			chestBoost = config.Bind("Item: " + ItemName, "Chest Boost", 1f).Value;
			chestBoostPerStack = config.Bind("Item: " + ItemName, "Chest Boost Per Stack", 1f).Value;
		}
	}
}