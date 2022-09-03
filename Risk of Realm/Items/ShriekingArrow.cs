using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class ShriekingArrow : ItemBase<ShriekingArrow>
	{
		public override string ItemName => "Shrieking Arrow";
		public override string ItemLangTokenName => "SHRIEKING_ARROW";
		public override string ItemPickupDesc => "When you start sprinting, shoot homing missiles into nearby enemies. Recharges over time.";
		public override string ItemFullDescription => $"When you initiate your sprint, release up to {storedArrows} <style=cStack>({storedArrowsPerStack})</style> <style=cIsDamage>homing specter arrows</style> that deal <style=cIsDamage>{arrowDamage}% base damage</style> into nearby enemies, with the specters recharging at a rate of <style=cIsUtility>{arrowsRechargePerSecond}</style> per second.";
		public override string ItemLore =>
			"Order: Shrieking Arrow\n" +
			"Tracking Number: 52******\n" +
			"Estimated Delivery: 08/19/2066\n" +
			"Shipping Method: Priority\n" +
			"Shipping Address: UES Nebula Grazer, Nabu Research Satellite, Rings of Saturn\n" +
			"Shipping Details:\n\n\n\n" +

			"For the eyes of Dr. Preston Young,\n\n\n" +

			"The [expletive] \"erudites\" back on Murkoth-3 detected odd wavelengths emanating from the tip of this artifact. Dug it out from some lost site deep below the Appalachians. That said, they couldn't come to any reasonable conclusions about neither its exact origins nor its anomalous properties.\n\n" +
			"Needless to say, and I'll cut the professionalism, the arrow screams. Screams when drawn, screams when released, screams as it travels… screams when it lands… and shudders as it does. Lots of the team's equipment broke down from the frequencies alone when they tried to load and release this thing from a Tarilyte-Ultra compound. And in a weird way, Young, I'll warn you now, I think it hates us.\n\n" +
			"We’re not convinced those notches in its side mean anything. They don’t disrupt its aerodynamics at all, however. Just be careful. The chief of research staff here on the UES [REDACTED] have affirmed that it will be taken care of, and that it shall not be interfered with for fear of either disrupting its anomalous properties, or... invoking them.\n\n" + 
			"Appended with this item should be a copy of the results of our tests, and what we believe should follow. It is classified and sealed, and the enforcers on the ship have been warned that opening this letter and the files attached to it will have them prosecuted.\n\n" +
			"And just between us, I think this thing needs to be destroyed. But you didn’t hear that from me.\n\n\n" +

			"~signed Dr. C. Phillips";


		public override ItemTier Tier => ItemTier.Tier2;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Damage };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float storedArrows;
		public float storedArrowsPerStack;
		public float arrowDamage;
		public float arrowsRechargePerSecond;

		protected override void CreateConfig(ConfigFile config)
		{
			storedArrows = config.Bind("Item: " + ItemName, "Stored Arrows", 4f).Value;
			storedArrowsPerStack = config.Bind("Item: " + ItemName, "Stored Arrows Per Stack", 2f).Value;
			arrowDamage = config.Bind("Item: " + ItemName, "Arrow Damage", 180f).Value;
			arrowsRechargePerSecond = config.Bind("Item: " + ItemName, "Arrows Recharge Per Second", 1f).Value;
		}
	}
}
