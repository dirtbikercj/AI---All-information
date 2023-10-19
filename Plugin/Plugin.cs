using BepInEx;
using Comfort.Common;
using EasySkillOptions.Core;
using EFT;

namespace EasySkillOptions
{
    [BepInPlugin("com.dirtbikercj.EasySkillOptions", "Easy Skill Options", "1.2.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance;

        public Player MainPlayer;
        public EliteSkillToggles eliteSkillToggles;

        private void Awake()
        {
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
