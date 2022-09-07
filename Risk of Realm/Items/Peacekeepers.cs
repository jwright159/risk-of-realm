using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class Peacekeepers : ItemBase<Peacekeepers>
	{
		public override string ItemName => "PC - K33PRs";
		public override string ItemLangTokenName => "PEACE_KEEPERS";
		public override string ItemPickupDesc => "All damage you deal to a class of enemy will be redirected to the first one struck. <style=cIsVoid>Corrupts all Cloudflash Engines</style>.";
		public override string ItemFullDescription => $"Directly hitting an enemy marks it with a debuff, redirecting {100 * redirectDamage}% <style=cStack>(+{100 * redirectDamagePerStack}% per stack)</style> total damage dealt to others of the same type unto itself until death. Once dead, a new enemy may be marked.";
		public override string ItemLore =>
			"War. It is brutal, it is corrupting, it is all-consuming, it is...\n\n" +

			"Necessary.\n\n" +

			"Peace is a privilege. Peace is what a kingdom can achieve when it is unshackled from the bonds of its hardships. What it CAN achieve. Not what it will achieve, not what it has a right to achieve, and not without a fair share of suffering before peace is firmly established.\n\n" +

			"To be a strong leader, one must make sacrifices for his kingdom. One must take the suffering he is branded with and turn it to those who seek to keep him oppressed.\n\n" +

			"I treat him like a father, and he treats me like a tool.\n" +
			"He will burn.\n" +
			"I swear it.";


		public override ItemTier Tier => ItemTier.Tier3;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Void };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float redirectDamage;
		public float redirectDamagePerStack;

		protected override void CreateConfig(ConfigFile config)
		{
			redirectDamage = config.Bind("Item: " + ItemName, "Redirect Damage", 1.2f).Value;
			redirectDamagePerStack = config.Bind("Item: " + ItemName, "Redirect Damage Per Stack", 1.2f).Value;
		}
	}
}