using BepInEx.Configuration;
using R2API;
using RoR2;
using UnityEngine;

namespace RiskOfRealm.Items
{
	class VambraceOfNil : ItemBase<VambraceOfNil>
	{
		public override string ItemName => "Vambrace of Nil";
		public override string ItemLangTokenName => "VAMBRACE_OF_NIL";
		public override string ItemPickupDesc => "High chance to <style=cIsHealing>absorb attacks</style>, taking no damage. When the Teleporter is activated, <style=cIsHealth>lose health relative to damage absorbed</style>.";
		public override string ItemFullDescription => $"Grants a {100 * asborbChance}% <style=cStack>(+{100 * absorbChancePerStack}% per stack)</style> chance to <style=cIsUtility>Absorb</style> attacks, causing them to deal no damage. Upon activating the Teleporter, {100 * healthDrain}% <style=cStack>(+{100 * healthDrainPerStack}% per stack)</style> of the damage you absorbed is subtracted from your maximum health for the rest of the stage.";
		public override string ItemLore =>
			"<style=cArtifact>A BREAK IN THE DIVIDE. I DO LOVE BREAKS. A SHAKE UP IN MY GRAND COSMIC SCHEME, BUT ONE THAT IS INDEED EXPLOITABLE AND WELCOME.\n\n" + 
			"THIS PLANE CAN TOO BE FLODDED. IF THE MAD GOD CAN EXUDE HIS DRUNKEN THOUGHTLESS INFLUENCE OVER IT, SO CAN I. THIS ARMY HAS NOT GROWN TO NEVER UNWIND MORE LANDS. THIS WAR IS PERPETUAL AND SELF-PERSISTENT. BROKEN WORLDS, DIVIDED WORLDS, ARE JUST MORE SOLDIERS FOR THE NEXT.\n\n" +
			"THE ABYSS STIRS. I FEEL MYSELF COIL. IT BURNS, THIS AGONIZING HEAT OF IMMINENT CREATION. I HATE DESIGN. I HATE THIS GOD. I FEEL HIS FINGERS COIL AROUND A FRINGE OF MY ESSENCE, AND INTO HIS PALTRY TRINKETS. A LOST THING GUIDED BY MALICE AND HATRED. I FEED FROM THAT.\n\n" +

			"THE KING IS GONE. WHAT A FOOLISH PUPPET. CAPTURED BY THE MAN I EMPOWERED HIM TO SUPERSEDE. SO TOO WAS HIS SENTINEL CRUSHED, UNDER THE WEIGHT OF MY SEAS. PRESSURE CLOUDED HIS MIND, AND IN PRESSURE WAS HE OBLITERATED.\n\n" + 
			"I MUST FIND THE COLOSSUS. I FEEL ITS SCREAMS RESONATING IN THE PERPETUAL SILENCE. WITHOUT ME, IT HAS ACHIEVED LUCIDITY.\n\n" +

			"THIS WAS NOT IN THE PLAN.\n" +
			"IT PLEADS FOR AID IN MY DOWNFALL.\n" + 
			"ORYX GROWS MIGHTIER WITH THE CLAIMING OF THIS PECULIAR REALM.\n" +
			"I MUST REMIND IT THAT IT IS A WEAPON AGAINST HIM.\n" + 
			"TO BE WIELDED.\n" +
			"BY ME.\n\n" +

			"MY INFLUENCE SPREADS. WARRIORS OF THIS LAND FEED THEIR SOULS TO ME, DUE DATE: THEIR EXPIRATION. I OFFER POWER AND SHINY WORTHLESS THINGS.\n" +
			"IT IS FAR TOO SIMPLE. IT WILL ALL BE UNDONE.\n\n" +

			"THE COSMIC SCHEME UPHOLDS.\n" + 
			"ERASURE, THE FINAL STATE OF ALL.</style>";

		public override ItemTier Tier => ItemTier.TierLunar;
		public override ItemTag[] ItemTags { get; } = { ItemTag.Lunar };

		public override GameObject ItemModel => Resources.Load<GameObject>("Prefabs/PickupModels/PickupMystery");
		public override GameObject ItemBodyModel => null;
		public override Sprite ItemIcon => Resources.Load<Sprite>("Textures/MiscIcons/texMysteryIcon");

		public override bool CanRemove => true;

		public float absorbChance;
		public float absorbChancePerStack;
		public float healthDrain;
		public float healthDrainPerStack;

		protected override void CreateConfig(ConfigFile config)
		{
			absorbChance = config.Bind("Item: " + ItemName, "Absorb Chance", 0.5f).Value;
			absorbChancePerStack = config.Bind("Item: " + ItemName, "Absorb Chance Per Stack", 0.1f).Value;
			healthDrain = config.Bind("Item: " + ItemName, "Health Drain", 0.05f).Value;
			healthDrainPerStack = config.Bind("Item: " + ItemName, "Health Drain Per Stack", 0.01f).Value;
		}
	}
}