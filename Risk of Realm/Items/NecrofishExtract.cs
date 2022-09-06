using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class NecrofishExtract : ItemBase<NecrofishExtract>
	{
		public override string ItemName => "Necrofish Extract";
		public override string ItemLangTokenName => "NECROFISH_EXTRACT";
		public override string ItemPickupDesc => "Hits have a chance to apply all their status effects numerous times. Corrupts all Plague Flasks.";
		public override string ItemFullDescription => $"Hits have a {100 * multiplyChance}% chance to apply {debuffBoost} <style=cStack>(+{debuffBoostPerStack} per stack)</style> <style=cIsDamage>additional stacks</style> of all status effects they happen to apply. Non-stackable effects have their duration doubled.";
		public override string ItemLore =>
			"...For generations had the colossal beast terrorized the great sea that bordered their illustrious nation state, constructed on a middling isle positioned well into the Irizan Sea of Krater IV. The aquatic monstrosity retained a malice for all living beings inexplicable to the human mind, an aggression unseen before in any creature.\n\n" +
			
			"Its jaws were wider than a schooner, and each tooth larger than three men. It had prevented for hundreds of years an egress from their island. The stars foretold on the cusp of the horizon of a land bountiful and immense, perfect to cultivate their people upon. But the great necrofish would never let their vessels pass, always hungry and ever present.\n\n" +
			
			"Ancient records from the most antiquarian of archives had always recounted the ferocity of the terror that encircled their island, vigilant for those who would seek escape. Early Irizani thought themselves the divine captives of rancorous gods, who taunted the trespassing of the grimy foot of man upon their holy world, once untouched and pristine before the advent of their sentient impure minds. The necrofish became, through the power of oral tradition, their thalassic warden; a fear of the unknown deep made flesh, to constrict their endeavors and choke their people out for their transgressions.\n\n" + 
			
			"So for centuries, generation after generation studied the shed scales of the beast, seeking to penetrate its impregnable hide. With the kingdom's growth, resources upon the island dwindled, and thus it was necessary for their incredible investment to pay off or else no longer would the legend of the Irizani proliferate.\n\n" +
			
			"And at last after years, the titanic harpoon would gut the beast from above, decimating its dorsal fins and skewering its innards. Pushing on yet deeper through its stomach, the shadow of the leviathan would breach the surface with the mechanical reeling of the rope, a cable thicker than a temple's pillar. The necrofish, with a dying wail to the heavens in demand of repentance, would recieve the final laugh, as all of Krater IV's seas were befouled with its toxic blood, rendering the world the Irizani were finally set to inherit entirely inhospitable.\n\n" +
			
			"The noxious oceans would evaporate and then precipitate, a people's dream washed away by torrents of indifferent violet rain.\n\n\n" +

			"<style=cSub>-Galactic Fables, Volume VI</style>";


		public override ItemTier Tier => ItemTier.Tier3;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Void };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float multiplyChance;
		public float debuffBoost;
		public float debuffBoostPerStack;

		protected override void CreateConfig(ConfigFile config)
		{
			multiplyChance = config.Bind("Item: " + ItemName, "Multiply Chance", 0.33f).Value;
			debuffBoost = config.Bind("Item: " + ItemName, "Debuff Boost", 1f).Value;
			debuffBoostPerStack = config.Bind("Item: " + ItemName, "Debuff Boost Per Stack", 1f).Value;
		}
	}
}