using BepInEx.Configuration;
using static EasySkillOptions.Plugin;

namespace EasySkillOptions.Core
{
    public class EliteSkillToggles
    {
        public static ConfigEntry<bool> instantSearch;
        public static ConfigEntry<bool> eliteAimDrills;
        public static ConfigEntry<bool> eliteAssault;
        public static ConfigEntry<bool> eliteAttention;
        public static ConfigEntry<bool> eliteCharisma;
        public static ConfigEntry<bool> eliteDMR;
        public static ConfigEntry<bool> eliteEndurance;
        public static ConfigEntry<bool> eliteHealth;
        public static ConfigEntry<bool> eliteImmunity;
        public static ConfigEntry<bool> eliteIntellect;
        public static ConfigEntry<bool> eliteLightVests;
        public static ConfigEntry<bool> eliteMagDrills;
        public static ConfigEntry<bool> eliteMemory;
        public static ConfigEntry<bool> eliteMetabolism;
        public static ConfigEntry<bool> elitePerception;
        public static ConfigEntry<bool> elitePistol;
        public static ConfigEntry<bool> eliteRecoil;
        public static ConfigEntry<bool> eliteRevolver;
        public static ConfigEntry<bool> eliteSearch;
        public static ConfigEntry<bool> eliteShotgun;
        public static ConfigEntry<bool> eliteSniper;
        public static ConfigEntry<bool> eliteStrength;
        public static ConfigEntry<bool> eliteStress;
        public static ConfigEntry<bool> eliteSurgery;
        public static ConfigEntry<bool> eliteThrowing;
        public static ConfigEntry<bool> eliteTroubleShooting;
        public static ConfigEntry<bool> eliteVitality;

        #region TOGGLES

        public void SetToggles()
        {
            InstantSearch();
            EliteAimDrills();
            EliteAssault();
            EliteAttention();
            EliteCharisma();
            EliteDMR();
            EliteEndurance();
            EliteHealth();
            EliteImmunity();
            EliteIntellect();
            EliteLightVests();
            EliteMagDrills();
            EliteMemory();
            EliteMetabolism();
            ElitePerception();
            ElitePistol();
            EliteRecoil();
            EliteRevolver();
            EliteSearch();
            EliteShotgun();
            EliteSniper();
            EliteStrength();
            EliteStress();
            EliteSurgery();
            EliteThrowing();
            EliteTroubleShooting();
            EliteVitality();
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

            if (skills.Search.Level != 51)
            {
                skills.Search.SetLevel(51);
            }

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

        private void EliteAimDrills()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteAimDrills.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.AimDrills.Level != 51)
            {
                skills.AimDrills.SetLevel(51);
            }
        }

        private void EliteAssault()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteAssault.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.Assault.Level != 51)
            {
                skills.Assault.SetLevel(51);
            }
        }

        private void EliteAttention()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteAttention.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.Attention.Level != 51)
            {
                skills.Attention.SetLevel(51);
            }
        }

        private void EliteCharisma()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteCharisma.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.Charisma.Level != 51)
            {
                skills.Charisma.SetLevel(51);
            }
        }

        private void EliteDMR()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteDMR.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.DMR.Level != 51)
            {
                skills.DMR.SetLevel(51);
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

            if (skills.Endurance.Level != 51)
            {
                skills.Endurance.SetLevel(51);
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

            if (skills.Health.Level != 51)
            {
                skills.Health.SetLevel(51);
            }
        }

        private void EliteImmunity()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteImmunity.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.Immunity.Level != 51)
            {
                skills.Immunity.SetLevel(51);
            }
        }

        private void EliteIntellect()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteIntellect.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.Intellect.Level != 51)
            {
                skills.Intellect.SetLevel(51);
            }
        }

        private void EliteLightVests()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteLightVests.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.LightVests.Level != 51)
            {
                skills.LightVests.SetLevel(51);
            }
        }
        
        private void EliteMagDrills()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteMagDrills.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.MagDrills.Level != 51)
            {
                skills.MagDrills.SetLevel(51);
            }
        }

        private void EliteMemory()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteMemory.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.Memory.Level != 51)
            {
                skills.Memory.SetLevel(51);
            }
        }

        private void EliteMetabolism()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteMetabolism.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.Metabolism.Level != 51)
            {
                skills.Metabolism.SetLevel(51);
            }
        }

        private void ElitePerception()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!elitePerception.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.Perception.Level != 51)
            {
                skills.Perception.SetLevel(51);
            }
        }

        private void ElitePistol()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!elitePistol.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.Pistol.Level != 51)
            {
                skills.Pistol.SetLevel(51);
            }
        }

        private void EliteRecoil()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteRecoil.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.RecoilControl.Level != 51)
            {
                skills.RecoilControl.SetLevel(51);
            }
        }

        private void EliteRevolver()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteRevolver.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.Revolver.Level != 51)
            {
                skills.Revolver.SetLevel(51);
            }
        }

        private void EliteSearch()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteSearch.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.Search.Level != 51)
            {
                skills.Search.SetLevel(51);
            }
        }

        private void EliteShotgun()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteShotgun.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.Shotgun.Level != 51)
            {
                skills.Shotgun.SetLevel(51);
            }
        }

        private void EliteSniper()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteSniper.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.Sniper.Level != 51)
            {
                skills.Sniper.SetLevel(51);
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

            if (skills.Strength.Level != 51)
            {
                skills.Strength.SetLevel(51);
            }
        }

        private void EliteStress()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteStress.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.StressResistance.Level != 51)
            {
                skills.StressResistance.SetLevel(51);
            }
        }

        private void EliteSurgery()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteSurgery.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.Surgery.Level != 51)
            {
                skills.Surgery.SetLevel(51);
            }
        }

        private void EliteThrowing()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteThrowing.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.Throwing.Level != 51)
            {
                skills.Throwing.SetLevel(51);
            }
        }

        private void EliteTroubleShooting()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteTroubleShooting.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.TroubleShooting.Level != 51)
            {
                skills.TroubleShooting.SetLevel(51);
            }
        }

        private void EliteVitality()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (!eliteVitality.Value)
            {
                return;
            }

            var skills = Instance.MainPlayer.Skills;

            if (skills.Vitality.Level != 51)
            {
                skills.Vitality.SetLevel(51);
            }
        }

        #endregion

        public void RegisterConfig()
        {
            string mainSectionElite = "Easy Skill Options - Elite Toggles";

            instantSearch = Instance.Config.Bind(
               mainSectionElite,
               "Instant Search",
               false,
               "Instantly search containers");

            eliteAimDrills = Instance.Config.Bind(
               mainSectionElite,
               "Toggle Elite AimDrills",
               false,
               "Enables elite AimDrills");

            eliteAssault = Instance.Config.Bind(
               mainSectionElite,
               "Toggle Elite Assault",
               false,
               "Enables elite Assault");

            eliteAttention = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Attention",
              false,
              "Enables elite Attention");

            eliteCharisma = Instance.Config.Bind(
               mainSectionElite,
               "Toggle Elite Charisma",
               false,
               "Enables elite Charisma");

            eliteDMR = Instance.Config.Bind(
               mainSectionElite,
               "Toggle Elite DMR",
               false,
               "Enables elite DMR");

            eliteEndurance = Instance.Config.Bind(
               mainSectionElite,
               "Toggle Elite Endurance",
               false,
               "Enables elite Endurance");

            eliteHealth = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Health",
              false,
              "Enables elite Health");

            eliteImmunity = Instance.Config.Bind(
               mainSectionElite,
               "Toggle Elite Immunity",
               false,
               "Enables elite Immunity");

            eliteIntellect = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Intellect",
              false,
              "Enables elite Intellect");

            eliteLightVests = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Light Vests",
              false,
              "Enables elite Light Vests");

            eliteMagDrills = Instance.Config.Bind(
               mainSectionElite,
               "Toggle Elite MagDrills",
               false,
               "Enables elite MagDrills");

            eliteMemory = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Memory",
              false,
              "Enables elite Memory");

            eliteMetabolism = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Metabolism",
              false,
              "Enables elite Metabolism");

            elitePerception = Instance.Config.Bind(
               mainSectionElite,
               "Toggle Elite Perception",
               false,
               "Enables elite Perception");

            elitePistol = Instance.Config.Bind(
               mainSectionElite,
               "Toggle Elite Pistols",
               false,
               "Enables elite Pistols");

            eliteRecoil = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Recoil Control",
              false,
              "Enables elite Recoil Control");

            eliteRevolver = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Revolvers",
              false,
              "Enables elite Revolvers");

            eliteSearch = Instance.Config.Bind(
               mainSectionElite,
               "Toggle Elite Search",
               false,
               "Enables elite Search (search two containers at once)");

            eliteShotgun = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Shotguns",
              false,
              "Enables elite Shotguns");

            eliteSniper = Instance.Config.Bind(
               mainSectionElite,
               "Toggle Elite Snipers",
               false,
               "Enables elite Snipers");

            eliteStrength = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Strength",
              false,
              "Enables elite Strength");

            eliteStress = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Stress",
              false,
              "Enables elite Stress");

            eliteSurgery = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Surgery",
              false,
              "Enables elite Surgery");

            eliteThrowing = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Throwing",
              false,
              "Enables elite Throwing");

            eliteTroubleShooting = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Troubleshooting",
              false,
              "Enables elite Troubleshooting");

            eliteVitality = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Vitality",
              false,
              "Enables elite Vitality");
        }
    }
}