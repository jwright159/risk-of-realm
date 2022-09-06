using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class WhiteBag : ItemBase<WhiteBag>
	{
		public override string ItemName => "White Bag";
		public override string ItemLangTokenName => "WHITE_BAG";
		public override string ItemPickupDesc => "Legendary item chances increased from all sources.";
		public override string ItemFullDescription => $"Increases chance for <style=cIsHealth>Legendary</style> items by {100 * legendaryBoost}% <style=cStack>(+{100 * legendaryBoostPerStack}% per stack)</style> of their usual chance from all sources.";
		public override string ItemLore =>
			"Order: White Bag\n" +
			"Tracking Number: 78******\n" +
			"Estimated Delivery: 05/08/2066\n" +
			"Shipping Method: Standard\n" +
			"Shipping Address: \"EUSW Nexus, Keys\" (???)\n" +
			"Shipping Details:\n\n\n\n" +

			"The weavers of USW3-Deathmage have always been lauded for the perfection of their craft. The finest of ivory silks, bound with a dreamweft cerulean lace.\n\n" + 
			"Icons among the nobility of their land, these durable and yet elegant sacks of minute and skillful artisanship are symbolic of an ancient power lost, a favored means of protecting and shielding not merely fragile but also incredibly valuable artifacts and relics.\n\n" +
			"Lo, there are frauds who seek to replicate in all but the delicate patterns the beauty of their crafts. Any simple creature could fashion a bag from white cloth and tie it with a blue string.\n\n" +
			"And yep, I can see there, from this fault in the pattern. This is not an original. This is a fake white bag.\n\n" + 
			"Best I’ll take it for is $12.50.";

		public override ItemTier Tier => ItemTier.Tier2;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Utility };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float legendaryBoost;
		public float legendaryBoostPerStack;

		protected override void CreateConfig(ConfigFile config)
		{
			legendaryBoost = config.Bind("Item: " + ItemName, "Legendary Boost", 0.2f).Value;
			legendaryBoostPerStack = config.Bind("Item: " + ItemName, "Legendary Boost Per Stack", 0.1f).Value;
		}
	}
}