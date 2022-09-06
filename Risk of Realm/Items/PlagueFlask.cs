using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class PlagueFlask : ItemBase<PlagueFlask>
	{
		public override string ItemName => "Plague Flask";
		public override string ItemLangTokenName => "PLAGUE_FLASK";
		public override string ItemPickupDesc => "Debuffs applied to an enemy are spread on death.";
		public override string ItemFullDescription => $"If an enemy dies with debuffs currently applied, the debuffs spread to enemies within {spreadZone}m <style=cStack>(+{spreadZonePerStack}m per stack)</style>. Number of stacks carries over, but duration is refreshed.";
		public override string ItemLore =>
			"The Grimhydra of Praxus 7 was finally slain.\n" +
			"Collecting a sample from its fearsome tooth, still dripping with venom, the scientist started to cough.";

		public override ItemTier Tier => ItemTier.Tier3;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Damage };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float spreadZone;
		public float spreadZonePerStack;

		protected override void CreateConfig(ConfigFile config)
		{
			spreadZone = config.Bind("Item: " + ItemName, "Spread Zone", 8f).Value;
			spreadZonePerStack = config.Bind("Item: " + ItemName, "Spread Zone Per Stack", 4f).Value;
		}
	}
}