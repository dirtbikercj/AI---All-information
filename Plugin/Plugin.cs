using BepInEx;
using BepInEx.Configuration;
using Comfort.Common;
using EasySkillOptions.Core;
using EasySkillOptions.Patches;
using EFT;

namespace EasySkillOptions
{
    [BepInPlugin("com.dirtbikercj.EasySkillOptions", "Easy Skill Options", "1.2.3")]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance;

        public Player MainPlayer;
        public EliteSkillToggles eliteSkillToggles;

        public static ConfigEntry<bool> QuickGrenade;

        private void Awake()
        {
            QuickGrenade = Config.Bind(
               "General",
               "Quck Throw Grenades",
               false,
               "Instantly throw grenades");

            new GrenadePatch().Enable();

            Instance = this;
            DontDestroyOnLoad(Instance);

            eliteSkillToggles = new EliteSkillToggles();
            eliteSkillToggles.RegisterConfig();
        }

        private void Update()
        {
            if (!Singleton<GameWorld>.Instantiated)
            {
                MainPlayer = null;
                return;
            }

            if (MainPlayer == null) 
            {
                MainPlayer = Singleton<GameWorld>.Instance.MainPlayer;
            }

            eliteSkillToggles.SetToggles();
            //skillMods.SetSliderValues();
        }
    }
}
