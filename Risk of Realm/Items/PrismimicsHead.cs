using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class PrismimicsHead : ItemBase<PrismimicsHead>
	{
		public override string ItemName => "Prismimic's Head";
		public override string ItemLangTokenName => "PRISMIMICS_HEAD";
		public override string ItemPickupDesc => "<style=cIsHealing>Damage is increased</style>, but all damage is <style=cIsHealth>applied over time</style>.";
		public override string ItemFullDescription => $"All damage is increased by {100 * damageBoost}% <style=cStack>(+{100 * damageBoostPerStack}% per stack)</style>. All damage is converted into damage over time, dealing the full damage of the attack over {damageDelay} <style=cStack>(+{damageDelayPerStack} per stack)</style> seconds.";
		public override string ItemLore =>
			"You have been living a lie.\n\n" +
			"Inhabiting a world defined by its desires for instant gratification. A world in which you believe change is made with the bending of a thumb and the scraping of a pen. As if the universe could be so mercily swift in its whim.\n\n" 
			"You're not who you think you are. Merely a reflection of something greater, cast into the featureless shadow of the cosmos. It pulls nearer, drifts farther. You have to wonder if there are greater lies about control. You cannot define actions swiftly. Can you change the course at all?\n\n" +
			"A crystal bubble, a glass world. It begs to break. That is why the universe cannot be swift. It must be gentle lest the illusion shatter. You are merely a reflection on the glass, and you can see that. You are on the outside, looking in.\n\n" +
			"You are projected onto the spherical black, an echo that speaks as its observer does, and moves with them. They have recognized change cannot be swift. They recognize the sphere cannot be rolled, and thus have surmised to influence it from within.\n\n" +
			"You are a vessel for greater things that see the long term. That have endless time. And have accepted that the universe’s actions are slow and methodical because they must be.\n\n" +
			"Finding yourself, you are holding my head now. Looking in. Do you not feel the same? Do you not understand?\n\n" +
			"You have been living a lie.\n\n" +
			"Staring through me you will see the truth. You will find power over time itself, because you are the master of the glass world. You do not fear the fragility of the bubble in your palm. You do not break with it.\n\n\n"+ 

			"Take a gaze into my skull again.\n" +
			"Do you not see the real world within?";


		public override ItemTier Tier => ItemTier.TierLunar;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Lunar };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float damageBoost;
		public float damageBoostPerStack;
		public float damageDelay;
		public float damageDelayPerStack;

		protected override void CreateConfig(ConfigFile config)
		{
			damageBoost = config.Bind("Item: " + ItemName, "Damage Boost", 0.5f).Value;
			damageBoostPerStack = config.Bind("Item: " + ItemName, "Damage Boost Per Stack", 0.25f).Value;
			damageDelay = config.Bind("Item: " + ItemName, "Damage Delay", 5f).Value;
			damageDelayPerStack = config.Bind("Item: " + ItemName, "Damage Delay Per Stack", 2.5f).Value;
		}
	}
}