using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class AmbrosiaVial : ItemBase<AmbrosiaVial>
	{
		public override string ItemName => "Ambrosia Vial";
		public override string ItemLangTokenName => "AMBROSIA_VIAL";
		public override string ItemPickupDesc => "All non-player allies have more health and damage.";
		public override string ItemFullDescription => $"All non-player allies (drones/item summons/etc.) get <style=cIsHealing>+{100 * petHealthBoost}%</style> <style=cStack>(+{petHealthBoostPerStack}% per stack)</style> health and <style=cIsDamage>+{100 * petDamageBoost}%</style> <style=cStack>(+{petDamageBoostPerStack}% per stack)</style> damage.";
		public override string ItemLore =>
			"NEW! NEW!\n\n" +

			"Patented NexUs™ Ambrosia is sure to hit your pet's gullet and make them feel like the gods they are! Just one scoop a day smothered among your pet's favorite kibble, [slop], etc. will help them grow healthier and stronger!\n\n" +

			"Watch what happened to little Victoria when NexUs™ Ambrosia was supplemented into her diet! Look at that growth, the strength in those bones! A strong pet, for a strong owner! *wink*\n\n" +

			"<style=cSub>(NexUs™ is not responsible for any indigestion, dietary problems, harm to pets or owners, [melting], or [ascension] invoked by Ambrosia products. Do not consult your doctor if [expletive] starts to hit the metaphorical fan.</style>\n\n" +

			"Buy now! And make your best friend... feel like a god!";

		public override ItemTier Tier => ItemTier.Tier2;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Damage };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float petHealthBoost;
		public float petHealthBoostPerStack;
		public float petDamageBoost;
		public float petDamageBoostPerStack;

		protected override void CreateConfig(ConfigFile config)
		{
			petHealthBoost = config.Bind("Item: " + ItemName, "Pet Health Boost", 0.2f).Value;
			petHealthBoostPerStack = config.Bind("Item: " + ItemName, "Pet Health Boost Per Stack", 0.2f).Value;
			petDamageBoost = config.Bind("Item: " + ItemName, "Pet Damage Boost", 0.2f).Value;
			petDamageBoostPerStack = config.Bind("Item: " + ItemName, "Pet Damage Boost Per Stack", 0.2f).Value;
		}
	}
}