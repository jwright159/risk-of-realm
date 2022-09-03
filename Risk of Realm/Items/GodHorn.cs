using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class GodHorn : ItemBase<GodHorn>
	{
		public override string ItemName => "God Horn";
		public override string ItemLangTokenName => "GOD_HORN";
		public override string ItemPickupDesc => "Massively increased attack speed while at full health.";
		public override string ItemFullDescription => $"Increases attack speed by <style=cIsDamage>{100 * attackSpeedBoost}</style> <style=cStack>(+{100 * attackSpeedPerStack} per stack)</style> while at <style=cIsHealth>full health.</style>";
		public override string ItemLore =>
			"<style=cMono>Intercepting signal... 33%...\n" +
			"Intercepting signal... 47%...\n" +
			"Intercepting signal... 82%...\n" +
			"Intercepting signal... 100%...\n" +
			"Now playing: intercepted signal...</style>\n\n" +

			"The denizens of this new realm have made a grievous error with the removal of my precious horn. They have invited only my unbridled wrath. Through this venture, they have asserted themselves superior to I. This will not do./n" +
			"They may claim strength from it. That strength will destroy them. It shall invoke within them a hubris as monumental as my own, for they shall drown in the presumption of their own triumph, and perish before their ignorance./n" +
			"The lowly ants among their ilk must be reminded that their actions carry the consequences of a permanent and irreversible death./n/n" +

			"And that begins with you. Doesn’t it, you loathsome worm?";

		public override ItemTier Tier => ItemTier.Tier3;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Damage };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float attackSpeedBoost;
		public float attackSpeedPerStack;

		protected override void CreateConfig(ConfigFile config)
		{
			attackSpeedBoost = config.Bind("Item: " + ItemName, "Attack Speed Boost", 1.5f).Value;
			attackSpeedPerStack = config.Bind("Item: " + ItemName, "Attack Speed Per Stack", 0.75f).Value;
		}
	}
}