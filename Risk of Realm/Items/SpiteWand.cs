using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class SpiteWand : ItemBase<SpiteWand>
	{
		public override string ItemName => "Spite Wand";
		public override string ItemLangTokenName => "SPITE_WAND";
		public override string ItemPickupDesc => "Critical strikes can now deal <style=cIsHealing>more damage</style>, or they can <style=cIsHealth>deal less</style>.";
		public override string ItemFullDescription => $"Critical strikes now vary in damage, ranging from {100 * critMin}% <style=cStack>(-{100 * critMinPerStack}% per stack)</style> to {100 * critMax}% <style=cStack>(+{100 * critMaxPerStack}% per stack)</style> damage.";
		public override string ItemLore =>
			"The worker pocketed the artifact on one of the digs. Thought it was pretty neat.\n" +
			"The worker hugged his wife when he got home. He shattered her spine.\n\n" +

			"The worker punched his rowdy cellmate with all he had.\n" +  
			"It bounced off of him like he was made of rubber.";

		public override ItemTier Tier => ItemTier.TierLunar;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Lunar };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float critMin;
		public float critMinPerStack;
		public float critMax;
		public float critMaxPerStack;

		protected override void CreateConfig(ConfigFile config)
		{
			critMin = config.Bind("Item: " + ItemName, "Crit Minimum", 0.5f).Value;
			critMinPerStack = config.Bind("Item: " + ItemName, "Crit Minimum Per Stack", 0.25f).Value;
			critMax = config.Bind("Item: " + ItemName, "Crit Maximum", 4f).Value;
			critMaxPerStack = config.Bind("Item: " + ItemName, "Crit Maximum Per Stack", 0.75f).Value;
		}
	}
}