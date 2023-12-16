using BepInEx.Configuration;
using EFT;
using static EasySkillOptions.Plugin;


namespace EasySkillOptions.Core
{
    internal class LevelingOptions
    {
        public ConfigEntry<bool> enableSimpleLevelingMod;
        public ConfigEntry<int> simpleLevelingMod;
        public ConfigEntry<bool> enableAtrophy;

        public void RegisterConfig()
        {
            string mainLevelingMods = "Leveling Modifiers";

            enableSimpleLevelingMod = Instance.Config.Bind(
               mainLevelingMods,
               "Enable simple leveling modifier",
               false,
               "Enables the simple leveling modifier. if disabled reverts back to 1x leveling");

            simpleLevelingMod = Instance.Config.Bind(
               mainLevelingMods,
               "Simple leveling modifier",
               1,
               new ConfigDescription("Leveling speed modifier", new AcceptableValueRange<int>(1, 20)));

            enableAtrophy = Instance.Config.Bind(
               mainLevelingMods,
               "Enable skill atrophy(regression)",
               true,
               "Enables the roll back of skills");   
        }

        private int currentMultiplier = 1;

        public void SetSimpleLeveling()
        {
            if (!enableSimpleLevelingMod.Value || !ShouldChangeValues() || BackendConfig == null)
            {
                return;
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

        public void EnableAtrophy()
        {
            if (enableAtrophy.Value && BackendConfig.SkillAtrophy == false)
            {
                BackendConfig.SkillAtrophy = true;
                return;
            }
            BackendConfig.SkillAtrophy = false;
        }

        private void SetOriginalValues()
        {
                // Fatique
                BackendConfig.SkillPointsBeforeFatigue = 1;
                BackendConfig.SkillFatiguePerPoint = 0.6f;
                BackendConfig.SkillFatigueReset = 200;

                // Progression Multipliers
                BackendConfig.SkillFreshPoints = 1;
                BackendConfig.SkillMinEffectiveness = 0.0001f;
                BackendConfig.SkillsSettings.SkillProgressRate = 0.4f;   
        }

        private bool ShouldChangeValues()
        {
            return currentMultiplier != simpleLevelingMod.Value;
        }
    }
}
