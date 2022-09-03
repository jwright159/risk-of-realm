using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class TwilightGemstone : ItemBase<TwilightGemstone>
	{
		public override string ItemName => "Twilight Gemstone";
		public override string ItemLangTokenName => "TWILIGHT_GEMSTONE";
		public override string ItemPickupDesc => "Chance to shorten a Skill’s next cooldown when it is used.";
		public override string ItemFullDescription => $"When using your Skills, <style=cIsUtility>{100 * reductionChance}%</style> chance <style=cStack>(+{100 * reductionChancePerStack}% per stack)</style> for {cooldownReduction} of its cooldown to pass instantly.";
		public override string ItemLore =>
			"\"...Supervisor Rand?\"\n" +
			"\"Yes, corporal?\"\n" +
			"\"We’re picking up an awfully weird frequency coming from out there… we’ve never seen a wave like this before, sir!\"\n" +
			"\"Can our systems translate it?\"\n" +
			"\"They can sure try...\"\n\n\n" +

			"<style=cMono>Translating...\n" +
			"Translating...\n" +
			"Translating...\n" +
			"Translation Complete.</style>\n\n\n" +

			"<style=cEvent>\"My soul, sealed within my body. My body, running amok. Enacting its dark influence on my King.\n" +
			"The Magia. Creeping. Consuming. I fear I do not have much time left.\n" +
			"I never would have invoked this level of power by my own volition. I was not in my right mind.\n" +
			It all started with that stone.\"</style>\n\n\n\n" +

			"\"Supervisor, did you put this purple rock in my lap to have it examined, or is someone messing with me?\"";



		public override ItemTier Tier => ItemTier.Tier2;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Utility };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float reductionChance;
		public float reductionChancePerStack;
		public float cooldownReduction;

		protected override void CreateConfig(ConfigFile config)
		{
			reductionChance = config.Bind("Item: " + ItemName, "Reduction Chance", 0.2f).Value;
			reductionChancePerStack = config.Bind("Item: " + ItemName, "Reduction Chance Per Stack", 0.1f).Value;
			cooldownReduction = config.Bind("Item: " + ItemName, "Cooldown Reduction", 0.25f).Value;
		}
	}
}