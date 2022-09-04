using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class MaxPotion : ItemBase<MaxPotion>
	{
		public override string ItemName => "M.A.X Potion";
		public override string ItemLangTokenName => "MAX_POTION";
		public override string ItemPickupDesc => "Gain more experience from all sources.";
		public override string ItemFullDescription => $"All experience gains from killing enemies, barrels, stage completions, etc. is increased by <style=cIsUtility>{100 * expBoost}%</style> <style=cStack>(+{100 * expBoostPerStack}% per stack)</style>.";
		public override string ItemLore =>
			"<style=cMono>StarCourier Instant Mail System Starting.\n" +
			"15%...\n" +
			"23%...\n" +
			"57%...\n" +
			"96%...\n" +
			"System booted.\n" +
			"Resuming from last unsent message.</style>\n\n\n" +

			"Hey, sport! Wow, you sure got back to me quick! Didn't figure my letters would get sent. So, no more baseball? Sorry in advance. I sent you something just a day ago that may not be of much use to you if you quit the league, but that's ok - now I know that, evidently, ALL the cool kids are into Zero-G wrestling! Well, whatever this drink is, it should help with that - the scientists had to put all these warning labels all over it! On a side note, I'm not sure what \"Anabolic\" means, but I'm sure you can look it up on the Webzone or whatever.\n\n" +

			"Love,\n" +
			"Your Dear Old Dad"; 


		public override ItemTier Tier => ItemTier.Tier1;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Utility };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float expBoost;
		public float expBoostPerStack;

		protected override void CreateConfig(ConfigFile config)
		{
			expBoost = config.Bind("Item: " + ItemName, "EXP Boost", 0.1f).Value;
			expBoostPerStack = config.Bind("Item: " + ItemName, "EXP Boost Per Stack", 0.1f).Value;
		}
	}
}