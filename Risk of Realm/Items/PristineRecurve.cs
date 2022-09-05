using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class PristineRecurve : ItemBase<PristineRecurve>
	{
		public override string ItemName => "Pristine Recurve";
		public override string ItemLangTokenName => "PRISTINE_RECURVE";
		public override string ItemPickupDesc => "Attacks pass through obstacles. Chance to duplicate projectiles.";
		public override string ItemFullDescription => $"All projectiles fired by skills and equipment pass through obstacles. {100 * doubleChance}% chance <style=cStack>(+{100 * doubleChancePerStack}% per stack)</style> to <style=cIsDamage>duplicate projectiles</style>.";
		public override string ItemLore =>
			"SHIPPING ORDER 0001280\n" +
			"ITEM(s): Pristine Recurve\n\n" +

			"<style=cMono>UNKNOWN DIALECT. TRANSLATION IS NOT CONFIRMED. SHIPPING ORDER COULD NOT BE TRACED.</style>\n\n\n" +

			"You must take it. It is the last remaining memory of my Kingdom - my Dominion - The [Broken]. It was held by the royal family for generations, unused until times of extreme need. I had never been much of a marksman myself; [spellcasting] was my preferred aspect of combat. However, upon holding the [Conqueror], I felt my vision enhance, my arms become more steady. As if I were drawing out its power.\n\n" +
			
			"Handle it with care. My Kingdom depends on it.";

		public override ItemTier Tier => ItemTier.Tier3;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Damage };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float doubleChance;
		public float doubleChancePerStack;

		protected override void CreateConfig(ConfigFile config)
		{
			doubleChance = config.Bind("Item: " + ItemName, "Double Chance", 0.25f).Value;
			doubleChancePerStack = config.Bind("Item: " + ItemName, "Double Chance Per Stack", 0.10f).Value;
		}
	}
}