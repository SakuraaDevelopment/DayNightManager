using System;
using System.Reflection;
using BepInEx;
using UnityEngine;
using Utilla;

namespace Sakuraa_DayNightManager
{
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {

        void OnGameInitialized(object sender, EventArgs e)
        {
            Debug.Log("DNM: Game Initialized");
        }

        void Update()
        {
            GameObject betterDayNight = GameObject.Find("BetterDayNight");
            BetterDayNightManager betterDayNightManager = betterDayNight.GetComponent<BetterDayNightManager>();
            var baseSecondsField = typeof(BetterDayNightManager).GetField("baseSeconds", BindingFlags.NonPublic | BindingFlags.Instance);
            if (baseSecondsField != null)
            {
                baseSecondsField.SetValue(betterDayNightManager, 10000.0);
            }
        }
    }
}
