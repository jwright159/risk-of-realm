using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class HummingLodestone : ItemBase<HummingLodestone>
	{
		public override string ItemName => "Humming Lodestone";
		public override string ItemLangTokenName => "HUMMING_LODESTONE";
		public override string ItemPickupDesc => "Activating an interactable creates a temporary barrier generating aura.";
		public override string ItemFullDescription => $"Upon use of an interactable, it will release an {zoneDistance}m <style=cStack>(+{zoneDistancePerStack} per stack)</style> zone around it that generates {100 * barrierMaker}% barrier per second for {zoneDuration} seconds.";
		public override string ItemLore =>
			"A fragment of a titan, a colossus, long-forgotten. A glorious being, a perfect construct. A construct that no longer exists.\n\n" +

			"You feel his power course through you, no matter the trinket's age.\n" +
			"You feel what he was created to <style=cArtifact>prevent</style>, too.";


		public override ItemTier Tier => ItemTier.Tier1;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Healing };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float zoneDistance;
		public float zoneDistancePerStack;
		public float barrierMaker;
		public float zoneDuration;

		protected override void CreateConfig(ConfigFile config)
		{
			zoneDistance = config.Bind("Item: " + ItemName, "Zone Distance", 8f).Value;
			zoneDistancePerStack = config.Bind("Item: " + ItemName, "Zone Distance Per Stack", 4f).Value;
			barrierMaker = config.Bind("Item: " + ItemName, "Barrier Maker", 0.05f).Value;
			zoneDuration = config.Bind("Item: " + ItemName, "Zone Duration", 4f).Value;
		}
	}
}