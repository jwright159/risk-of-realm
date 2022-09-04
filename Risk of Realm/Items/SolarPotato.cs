using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class SolarPotato : ItemBase<SolarPotato>
	{
		public override string ItemName => "Solar Potato";
		public override string ItemLangTokenName => "SOLAR_POTATO";
		public override string ItemPickupDesc => "Gradually gain speed while in combat.";
		public override string ItemFullDescription => $"Gain <style=cIsUtility>{100 * speedBuilding}%</style> <style=cStack>(+{100 * speedBuildingPerStack}% per stack)</style> movement speed every {speedTick} second you are in combat up to a maximum of <style=cIsUtility>{100 * speedMaximum}%</style> <style=cStack>(+{100 * speedMaximumPerStack}% per stack)</style>.";
		public override string ItemLore =>
			"Another prototype. Since they made this stuff illegal, we've had to go DIY and the company can't give us any more funding. I don't know how they expect to make more if we've got no money and I don’t know how selling on the black market is going to improve our frankly miserable reputation, but this job is all I have.\n\n" +

			"Anyways, this batch is the closest we've gotten to replicating so far. Power is still diluted, but it's getting close to what that crazy guy at the top of the corporate food chain has been demanding. Maybe if we finish it we'll finally get to cash in our IOU's…\n\n\n" +

			"<style=cSub>-Note attached to a variety of unstable contraband found on an abandoned ship marked \"NexUs\" products. No company with this registration noted within the Federation.</style>;

		public override ItemTier Tier => ItemTier.Tier1;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Utility };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float speedBuilding;
		public float speedBuildingPerStack;
		public float speedTick;
		public float speedMaximum;
		public float speedMaximumPerStack;

		protected override void CreateConfig(ConfigFile config)
		{
			speedBuilding = config.Bind("Item: " + ItemName, "Speed Building", 0.02f).Value;
			speedBuildingPerStack = config.Bind("Item: " + ItemName, "Speed Building Per Stack", 0.01f).Value;
			speedTick = config.Bind("Item: " + ItemName, "Speed Tick", 1f).Value;
			speedMaximum = config.Bind("Item: " + ItemName, "Speed Maximum", 0.2f).Value;
			speedMaximumPerStack = config.Bind("Item: " + ItemName, "Speed Maximum Per Stack", 0.1f).Value;
		}
	}
}