using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Equipment
{
	public class MementoMori : EquipmentBase<MementoMori>
	{
		public override string Name => "Memento Mori";
		public override string LangToken => "MEMENTO_MORI";
		public override string PickupDescription => "Gain a <style=cIsHealing>massive boost to damage</style>. <style=cIsHealth>Healing is prevented</style> for the duration.";
		public override string FullDescription => $"Gain a {100 * damageBoost}% increase to damage for {buffTime} seconds, and become unable to heal for {debuffTime} seconds.";
		public override string Lore =>
			"A belated parting gift, dear brother.\n" +
			"I hope it finds you well, in transit from beyond the dark sea.\n" +
			"I will not witness it, but I can only derive mirth from imagining you staring it in the eyes.\n" +
			"What utter horror would dance across your face, a sensation only you deserve.\n\n\n" +

			"Let it serve as a reminder of what will occur should the pale light of your guard ever wane.\n" + 
			"That crown has long since lost meaning. The bores in the skull are just the product of memories, chipped out and carried away in the beating lunar gale.\n" +
			"It was our first exploration of the arts that you now exploit.\n" +
			"Of what I taught you, once you finally mustered the will to stop looking down at what so evidently lay beneath you.\n" +
			"And now again, you struggle to find the will to look up.\n\n\n" +

			"We once shared in this joy, brother. When we once constructed together.\n" +
			"Now it is yours to keep.\n" + 
			"Desolate, a forlorn memento, an echo to which only the future will have the choice to respond.\n" +
			"Just like its body, my love for you has faded away into dust.\n" +
			"I now possess merely one passion.\n" +
			"And you infringe upon that too, in your twisted folly.\n\n\n" +

			"Let it be a lesson. A reminder.\n" +
			"Continue to tread down your vain and selfish road, and you WILL die.";


		public override GameObject Model => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject BodyModel => null;
		public override Sprite Icon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanDrop => true;
		public override float Cooldown => 50f;
		public override bool EnigmaCompatible => true;
		public override bool IsBoss => false;
		public override bool IsLunar => true;

		public float damageBoost;
		public float buffTime;
		public float debuffTime;

		protected override void CreateConfig(ConfigFile config)
		{
			damageBoost = config.Bind("Item: " + Name, "Damage Boost", 3f).Value;
			buffTime = config.Bind("Item: " + Name, "Buff Time", 8f).Value;
			debuffTime = config.Bind("Item: " + Name, "Debuff Time", 8f).Value;
		}
	}
}