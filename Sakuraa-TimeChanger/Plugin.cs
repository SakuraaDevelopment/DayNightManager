using System;
using System.Reflection;
using BepInEx;
using GorillaNetworking;
using UnityEngine;
using Utilla;

namespace Sakuraa_TimeChanger
{
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {

        void Start()
        {
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            HarmonyPatches.RemoveHarmonyPatches();
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            Debug.Log("STC: Game Initialized");
        }

        void Update()
        {
            // Find the BetterDayNight GameObject in the scene
            GameObject betterDayNight = GameObject.Find("BetterDayNight");

            // Get the BetterDayNightManager component
            BetterDayNightManager betterDayNightManager = betterDayNight.GetComponent<BetterDayNightManager>();

            // Use reflection to access the private baseSeconds field
            var baseSecondsField = typeof(BetterDayNightManager).GetField("baseSeconds", BindingFlags.NonPublic | BindingFlags.Instance);
            if (baseSecondsField != null)
            {
                baseSecondsField.SetValue(betterDayNightManager, 26000.0); // night time
            }
        }
    }
}
