using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Equipment
{
	public class EndlessTorment : EquipmentBase<EndlessTorment>
	{
		public override string Name => "Endless Torment";
		public override string LangToken => "ENDLESS_TORMENT";
		public override string PickupDescription => "<style=cIsHealth>Damage and cripple yourself</style> significantly to <style=cIsHealing>reduce the cost</style> of nearby interactables.";
		public override string FullDescription => $"Upon activation, take {100 * selfDamage}% of your maximum health as damage and prevent healing for {debuffTime} seconds. In exchange, reduce the price of all purchasables within a {discountDistance}m radius by {100 * discountValue}%. This effect can stack multiple times and be fatal.";
		public override string Lore =>
			"<style=cMono>========================================\n" +
			"====   MyBabel Machine Translator   ====\n" +
			"====     [Version 12.45.1.009 ]   ======\n" +
			"========================================\n" +
			"Training... \<100000000 cycles\>\n" +
			"Training... \<4680422 cycles\>\n" +
			"Complete!\n" +
			"Display result? Y/N\n" +
			"Y\n" +
			================================</style>\n\n\n" +

			"Athiz never looked me in the eyes.\n" +
			"He would always avert.\n" +
			"I wanted him.\n\n\n" +

			"My heart tore.\n" +
			"He could play its strings like an instrument.\n" +
			"He never did.\n\n\n" +

			"Athiz left me in pain.\n" +
			"I would have torn my eyes out their sockets for him.\n" +
			"I needed him to return that.\n" + 
			"He never did.\n\n\n" +

			"My claws shook.\n" +
			"They fidgeted with little bones.\n" +
			"Bones I would try and give him.\n" +
			"He would not take them.\n" +
			"He never did.\n\n\n" +

			"He left me in pain. He would not accept my generosity.\n" +
			"Even as we worked together, upon His crafts.\n" +
			"He would not accept my love.\n" +
			"Athiz will feel my torture, as he has broken my heart.\n" +
			"I will make him.\n\n\n" +
			"Fashioned into another of His baubles, he will know then how much I loved him.\n\n\n"

			"I will make his agony long and dry.\n" +
			"Like a scream.\n" +
			"A long, agonizing, bloody scream.\n" +
			"Releasing a cry of endless torment.";


		public override GameObject Model => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject BodyModel => null;
		public override Sprite Icon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanDrop => true;
		public override float Cooldown => 20f;
		public override bool EnigmaCompatible => true;
		public override bool IsBoss => false;
		public override bool IsLunar => true;

		public float selfDamage;
		public float debuffTime;
		public float discountDistance;
		public float discountValue;

		protected override void CreateConfig(ConfigFile config)
		{
			selfDamage = config.Bind("Item: " + Name, "Self Damage", 0.5f).Value;
			debuffTime = config.Bind("Item: " + Name, "Debuff Time", 4f).Value;
			discountDistance = config.Bind("Item: " + Name, "Discount Distance", 15f).Value;
			discountValue = config.Bind("Item: " + Name, "Discount Value", 0.2f).Value;
		}
	}
}