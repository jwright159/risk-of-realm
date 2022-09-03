using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class RusticCuff : ItemBase<RusticCuff>
	{
		public override string ItemName => "Rustic Cuff";
		public override string ItemLangTokenName => "RUSTIC_CUFF";
		public override string ItemPickupDesc => "Every seventh attack of your Primary reduces enemy attack speed.";
		public override string ItemFullDescription => $"Every seventh attack of your <style=cIsUtility>Primary</style> reduces enemy attack speed by {100 * attackSpeedReduction}% for {reductionTime} <style=cStack>(+{reductionTimePerStack} per stack)</style> seconds.";
		public override string ItemLore =>
			"<style=cMono>Welcome to DataScraper (v3.1.53 – beta branch)\n" +
			"$ Scraping memory... done.\n" +
			"$ Resolving... done.\n" +
			"$ Combing for relevant data... done.\n" +
			"Complete!\n" +
			"Outputting video...</style>\n\n\n" +

			"The guard rattled the prisoner's chains.\n" +
			"\"What you've done, bub... well, seems like you’re gonna be here a while. Crimes against the Federation... stealing classified artifacts from archeology outreaches… even trying to involve your own son in your schemes with dangerous, illegal steroids! Thank goodness we intercepted your packages before they got off the ship. Yep. You’re gonna be in the brig for a very, very long time./"/n" +
			"The prisoner chuckled, his eyes glowing a faint violet.\n\n" +

			"\"None of that matters now. The corporal showed me - he showed me <style=cArtifact>the Stone</style>. This is something beyond all of us. You don’t know what’s coming. Neither does the captain. Neither does The Brother, the heretical brother, neither does The Mad God, despite all of his brute strength. The end is coming for us all.\"\n\n" +

			"The guard chuckled. /"Whatever weird strategy this is, it won't work on me. Been on the force for decades./"/n/n/n" +
			"The prisoner rattled his chains.";


		public override ItemTier Tier => ItemTier.Tier1;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Utility };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float attackSpeedReduction;
		public float reductionTime;
		public float reductionTimePerStack;

		protected override void CreateConfig(ConfigFile config)
		{
			attackSpeedReduction = config.Bind("Item: " + ItemName, "Attack Speed Reduction", 0.2f).Value;
			reductionTime = config.Bind("Item: " + ItemName, "Reduction Time", 3f).Value;
			reductionTimePerStack = config.Bind("Item: " + ItemName, "Reduction Time Per Stack", 2f).Value;
		}
	}
}