using BepInEx.Configuration;
using System.Security.Permissions;
using static EasySkillOptions.Plugin;

namespace EasySkillOptions.Core
{
    public class SkillMods
    {
        public static ConfigEntry<bool> instantSearch;
        public static ConfigEntry<bool> eliteEndurance;
        public static ConfigEntry<bool> eliteStrength;
        public static ConfigEntry<bool> eliteHealth;

        #region SLIDERS
        public static ConfigEntry<float> attentionLootSpeed;
        public static ConfigEntry<float> attentionExamine;

        public static ConfigEntry<float> CharismaDailyQuestsReroll;
        public static ConfigEntry<float> CharismaHealingDiscount;
        public static ConfigEntry<float> CharismaInsuranceDiscount;
        public static ConfigEntry<float> charismaExfilDiscount;

        public static ConfigEntry<float> intellectLearningSpeed;
        public static ConfigEntry<float> intellectWeaponMaintance;
        public static ConfigEntry<float> intellectRepairPointsCostReduction;

        public static ConfigEntry<float> memoryMentalForget1;
        public static ConfigEntry<float> memoryMentalForget2;

        public static ConfigEntry<float> perceptionHearing;
        public static ConfigEntry<float> perceptionLootDot;
        

        #endregion

        #region TOGGLES
        public void SetToggles()
        {
            InstantSearch();
            EliteEndurance();
            EliteStrength();
            EliteHealth();
        }

        private void InstantSearch()
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

        private void EliteEndurance()
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

        private void EliteStrength()
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

        private void EliteHealth()
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

        #endregion

        #region SLIDERS
        public void SetSliderValues()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteHealth.Value)
            {
                return;
            }

            SetAttention();
            SetCharisma();
            SetIntellect();
            SetMemory();
            SetPerception();
            
        }

        private void SetAttention()
        {
            var skills = Instance.MainPlayer.Skills;

            if (skills.AttentionLootSpeed.PerLevel(Normalize(attentionLootSpeed.Value)) != Normalize(attentionLootSpeed.Value))
            {
                skills.AttentionLootSpeed.PerLevel(Normalize(attentionLootSpeed.Value));
            }

            if (skills.AttentionExamine.PerLevel(Normalize(attentionExamine.Value)) != Normalize(attentionExamine.Value))
            {
                skills.AttentionExamine.PerLevel(Normalize(attentionExamine.Value));
            }
        }

        private void SetCharisma()
        {
            var skills = Instance.MainPlayer.Skills;

            if (skills.CharismaDailyQuestsRerollDiscount.PerLevel(Normalize(CharismaDailyQuestsReroll.Value)) != Normalize(CharismaDailyQuestsReroll.Value))
            {
                skills.CharismaDailyQuestsRerollDiscount.PerLevel(Normalize(CharismaDailyQuestsReroll.Value));
            }

            if (skills.CharismaHealingDiscount.PerLevel(Normalize(CharismaHealingDiscount.Value)) != Normalize(CharismaHealingDiscount.Value))
            {
                skills.CharismaHealingDiscount.PerLevel(Normalize(CharismaHealingDiscount.Value));
            }

            if (skills.CharismaInsuranceDiscount.PerLevel(Normalize(CharismaInsuranceDiscount.Value)) != Normalize(CharismaInsuranceDiscount.Value))
            {
                skills.CharismaInsuranceDiscount.PerLevel(Normalize(CharismaInsuranceDiscount.Value));
            }

            if (skills.CharismaExfiltrationDiscount.PerLevel(Normalize(charismaExfilDiscount.Value)) != Normalize(charismaExfilDiscount.Value))
            {
                skills.CharismaExfiltrationDiscount.PerLevel(Normalize(charismaExfilDiscount.Value));
            }
        }

        private void SetEndurance()
        {

        }

        private void SetIntellect()
        {
            var skills = Instance.MainPlayer.Skills;

            if (skills.IntellectLearningSpeed.PerLevel(Normalize(intellectLearningSpeed.Value)) != Normalize(intellectLearningSpeed.Value))
            {
                skills.IntellectLearningSpeed.PerLevel(Normalize(intellectLearningSpeed.Value));
            }

            if (skills.IntellectWeaponMaintance.PerLevel(Normalize(intellectWeaponMaintance.Value)) != Normalize(intellectWeaponMaintance.Value))
            {
                skills.IntellectWeaponMaintance.PerLevel(Normalize(intellectWeaponMaintance.Value));
            }

            if (skills.IntellectRepairPointsCostReduction.PerLevel(Normalize(intellectRepairPointsCostReduction.Value)) != Normalize(intellectRepairPointsCostReduction.Value))
            {
                skills.IntellectRepairPointsCostReduction.PerLevel(Normalize(intellectRepairPointsCostReduction.Value));
            }
        }

        private void SetMemory()
        {
            var skills = Instance.MainPlayer.Skills;

            if (skills.MemoryMentalForget1.PerLevel(Normalize(memoryMentalForget1.Value)) != Normalize(memoryMentalForget1.Value))
            {
                skills.MemoryMentalForget1.PerLevel(Normalize(memoryMentalForget1.Value));
            }

            if (skills.MemoryMentalForget2.PerLevel(Normalize(memoryMentalForget2.Value)) != Normalize(memoryMentalForget2.Value))
            {
                skills.MemoryMentalForget2.PerLevel(Normalize(memoryMentalForget2.Value));
            }
        }

        private void SetPerception()
        {
            var skills = Instance.MainPlayer.Skills;

            if (skills.PerceptionHearing.PerLevel(Normalize(perceptionHearing.Value)) != Normalize(perceptionHearing.Value))
            {
                skills.PerceptionHearing.PerLevel(Normalize(perceptionHearing.Value));
            }

            if (skills.PerceptionLootDot.PerLevel(Normalize(perceptionLootDot.Value)) != Normalize(perceptionLootDot.Value))
            {
                skills.PerceptionLootDot.PerLevel(Normalize(perceptionLootDot.Value));
            }
        }

        

        #endregion
        // Configs

        public void RegisterConfigs()
        {
            string mainSectionElite = "Easy Skill Options - Elite Toggles";
            string sliderSectiono = "Easy Skill Options - Adjust skill values";

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

        public void RegisterSliderConfigs()
        {
            string sliderSection = "Easy Skill Options - Adjust skill values";

            // Perception

            perceptionHearing = Instance.Config.Bind(
               sliderSection,
               "Increases hearing distance per level by a percentage",
               0.00f,
               new ConfigDescription("1 = 1% per level, 100 = 100% per level", new AcceptableValueRange<float>(0f, 100f)));

            perceptionLootDot = Instance.Config.Bind(
               sliderSection,
               "Increases loot dot radius per level by a percentage",
               0.00f,
               new ConfigDescription("1 = 1 % per level, 100 = 100 % per level", new AcceptableValueRange<float>(0f, 100f)));

            //
        }

        private float Normalize(float skill)
        {
            return skill / 100;
        }
    }
}