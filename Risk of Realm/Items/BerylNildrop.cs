using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class BerylNildrop : ItemBase<BerylNildrop>
	{
		public override string ItemName => "Beryl Nildrop";
		public override string ItemLangTokenName => "BERYL_NILDROP";
		public override string ItemPickupDesc => "Move faster at the beginning of each stage.";
		public override string ItemFullDescription => $"For the first <style=cIsUtility>{time}</style> <style=cStack>(+{timePerStack} per stack)</style> seconds each stage, get a <style=cIsUtility>{speedBoost * 100}%</style> boost to movement speed.";
		public override string ItemLore =>
			"<style=cMono>Welcome to DataScraper (v3.1.53 - beta branch)\n" +
			"$ Scraping memory... done.\n" +
			"$ Resolving... done.\n" +
			"$ Combing for relevant data... done.\n" +
			"Complete!\n" +
			"Outputting video...</style>\n\n" +

			"\"F-f-faster... faster.\" The man sat huddled in the corner of his room, rocking back and forth on his hands and knees.\n\n" +

			"His coworker rolled his eyes and sighed heavily. He pulled the man up with a hissing whisper. \"C'mon, Jones, seriously?!? You got into the Green again, didn't you? Goddammit, I can’t keep covering for you like this! You know how the higher ups feel about us dipping into the samples. You could get us both fired or worse!\"\n\n" +

			"\"Faster. F-faster.\"\n\n" +

			"\"Yeah, whatever. This is the last time. If I find you like this again, you're going into the airlock, bud.\"\n\n" +

			"\"F... Fast... okay.\"";

		public override ItemTier Tier => ItemTier.Tier1;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Utility };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float time;
		public float timePerStack;
		public float speedBoost;

		protected override void CreateConfig(ConfigFile config)
		{
			time = config.Bind("Item: " + ItemName, "Time", 20f).Value;
			timePerStack = config.Bind("Item: " + ItemName, "Time per Stack", 10f).Value;
			speedBoost = config.Bind("Item: " + ItemName, "Speed Boost", 0.7f).Value;
		}
	}
}