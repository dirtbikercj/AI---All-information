using BepInEx.Configuration;
using static EasySkillOptions.Plugin;

namespace EasySkillOptions.Core
{
    public class SkillMods
    {
        public static ConfigEntry<bool> instantSearch;
        public static ConfigEntry<bool> eliteEndurance;
        public static ConfigEntry<bool> eliteStrength;
        public static ConfigEntry<bool> eliteHealth;

        public void InstantSearch()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!instantSearch.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.AttentionEliteExtraLootExp.Value != true)
            {
                skills.AttentionEliteExtraLootExp.Value = true;
            }

            if (skills.AttentionEliteLuckySearch.Value != 100f)
            {
                skills.AttentionEliteLuckySearch.Value = 100f;
            }

            if (skills.IntellectEliteContainerScope.Value != true)
            {
                skills.IntellectEliteContainerScope.Value = true;
            }
        }

        public void EliteEndurance()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteEndurance.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.EnduranceBuffBreathTimeInc.Value != 200f)
            {
                skills.EnduranceBuffBreathTimeInc.Value = 200f;
            }

            if (skills.EnduranceBuffEnduranceInc.Value != 200f)
            {
                skills.EnduranceBuffEnduranceInc.Value = 200f;
            }

            if (skills.EnduranceBuffRestoration.Value != 2f)
            {
                skills.EnduranceBuffRestoration.Value = 2f;
            }

            if (skills.EnduranceBreathElite.Value != 200f)
            {
                skills.EnduranceBreathElite.Value = 200f;
            }

            if (skills.EnduranceBuffJumpCostRed.Value != 0.3f)
            {
                skills.EnduranceBuffJumpCostRed.Value = 0.3f;
            }

            if (skills.EnduranceHands.Value != 200f)
            {
                skills.EnduranceHands.Value = 200f;
            }
        }

        public void EliteStrength()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteStrength.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.StrengthBuffElite.Value != true)
            {
                skills.StrengthBuffElite.Value = true;
            }

            if (skills.ThrowingEliteBuff.Value != true)
            {
                skills.ThrowingEliteBuff.Value = true;
            }
        }

        public void EliteHealth()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteHealth.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.HealthEliteAbsorbDamage.Value != true)
            {
                skills.HealthEliteAbsorbDamage.Value = true;
            }

            if (skills.VitalityBuffBleedStop.Value != true)
            {
                skills.VitalityBuffBleedStop.Value = true;
            }

            if (skills.VitalityBuffRegeneration.Value != true)
            {
                skills.VitalityBuffRegeneration.Value = true;
            }

            if (skills.VitalityBuffBleedChanceRed.Value != 60f)
            {
                skills.VitalityBuffBleedChanceRed.Value = 60f;
            }

            if (skills.VitalityBuffSurviobilityInc.Value != 20f)
            {
                skills.VitalityBuffSurviobilityInc.Value = 20f;
            }

            if (skills.ImmunityAvoidMiscEffectsChance.Value != 55f)
            {
                skills.ImmunityAvoidMiscEffectsChance.Value = 55f;
            }

            if (skills.ImmunityAvoidPoisonChance.Value != 25f)
            {
                skills.ImmunityAvoidPoisonChance.Value = 25f;
            }

            if (skills.ImmunityPainKiller.Value != 30f)
            {
                skills.ImmunityPainKiller.Value = 30f;
            }

            if (skills.ImmunityPoisonBuff.Value != 50f)
            {
                skills.ImmunityPoisonBuff.Value = 50f;
            }
        }

        public void RegisterConfigs()
        {
            string mainSectionElite = "Easy Skill Options - Elite Toggles";

            instantSearch = Instance.Config.Bind(
               mainSectionElite,
               "Instant Search",
               false,
               "Instantly search containers");

            eliteEndurance = Instance.Config.Bind(
               mainSectionElite,
               "Toggle Elite Endurance",
               false,
               "Enables elite endurance");

            eliteStrength = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Strength",
              false,
              "Enables elite Strength");

            eliteHealth = Instance.Config.Bind(
               mainSectionElite,
               "Toggle Elite Health",
               false,
               "Includes Immunity, Vitality, and Health buffs. Basically makes you way more survivable");
        }
    }
}