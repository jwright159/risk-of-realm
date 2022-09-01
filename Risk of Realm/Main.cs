using System;
using BepInEx;
using R2API;
using R2API.Utils;
using System.Reflection;
using UnityEngine;
using RiskOfRealm.Items;
using RoR2;
using System.Linq;
using System.Collections.Generic;
using BepInEx.Logging;

namespace RiskOfRealm
{
	[BepInDependency(R2API.R2API.PluginGUID, R2API.R2API.PluginVersion)]
	[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
	[BepInPlugin(ModGUID, ModName, ModVersion)]
	[R2APISubmoduleDependency(nameof(ItemAPI), nameof(LanguageAPI), nameof(RecalculateStatsAPI))]
	public class Main : BaseUnityPlugin
	{
		public const string ModGUID = "com.github.jwright159.risk-of-realm";
		public const string ModName = "Risk of Realm";
		public const string ModVersion = "1.0.0";

		public static AssetBundle Assets;

		public static ManualLogSource ModLogger;

		private void Awake()
		{
			Logger.LogInfo($"Starting Risk of Realm");
			ModLogger = Logger;

			//using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("RiskOfRealm.risk_of_realm_assets"))
			//Assets = AssetBundle.LoadFromStream(stream);

			Configs();

			Hooks();

			foreach (Type itemType in Assembly.GetExecutingAssembly().GetTypes().Where(type => !type.IsAbstract && type.IsSubclassOf(typeof(ItemBase))))
			{
				ItemBase item = (ItemBase)Activator.CreateInstance(itemType);
				item.Init(Config);
				Logger.LogInfo($"{item.ItemName} initialized");
			}
		}

		public void Configs()
		{
		
		}

		public void Hooks()
		{
		
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.F2))
			{
				Logger.LogDebug("Spawning Elixir");
				Transform player = PlayerCharacterMasterController.instances[0].master.GetBodyObject().transform;
				PickupDropletController.CreatePickupDroplet(PickupCatalog.FindPickupIndex(ElixirOfDefense.Instance.itemDef.itemIndex), player.position, player.forward * 20f);
			}
		}
	}
}
