using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class EyeOfTheVoid : ItemBase<EyeOfTheVoid>
	{
		public override string ItemName => "Eye of the Void";
		public override string ItemLangTokenName => "EYE_OF_THE_VOID";
		public override string ItemPickupDesc => "Chance to receive <style=cIsHealing>doubled rewards</style> from all interactables. Spending too long on a stage will <style=cIsHealth>permanently drain you</style>.";
		public override string ItemFullDescription => $"Interactables have a {payoutChance}% <style=cStack>(+{payoutChancePerStack}% per stack)</style> chance to payout twice. Spending longer than {drainStartTimer} minutes on a stage will begin to reduce your maximum health by {healthDrain} <style=cStack>(+{healthDrainPerStack} per stack)</style> every {drainTick} seconds.";
		public override string ItemLore =>
			"I have seen you, interloper. I acknowledge your presence.\n" + 
			"I am not a foolish being. You are no god.\n\n" +

			"You are vermin in regalia; a pretender king, a clueless tyrant.\n" +
			"You’ve a share of failure that I am not unacquainted with.\n" +
			"Brittle beings beneath you bite at your hide and challenge your reign.\n" +
			"It is this shame we share.\n\n" +

			"But I’ve eyes where I cannot see, and hands where I cannot reach.\n" +
			"They have sampled for me the artifacts of your downfall, sourced from the world of your origin.\n\n" +

			"You too are challenged by greater and far darker seas.\n" +
			"I have been whet of fear by time. This planet is mine.\n\n" +

			"A darkness, void of any light, seeks to consume you and that which you govern?\n" +
			"I shall exploit that.";



		public override ItemTier Tier => ItemTier.TierLunar;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Lunar };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float payoutChance;
		public float payoutChancePerStack;
		public float drainStartTimer;
		public float healthDrain;
		public float healthDrainPerStack;
		public float drainTick;

		protected override void CreateConfig(ConfigFile config)
		{
			payoutChance = config.Bind("Item: " + ItemName, "Payout Chance", 0.2f).Value;
			payoutChancePerStack = config.Bind("Item: " + ItemName, "Payout Chance Per Stack", 0.1f).Value;
			drainStartTimer = config.Bind("Item: " + ItemName, "Drain Start Timer", 300f).Value;
			healthDrain = config.Bind("Item: " + ItemName, "Health Drain", 1f).Value;
			healthDrainPerStack = config.Bind("Item: " + ItemName, "Health Drain Per Stack", 1f).Value;
			drainTick = config.Bind("Item: " + ItemName, "Drain Tick", 2f).Value;
		}
	}
}