using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Equipment
{
	public class ShieldOfOgmur : EquipmentBase<ShieldOfOgmur>
	{
		public override string Name => "Shield of Ogmur";
		public override string LangToken => "SHIELD_OF_OGMUR";
		public override string PickupDescription => "Release a damaging burst that reduces enemy armor.";
		public override string FullDescription => $"On use, releases a {damageZone}m radial wave that Pulverizes all enemies for {debuffTime} seconds and deals {100 * shieldDamage}% base damage.";
		public override string Lore =>
			"SUNDAY! SUNDAY! SUNDAY! One night only, folks! The Shendora family brings you the finest gladiators from across the stars to do battle in our arenas. Our clan is famed for the drama and excitement that these bouts bring, and you definitely don't want to miss this one! Our most glorious champion, Grognak the Impervious, faces off against a new challenger: an authentic Knight of the fallen nation of Ogmur!";

		public override GameObject Model => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject BodyModel => null;
		public override Sprite Icon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanDrop => true;
		public override float Cooldown => 40f;
		public override bool EnigmaCompatible => true;
		public override bool IsBoss => false;
		public override bool IsLunar => false;

		public float damageZone;
		public float debuffTime;
		public float shieldDamage;

		protected override void CreateConfig(ConfigFile config)
		{
			damageZone = config.Bind("Item: " + Name, "Damage Zone", 10f).Value;
			debuffTime = config.Bind("Item: " + Name, "Debuff Time", 8f).Value;
			shieldDamage = config.Bind("Item: " + Name, "Shield Damage", 4f).Value;
		}
	}
}