using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class SentinelsCuirass : ItemBase<SentinelsCuirass>
	{
		public override string ItemName => "Sentinel's Cuirass";
		public override string ItemLangTokenName => "SENTINELS_CUIRASS";
		public override string ItemPickupDesc => "Gain Armor over time. Temporarily lose Armor when damaged.";
		public override string ItemFullDescription => $"Gain <style=cIsUtility>+{baseArmor} Armor</style>. Grants additional Armor that builds up over {bonusArmorBuilding} seconds to a maximum of {bonusArmorCap} <style=cStack>(+{bonusArmorCapPerStack} per stack)</style>. Upon taking damage, reduce this bonus Armor by {100 * {armorHurt}% of the damage sustained.";
		public override string ItemLore =>
			"My loyal sentinel entered the throne room.\n" +
			"\"Through the gloom\" he spoke, \"I see impending doom...\"\n" +
			"\"I found this,\", a slab, slathered in murky purple ooze.\n" +
			"He gave me a peer, with ruin coming into view.\n\n" +

			"The voice in my head told me to decline.\n" +
			"<style=cArtifact>\"What does he take you for? A cube that is blind!" +
			"Go and show HIM a piece of your mind!\"</style>\n\n" + 

			"I slowly rose from my seat.\n" +
			"My heart skipped a beat as I got to my feet.\n" +
			"\"Let me be discreet, and with all due respects\n" +
			"But your bets seem to me like nothing but jests.\n" +
			"My patron sees clearly through the veil of time.\n" +
			"So I assure you to pay the future no mind.\"\n\n" +

			"But Valen would not have it.\n" +
			"\"Death was coming\", he insisted.\n" +
			"And with every qualm he rose,\n" +
			"I had always resisted.\n" +
			"He was sent off to his chamber\n" +
			"And to leave for the night.\n" +
			"Everything was going to be alright.\n\n\n" +

			"<style=cEvent>-The Tragedy of King [REDACTED], Act IV Scene II</style>";


		public override ItemTier Tier => ItemTier.Tier3;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Utility };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float baseArmor;
		public float bonusArmorBuilding;
		public float bonusArmorCap;
		public float bonusArmorCapPerStack;
		public float armorHurt;

		protected override void CreateConfig(ConfigFile config)
		{
			baseArmor = config.Bind("Item: " + ItemName, "Base Armor", 50f).Value;
			bonusArmorBuilding = config.Bind("Item: " + ItemName, "Bonus Armor Building", 15f).Value;
			bonusArmorCap = config.Bind("Item: " + ItemName, "Bonus Armor Cap", 150f).Value;
			bonusArmorCapPerStack = config.Bind("Item: " + ItemName, "Bonus Armor Cap Per Stack", 75f).Value;
			armorHurt = config.Bind("Item: " + ItemName, "Armor Hurt", 0.5f).Value;
		}
	}
}