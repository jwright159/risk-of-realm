using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class ForgottenCrown : ItemBase<ForgottenCrown>
	{
		public override string ItemName => "Forgotten Crown";
		public override string ItemLangTokenName => "FORGOTTEN_CROWN";
		public override string ItemPickupDesc => "Killing enemies <style=cIsHealing>raises all stats</style>. <style=cIsHealth>All stats drain over time.</style>";
		public override string ItemFullDescription => $"Killing an enemy raises all stats by {statsPerKill}%, up to a maximum of {statsKillCap}% <style=cStack>(+{statsKillCapPerStack}% per stack)</style>. All stats decay by {statsDecay}% <style=cStack>(+{statsDecayPerStack})% per stack</style>, after not killing enemies for <style=cIsUtility>{gracePeriod}</style> seconds.";
		public override string ItemLore =>
			"<style=cMono>\"An eerie reminder of what lays in the depths of...\"</style>\n" +
			"The rest of the cracked old tablet was chipped. He could only wonder."

		public override ItemTier Tier => ItemTier.TierLunar;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Lunar };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float statsPerKill;
		public float statsKillCap;
		public float statsKillCapPerStack;
		public float statsDecay;
		public float statsDecayPerStack;
		public float gracePeriod;

		protected override void CreateConfig(ConfigFile config)
		{
			statsPerKill = config.Bind("Item: " + ItemName, "Stats Per Kill", 0.02f).Value;
			statsKillCap = config.Bind("Item: " + ItemName, "Stats Kill Cap", 0.3f).Value;
			statsKillCapPerStack = config.Bind("Item: " + ItemName, "Stats Kill Cap Per Stack", 0.15f).Value;
			statsDecay = config.Bind("Item: " + ItemName, "Stats Decay", 0.01f).Value;
			statsDecayPerStack = config.Bind("Item: " + ItemName, "Stats Decay Per Stack", 0.005f).Value;
			gracePeriod = config.Bind("Item: " + ItemName, "Grace Period", 4f).Value;
		}
	}
}