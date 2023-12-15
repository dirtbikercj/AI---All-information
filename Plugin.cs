using BepInEx;
using BepInEx.Configuration;
using Comfort.Common;
using EasySkillOptions.Core;
using EasySkillOptions.Patches;
using EFT;

namespace EasySkillOptions
{
    [BepInPlugin("com.dirtbikercj.EasySkillOptions", "Easy Skill Options", "2.0.0")]
    internal class Plugin : BaseUnityPlugin
    {
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
            
            if (levelingOptions.enableSimpleLevelingMod.Value && Singleton<BackendConfigSettingsClass>.Instantiated)
            {
                levelingOptions.SetSimpleLeveling();
            }

            if (levelingOptions.enableAtrophy.Value && Singleton<BackendConfigSettingsClass>.Instantiated)
            {
                levelingOptions.EnableAtrophy();
            }
            
            if (Singleton<GameWorld>.Instantiated || Singleton<LocalPlayer>.Instantiated)
            {
                eliteSkillToggles.SetToggles();
            }

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
