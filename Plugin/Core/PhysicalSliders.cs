using BepInEx.Configuration;
using static EasySkillOptions.Plugin;

namespace EasySkillOptions.Core
{
    internal class PhysicalSliders
    {
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

        public void SetSliderValues()
        {
            if (Instance.MainPlayer == null)
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
