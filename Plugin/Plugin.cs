using BepInEx;
using Comfort.Common;
using EasySkillOptions.Core;
using EFT;

namespace EasySkillOptions
{
    [BepInPlugin("com.dirtbikercj.EasySkillOptions", "Easy Skill Options", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin Instance;

        public Player MainPlayer;
        public SkillMods skillMods;

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(Instance);

            skillMods = new SkillMods();
            skillMods.RegisterConfigs();
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

            skillMods.InstantSearch();
            skillMods.EliteEndurance();
            skillMods.EliteStrength();
            skillMods.EliteHealth();
        }
    }
}
