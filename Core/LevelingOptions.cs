using BepInEx.Configuration;
using EFT;
using static EasySkillOptions.Plugin;


namespace EasySkillOptions.Core
{
    internal class LevelingOptions
    {
        public ConfigEntry<bool> enableSimpleLevelingMod;
        public static ConfigEntry<int> simpleLevelingMod;
        
        public ConfigEntry<bool> enableAdvancedLevelingMod;
        public static ConfigEntry<float> freshSkillPoints;
        public static ConfigEntry<float> skillPointsBeforeFatique;
        public static ConfigEntry<float> skillPointsResetTime;
        public static ConfigEntry<float> skillPointsFreshEffectivness;
        public static ConfigEntry<float> skillFatiquePerPoint;
        public static ConfigEntry<float> skillMinEffectiveness;
        public static ConfigEntry<float> skillProgressRate;
        public static ConfigEntry<bool> enableAtrophy;

        public void RegisterConfig()
        {
            string mainLevelingMods = "Simple Leveling Modifier";
            string advancedLevelingMods = "Advanced Leveling Modifiers";

            enableSimpleLevelingMod = Instance.Config.Bind(
               mainLevelingMods,
               "Enable simple leveling modifier",
               false,
               "Enables the simple leveling modifier. if disabled reverts back to 1x leveling, this will also deactivate the advanced leveling options if enabled");

            simpleLevelingMod = Instance.Config.Bind(
               mainLevelingMods,
               "Simple leveling modifier",
               1,
               new ConfigDescription("Leveling speed modifier", new AcceptableValueRange<int>(1, 20)));

            
            // Advanced leveling
            
            
            enableAdvancedLevelingMod = Instance.Config.Bind(
               advancedLevelingMods,
               "Enable advanced leveling config",
               false,
               "Enables the advanced leveling configs. if enabled disables the simple leveling modifier");

            freshSkillPoints = Instance.Config.Bind(
               advancedLevelingMods,
               "Fresh skill points",
               1f,
               new ConfigDescription("Amount of fresh skill points you have", new AcceptableValueRange<float>(1, 100)));

            skillPointsBeforeFatique = Instance.Config.Bind(
               advancedLevelingMods,
               "skill points before fatique",
               2f,
               new ConfigDescription("Amount of fresh skill points before skill fatique kicks in", new AcceptableValueRange<float>(1, 100)));

            skillPointsResetTime = Instance.Config.Bind(
               advancedLevelingMods,
               "skill point fatique reset time",
               300f,
               new ConfigDescription("Amount of time in seconds before fatique resets", new AcceptableValueRange<float>(1, 1000)));

            skillPointsFreshEffectivness = Instance.Config.Bind(
               advancedLevelingMods,
               "Fresh skill point multiplier",
               1.2f,
               new ConfigDescription("Multiplies the points per action of fresh points", new AcceptableValueRange<float>(1, 10)));

            skillFatiquePerPoint = Instance.Config.Bind(
               advancedLevelingMods,
               "Skill fatique per point",
               0.5f,
               new ConfigDescription("How much fatique is accumulated per skill point gained", new AcceptableValueRange<float>(1, 10)));

            skillMinEffectiveness = Instance.Config.Bind(
               advancedLevelingMods,
               "Min skill effectiveness",
               0.01f,
               new ConfigDescription("minimum skill point gained per action", new AcceptableValueRange<float>(0, 10)));

            skillProgressRate = Instance.Config.Bind(
               advancedLevelingMods,
               "Skill progress rate",
               0.4f,
               new ConfigDescription("How often actions can occur", new AcceptableValueRange<float>(0, 10)));

            enableAtrophy = Instance.Config.Bind(
               advancedLevelingMods,
               "Enable skill atrophy(regression)",
               true,
               "Enables the roll back of skills");
        }

        #region Simple Leveling

        private int currentMultiplier = 1;

        public void SetSimpleLeveling()
        {
            if (!enableSimpleLevelingMod.Value || !ShouldChangeValues() || BackendConfig == null)
            {
                return;
            }

            // If advanced leveling is enabled,
            // Disable it and proceed
            if (enableAdvancedLevelingMod.Value)
            {
                enableAdvancedLevelingMod.Value = false;
            }

            // Make sure we always set the original values first, before setting the new ones
            SetOriginalValues();

            // Fatique
            BackendConfig.SkillPointsBeforeFatigue *= simpleLevelingMod.Value;
            BackendConfig.SkillFatiguePerPoint /= simpleLevelingMod.Value;
            BackendConfig.SkillFatigueReset /= simpleLevelingMod.Value;

            // Progression Multipliers
            BackendConfig.SkillFreshPoints *= simpleLevelingMod.Value;
            BackendConfig.SkillMinEffectiveness *= simpleLevelingMod.Value;
            BackendConfig.SkillsSettings.SkillProgressRate *= simpleLevelingMod.Value;

            // Set the current multiplier so we dont repeat the process if not needed
            currentMultiplier = simpleLevelingMod.Value;
        }

        private void SetOriginalValues()
        {
                // Fatique
                BackendConfig.SkillPointsBeforeFatigue = 1;
                BackendConfig.SkillFatiguePerPoint = 0.6f;
                BackendConfig.SkillFatigueReset = 300;

                // Progression Multipliers
                BackendConfig.SkillMinEffectiveness = 0.01f;
                BackendConfig.SkillFatiguePerPoint = 0.5f;
                BackendConfig.SkillFreshPoints = 1;
                BackendConfig.SkillMinEffectiveness = 0.0001f;
                BackendConfig.SkillsSettings.SkillProgressRate = 0.4f;   
        }

        private bool ShouldChangeValues()
        {
            return currentMultiplier != simpleLevelingMod.Value;
        }

        #endregion

        public void SetadvancedLeveling()
        {
            // If the backend is null
            // or the mod is not enabled, return early
            if (BackendConfig == null || !enableAdvancedLevelingMod.Value)
            {
                return;
            }

            // If simple leveling is enabled,
            // Disable it and proceed
            if (enableSimpleLevelingMod.Value)
            {
                enableSimpleLevelingMod.Value = false;
            }

            SetOriginalValues();
            SetSkillPoints();
        }

        private void SetSkillPoints()
        {
            if (BackendConfig.SkillFreshPoints != freshSkillPoints.Value)
            {
                BackendConfig.SkillFreshPoints = (int)freshSkillPoints.Value;
            }

            if (BackendConfig.SkillPointsBeforeFatigue != skillPointsBeforeFatique.Value)
            {
                BackendConfig.SkillPointsBeforeFatigue = (int)skillPointsBeforeFatique.Value;
            }

            if (BackendConfig.SkillFatigueReset != skillPointsResetTime.Value)
            {
                BackendConfig.SkillPointsBeforeFatigue = (int)skillPointsResetTime.Value;
            }

            if (BackendConfig.SkillFatigueReset != skillPointsResetTime.Value)
            {
                BackendConfig.SkillPointsBeforeFatigue = (int)skillPointsResetTime.Value;
            }

            if (BackendConfig.SkillFreshEffectiveness != skillPointsFreshEffectivness.Value)
            {
                BackendConfig.SkillFreshEffectiveness = skillPointsFreshEffectivness.Value;
            }

            if (BackendConfig.SkillFatiguePerPoint != skillFatiquePerPoint.Value)
            {
                BackendConfig.SkillFatiguePerPoint = skillFatiquePerPoint.Value;
            }

            if (BackendConfig.SkillMinEffectiveness != skillMinEffectiveness.Value)
            {
                BackendConfig.SkillMinEffectiveness = skillMinEffectiveness.Value;
            }

            if (BackendConfig.SkillsSettings.SkillProgressRate != skillProgressRate.Value)
            {
                BackendConfig.SkillsSettings.SkillProgressRate = skillProgressRate.Value;
            }

            if (enableAtrophy.Value && BackendConfig.SkillAtrophy == false)
            {
                BackendConfig.SkillAtrophy = true;

            }
            else if (!enableAtrophy.Value && BackendConfig.SkillAtrophy == true)
            {
                BackendConfig.SkillAtrophy = false;
            }
        }
    }
}
