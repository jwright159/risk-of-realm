using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class BerylNildrop : ItemBase<BerylNildrop>
	{
		public override string ItemName => "Beryl Nildrop";
		public override string ItemLangTokenName => "BERYL_NILDROP";
		public override string ItemPickupDesc => "Move faster at the beginning of each stage.";
		public override string ItemFullDescription => $"For the first <style=cIsUtility>{baseTime}</style> <style=cStack>(+{timePerStack} per stack)</style> seconds each stage, get a <style=cIsUtility>{baseSpeedBoost * 100}%</style> boost to movement speed.";
		public override string ItemLore => "bepis";

		public override ItemTier Tier => ItemTier.Tier1;

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float baseTime;
		public float timePerStack;
		public float baseSpeedBoost;

		protected override void CreateConfig(ConfigFile config)
		{
			baseTime = config.Bind<float>("Item: " + ItemName, "Time", 20).Value;
			timePerStack = config.Bind<float>("Item: " + ItemName, "Time per Stack", 10).Value;
			baseSpeedBoost = config.Bind<float>("Item: " + ItemName, "Speed Boost", 0.7f).Value;
		}
	}
}