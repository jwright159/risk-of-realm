using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class TransformationPotion : ItemBase<TransformationPotion>
	{
		public override string ItemName => "Transformation Potion";
		public override string ItemLangTokenName => "TRANSFORMATION_POTION";
		public override string ItemPickupDesc => "Chance on hit to turn enemies into Beetles.";
		public override string ItemFullDescription => $"<style=cIsUtility>{100 * transformChance}%</style> <style=cStack>(+{100 * transformChancePerStack}% per stack)</style> chance on hit to <style=cIsUtility>transform</style> a non-boss enemy into a Beetle.";
		public override string ItemLore =>
			"\"Doctor, are you sure this is safe?\"\n\n" +

			"\"Ah, yes! Yes, do not worry, Johannes! Perfectly safe! The solution has been tested for every side effect. Now - drink! Watch your wildest dreams come true!\"\n\n" +

			"Johannes drank the potion. His vision began to shift. He felt as if he was falling. When he settled, he was staring at the doctor’s shoe. At eye level.\n\n" +

			"\"Chit, chit chit… CHIT CHIT CHIT CHIT!!!\"\n\n" +

			"\"Very good. Very good.\"";

		public override ItemTier Tier => ItemTier.Tier2;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Utility };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float transformChance;
		public float transformChancePerStack;

		protected override void CreateConfig(ConfigFile config)
		{
			transformChance = config.Bind("Item: " + ItemName, "Transform Chance", 0.02f).Value;
			transformChancePerStack = config.Bind("Item: " + ItemName, "Transform Chance Per Stack", 0.01f).Value;
		}
	}
}