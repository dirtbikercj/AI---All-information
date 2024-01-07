using BepInEx;
using BepInEx.Configuration;
using Comfort.Common;
using DrakiaXYZ.VersionChecker;
using EasySkillOptions.Core;
using EasySkillOptions.Patches;
using EFT;
using System;

namespace EasySkillOptions
{
    [BepInPlugin("com.dirtbikercj.EasySkillOptions", "Easy Skill Options", "2.0.3")]
    internal class Plugin : BaseUnityPlugin
    {
        public const int TarkovVersion = 26535;

        internal static Plugin Instance;
        internal static BackendConfigSettingsClass BackendConfig;

        internal Player MainPlayer;
        internal EliteSkillToggles eliteSkillToggles;
        internal LevelingOptions levelingOptions;

        private InstantCraftingPatch _craftingPatch;
        private bool _isCraftingPatchEnabled = false;

        internal static ConfigEntry<bool> QuickGrenade;

        private void Awake()
        {
            if (!VersionChecker.CheckEftVersion(Logger, Info, Config))
            {
                throw new Exception("Invalid EFT Version");
            }

            QuickGrenade = Config.Bind(
               "General",
               "Quick Throw Grenades",
               false,
               "Instantly throw grenades");

            new GrenadePatch().Enable();

            BackendConfig = Singleton<BackendConfigSettingsClass>.Instance;

            Instance = this;
            DontDestroyOnLoad(Instance);

            eliteSkillToggles = new EliteSkillToggles();
            levelingOptions = new LevelingOptions();

            eliteSkillToggles.RegisterConfig();
            levelingOptions.RegisterConfig();

            _craftingPatch = new InstantCraftingPatch();
            _isCraftingPatchEnabled = eliteSkillToggles.instantCrafting.Value;
   
        }

        private void Update()
        {
            if (MainPlayer == null && Singleton<GameWorld>.Instantiated) 
            {
                MainPlayer = Singleton<GameWorld>.Instance.MainPlayer;
            }

            if (BackendConfig == null && Singleton<BackendConfigSettingsClass>.Instantiated)
            {
                BackendConfig = Singleton<BackendConfigSettingsClass>.Instance;
            }

            /*
            if (levelingOptions.enableSimpleLevelingMod.Value && Singleton<BackendConfigSettingsClass>.Instantiated)
            {
                levelingOptions.SetSimpleLeveling();
            }
            */

            if (levelingOptions.enableAdvancedLevelingMod.Value && Singleton<BackendConfigSettingsClass>.Instantiated)
            {
                levelingOptions.SetadvancedLeveling();
            }
            
            if (Singleton<GameWorld>.Instantiated)
            {
                eliteSkillToggles.SetToggles();
            }

            CheckEnablePatches();
        }


        private void CheckEnablePatches()
        {
            // Instant Crafting
            if (eliteSkillToggles.instantCrafting.Value && !_isCraftingPatchEnabled)
            {
                _craftingPatch.Enable();
                _isCraftingPatchEnabled = true;
            }
            else if (!eliteSkillToggles.instantCrafting.Value && _isCraftingPatchEnabled)
            {
                _craftingPatch.Disable();
                _isCraftingPatchEnabled = false;
            }
        }
    }
}
