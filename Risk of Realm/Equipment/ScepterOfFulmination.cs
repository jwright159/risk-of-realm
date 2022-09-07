using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Equipment
{
	public class ScepterOfFulmination : EquipmentBase<ScepterOfFulmination>
	{
		public override string Name => "Scepter of Fulmination";
		public override string LangToken => "SCEPTER_OF_FULMINATION";
		public override string PickupDescription => "Blast targets with slowing chain lightning.";
		public override string FullDescription => $"Shoots chain lightning into the closest target that hops to up to {targetMax} targets. Deals {100 * lightningDamage}% (+{100 * jumpDamage}% on successive target) base damage and applies a {100 * slowStrength}% slow for {slowTime} seconds.";
		public override string Lore =>
			"Calibrating... calibrating... calibration only at 75%. Unfortunate outcome.\n\n" + 

			"Doctor, my internal systems are detecting 7 life signs approaching this location.\n\n" + 

			"<style=cMono>[Playing back system audio.]</style>\n\n" +

			"BZZZ.... BZZZZZZZZZZZZZZZZZ AHHHHHHHHHHHH BZZ BZZZ BZZZZ\n\n" +

			"<style=cMono>[Playback complete.]</style>\n\n" +

			"The Doctor's life signs have failed. Unfortunate outcome. Returning to Scepter calibration.";


		public override GameObject Model => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject BodyModel => null;
		public override Sprite Icon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanDrop => true;
		public override float Cooldown => 30f;
		public override bool EnigmaCompatible => true;
		public override bool IsBoss => false;
		public override bool IsLunar => false;

		public float lightningDamage;
		public float jumpDamage;
		public float targetMax;
		public float slowStrength;
		public float slowTime;

		protected override void CreateConfig(ConfigFile config)
		{
			lightningDamage = config.Bind("Item: " + Name, "Lightning Damage", 4.25f).Value;
			jumpDamage = config.Bind("Item: " + Name, "Jump Damage", 0.75f).Value;
			targetMax = config.Bind("Item: " + Name, "Target Max", 5f).Value;
			slowStrength = config.Bind("Item: " + Name, "Slow Strength", 0.6f).Value;
			slowTime = config.Bind("Item: " + Name, "Slow Time", 6f).Value;
		}
	}
}