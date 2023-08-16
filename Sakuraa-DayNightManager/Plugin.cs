using System;
using System.Reflection;
using BepInEx;
using UnityEngine;
using Utilla;

namespace Sakuraa_DayNightManager
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        private GameObject betterDayNight;

        void OnGameInitialized(object sender, EventArgs e)
        {
            Debug.Log("DNM: Game Initialized");
        }

        void Start()
        {
            betterDayNight = GameObject.Find("BetterDayNight");
            if (betterDayNight == null)
            {
                Debug.LogError("DNM: BetterDayNight GameObject not found!");
                return;
            }
        }

        void Update()
        {
            if (betterDayNight == null)
            {
                Debug.LogError("DNM: BetterDayNight GameObject not found!");
                return;
            }

            BetterDayNightManager betterDayNightManager = betterDayNight.GetComponent<BetterDayNightManager>();
            if (betterDayNightManager == null)
            {
                Debug.LogError("DNM: BetterDayNightManager component not found!");
                return;
            }

            var baseSecondsField = typeof(BetterDayNightManager).GetField("baseSeconds", BindingFlags.NonPublic | BindingFlags.Instance);
            if (baseSecondsField != null)
            {
                baseSecondsField.SetValue(betterDayNightManager, 2000.0);
            }
        }
    }
}
