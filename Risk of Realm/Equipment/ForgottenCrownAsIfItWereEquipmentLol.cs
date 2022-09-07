using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Equipment
{
	public class ForgottenCrownAsIfItWereEquipmentLol : EquipmentBase<ForgottenCrownAsIfItWereEquipmentLol>
	{
		public override string EquipmentName => "Forgotten Crown";
		public override string EquipmentLangTokenName => "FORGOTTEN_CROWN";
		public override string EquipmentPickupDesc => "Killing enemies <style=cIsHealing>raises all stats</style>. <style=cIsHealth>All stats drain over time.</style>";
		public override string EquipmentFullDescription => $"Killing an enemy raises all stats by {100 * statsPerKill}%, up to a maximum of {100 * statsKillCap}% <style=cStack>(+{100 * statsKillCapPerStack}% per stack)</style>. All stats decay by {100 * statsDecay}% <style=cStack>(+{100 * statsDecayPerStack})% per stack</style>, after not killing enemies for <style=cIsUtility>{gracePeriod}</style> seconds.";
		public override string EquipmentLore =>
			"<style=cMono>\"An eerie reminder of what lays in the depths of...\"</style>\n" +
			"The rest of the cracked old tablet was chipped. He could only wonder.";

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanDrop => true;
		public override float Cooldown => 60f;
		public override bool EnigmaCompatible => true;
		public override bool IsBoss => false;
		public override bool IsLunar => false;

		public float statsPerKill;
		public float statsKillCap;
		public float statsKillCapPerStack;
		public float statsDecay;
		public float statsDecayPerStack;
		public float gracePeriod;

		protected override void CreateConfig(ConfigFile config)
		{
			statsPerKill = config.Bind("Item: " + EquipmentName, "Stats Per Kill", 0.02f).Value;
			statsKillCap = config.Bind("Item: " + EquipmentName, "Stats Kill Cap", 0.3f).Value;
			statsKillCapPerStack = config.Bind("Item: " + EquipmentName, "Stats Kill Cap Per Stack", 0.15f).Value;
			statsDecay = config.Bind("Item: " + EquipmentName, "Stats Decay", 0.01f).Value;
			statsDecayPerStack = config.Bind("Item: " + EquipmentName, "Stats Decay Per Stack", 0.005f).Value;
			gracePeriod = config.Bind("Item: " + EquipmentName, "Grace Period", 4f).Value;
		}
	}
}
