using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class CloudflashEngine : ItemBase<CloudflashEngine>
	{
		public override string ItemName => "Cloudflash Engine";
		public override string ItemLangTokenName => "CLOUDFLASH_ENGINE";
		public override string ItemPickupDesc => "Striking a monster damages monsters of the same type nearby.";
		public override string ItemFullDescription => $"Upon striking an enemy, others of the same type within {sharedZone}m <style=cStack>(+{sharedZonePerStack}m per stack)</style> receive <style=cIsDamage>{100 * sharedDamage}%</style> total damage. ";
		public override string ItemLore =>
			"Legends spoke of Zathus, a great sorcerer, able to conduct the powers of lightning to incinerate any foe. She conquered kingdoms, destroyed all who opposed her...\n\n" +

			"The industrial revolution treated Zathus rather kindly, it seems.\n\n\n" +
			
			"<style=cSub>-Parables of the Realm Volume II, Section XIII-c</style>";

		public override ItemTier Tier => ItemTier.Tier3;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Damage };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float sharedZone;
		public float sharedZonePerStack;
		public float sharedDamage;

		protected override void CreateConfig(ConfigFile config)
		{
			sharedZone = config.Bind("Item: " + ItemName, "Shared Zone", 12f).Value;
			sharedZonePerStack = config.Bind("Item: " + ItemName, "Shared Zone Per Stack", 6f).Value;
			sharedDamage = config.Bind("Item: " + ItemName, "Shared Damage", 0.75f).Value;
		}
	}
}