using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Equipment
{
	public class FungalTome : EquipmentBase<FungalTome>
	{
		public override string Name => "Fungal Tome";
		public override string LangToken => "FUNGAL_TOME";
		public override string PickupDescription => "Places fungal healing circles on the ground.";
		public override string FullDescription => $" Places {healZone}m healing circles on the ground that heal allies for {100 * healRate}% health every second to all allies in range, lasting {zoneDuration} seconds.";
		public override string Lore =>
			"<style=cMono>========================================\n" +
			"====   MyBabel Machine Translator   ====\n" +
			"====     [Version 12.45.1.009 ]   ======\n" +
			"========================================\n" +
			"Training... \<100000000 cycles\>\n" +
			"Training... \<3964210 cycles\>\n" +
			"Complete!\n" +
			"Display result? Y/N\n" +
			"Y</style>\n\n\n\n" +

			"Oingo puts his palm on my shoulder. The rock worm shakes the cavern as it burrows. Pretty crystalline fangs break the surface. It is retreating down.\n\n" +
			"Dibli'bli has taken to the foot of the \"worship hole\". The rock worm's descent means the nightmare spirits are coming. We must retreat to the sanctuary. I hear Dibli'bli shout out holy words, and big greens and little yellows come running from neighboring dens.\n\n" +
			"This is what the tribe has prepared for. My little spider Ababababa makes little chittery noises with his little fangs, ready to pounce. The nightmare spirits thunder forth. Dibli'bli prepares \"spore circle\". Oingo holds forth spear. Hapip'oonga yells a battle cry as he mounts the \"big yellow worm\". It will do some damage.\n\n" +
			"Thundering grows louder. The mushrooms grow from the cavern floor. They leak \"green pus\", to slow nightmare spirits down, and create the little clouds to seal our wounds.\n\n" +
			"I hope in our defense of the tribe, nightmare spirits do not take bite of me. They took bite out of Quinbo and he never recovered.\n\n\n" +

			"THEY ARE HERE. THEY YELL BATTLE CRIES.\n" +
			"<style=cSub>\"RL GIRL?\"\n" +
			"\"SELL 2 VIT 1 LIFE\"\n" +
			"\"FIVE TO FIVE FIVE\"</style>\n\n\n" +

			"It was very menacing. But the mushrooms healed us. Big rock sprouted from ground on top of nightmare spirit when Ababababa hurdled forth. Nightmare spirit died. Ababababa died. Sad. I am very sad.\n\n" + 
			"I ran away. Dibli'bli is dead. Nightmare spirit took his book. The shroom gods are angry.\n" + 
			"And so am I.";

		public override GameObject Model => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject BodyModel => null;
		public override Sprite Icon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanDrop => true;
		public override float Cooldown => 30f;
		public override bool EnigmaCompatible => true;
		public override bool IsBoss => false;
		public override bool IsLunar => false;

		public float healZone;
		public float healRate;
		public float zoneDuration;

		protected override void CreateConfig(ConfigFile config)
		{
			healZone = config.Bind("Item: " + Name, "Heal Zone", 10f).Value;
			healRate = config.Bind("Item: " + Name, "Heal Rate", 0.055f).Value;
			zoneDuration = config.Bind("Item: " + Name, "Zone Duration", 6f).Value;
		}
	}
}