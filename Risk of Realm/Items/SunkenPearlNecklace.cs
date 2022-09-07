using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class SunkenPearlNecklace : ItemBase<SunkenPearlNecklace>
	{
		public override string ItemName => "Sunken Pearl Necklace";
		public override string ItemLangTokenName => "SUNKEN_PEARL_NECKLACE";
		public override string ItemPickupDesc => "Prioritized by Cleansing Pools. Recieve an <style=cIsHealing>Irradiant Pearl</style> when this is cleansed. At low health, break the necklace and <style=cIsHealth>sequence yourself</style>.";
		public override string ItemFullDescription => $"Prioritized by Cleansing Pools. When cleansed, this item has a guaranteed chance of becoming an Irradiant Pearl. When falling below {100 * breakThreshold}% health, this breaks, and your items are sequenced.";
		public override string ItemLore =>
			"Silent betrayal.\n" +
			"Heart wrenched by twisted intents.\n" +
			"Design made faceless.\n\n\n" +

			"Uncleansed false beauty.\n" +
			"Faithfuls hiding in plain sight.\n" +
			"Waxing and waning.\n\n\n" +

			"A line of glass beads.\n" +
			"Order masked as chaos.\n" +
			"Like pearls on string.";

		public override ItemTier Tier => ItemTier.TierLunar;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Lunar };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float breakThreshold;

		protected override void CreateConfig(ConfigFile config)
		{
			breakThreshold = config.Bind("Item: " + ItemName, "Break Threshold", 0.25f).Value;
		}
	}
}