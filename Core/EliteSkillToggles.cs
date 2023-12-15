using BepInEx.Configuration;
using Comfort.Common;
using EFT;
using static EasySkillOptions.Plugin;

namespace EasySkillOptions.Core
{
    internal class EliteSkillToggles
    {
        SkillManager skills;

        #region Config Entires

        public static ConfigEntry<bool> instantSearch;
        public ConfigEntry<bool> instantCrafting;
        public ConfigEntry<bool> unlimtedCrafting;
        public static ConfigEntry<bool> eliteAimDrills;
        public static ConfigEntry<bool> eliteAssault;
        public static ConfigEntry<bool> eliteAttention;
        public static ConfigEntry<bool> eliteCharisma;
        public static ConfigEntry<bool> eliteCrafting;
        public static ConfigEntry<bool> eliteCovert;
        public static ConfigEntry<bool> eliteDMR;
        public static ConfigEntry<bool> eliteEndurance;
        public static ConfigEntry<bool> eliteHealth;
        public static ConfigEntry<bool> eliteHideout;
        public static ConfigEntry<bool> eliteHMG;
        public static ConfigEntry<bool> eliteImmunity;
        public static ConfigEntry<bool> eliteIntellect;
        public static ConfigEntry<bool> eliteLightVests;
        public static ConfigEntry<bool> eliteLMG;
        public static ConfigEntry<bool> eliteMagDrills;
        public static ConfigEntry<bool> eliteMemory;
        public static ConfigEntry<bool> eliteMelee;
        public static ConfigEntry<bool> eliteMetabolism;
        public static ConfigEntry<bool> elitePerception;
        public static ConfigEntry<bool> elitePistol;
        public static ConfigEntry<bool> eliteProne;
        public static ConfigEntry<bool> eliteRecoil;
        public static ConfigEntry<bool> eliteRevolver;
        public static ConfigEntry<bool> eliteSearch;
        public static ConfigEntry<bool> eliteShotgun;
        public static ConfigEntry<bool> eliteSniper;
        public static ConfigEntry<bool> eliteSMG;
        public static ConfigEntry<bool> eliteStrength;
        public static ConfigEntry<bool> eliteStress;
        public static ConfigEntry<bool> eliteSurgery;
        public static ConfigEntry<bool> eliteThrowing;
        public static ConfigEntry<bool> eliteTroubleShooting;
        public static ConfigEntry<bool> eliteVitality;
        public static ConfigEntry<bool> eliteRepair;
        
        #endregion

        #region TOGGLES

        public void SetToggles()
        {
            if (Instance.MainPlayer == null)
            {
                return;
            }

            if (skills == null)
            {
                skills = Instance.MainPlayer.Skills;
            }
            else if (skills == null)
            {
                skills = Singleton<LocalPlayer>.Instance.Skills;
            }
            
            InstantSearch();
            InstantCrafting();
            UnlimitedCrafting();
            EliteAimDrills();
            EliteAssault();
            EliteAttention();
            EliteCharisma();
            EliteCrafting();
            EliteCovert();
            EliteDMR();
            EliteEndurance();
            EliteHealth();
            EliteHideout();
            EliteHMG();
            EliteImmunity();
            EliteIntellect();
            EliteLightVests();
            EliteLMG();
            EliteMagDrills();
            EliteMemory();
            EliteMelee();
            EliteMetabolism();
            ElitePerception();
            ElitePistol();
            EliteProne();
            EliteRecoil();
            EliteRevolver();
            EliteSearch();
            EliteShotgun();
            EliteSniper();
            EliteSMG();
            EliteStrength();
            EliteStress();
            EliteSurgery();
            EliteThrowing();
            EliteTroubleShooting();
            EliteVitality();
            EliteRepair();
        }
       
        private void InstantSearch()
        {
            if (!instantSearch.Value)
            {
                return;
            }

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

        public void InstantCrafting()
        {
            if (!instantCrafting.Value)
            {
                return;
            }

            EliteCrafting(true);
            skills.Settings.Crafting.CraftTimeReductionPerLevel = 100000f;
        }

        private void UnlimitedCrafting()
        {
            if (!unlimtedCrafting.Value && skills.Settings.Crafting.EliteExtraProductions != 1f)
            {
                skills.Settings.Crafting.EliteExtraProductions = 1f;
                return;
            }

            EliteCrafting(true);
            skills.Settings.Crafting.EliteExtraProductions = 10000000000f;
        }

        private void EliteAimDrills()
        {
            if (!eliteAimDrills.Value)
            {
                return;
            }

            if (skills.AimDrills.Level != 51)
            {
                skills.AimDrills.SetLevel(51);
            }
        }

        private void EliteAssault()
        {
            if (!eliteAssault.Value)
            {
                return;
            }

            if (skills.Assault.Level != 51)
            {
                skills.Assault.SetLevel(51);
            }
        }

        private void EliteAttention()
        {
            if (!eliteAttention.Value)
            {
                return;
            }

            if (skills.Attention.Level != 51)
            {
                skills.Attention.SetLevel(51);
            }
        }

        private void EliteCharisma()
        {
            if (!eliteCharisma.Value)
            {
                return;
            }

            if (skills.Charisma.Level != 51)
            {
                skills.Charisma.SetLevel(51);
            }
        }

        private void EliteCrafting(bool bypass = false)
        {
            if (!eliteCrafting.Value || bypass)
            {
                return;
            }

            if (skills.Crafting.Level != 51)
            {
                skills.Crafting.SetLevel(51);
            }
        }

        private void EliteCovert()
        {
            if (!eliteCovert.Value)
            {
                return;
            }

            if (skills.CovertMovement.Level != 51)
            {
                skills.CovertMovement.SetLevel(51);
            }
        }

        private void EliteDMR()
        {
            if (!eliteDMR.Value)
            {
                return;
            }

            if (skills.DMR.Level != 51)
            {
                skills.DMR.SetLevel(51);
            }
        }

        private void EliteEndurance()
        {
            if (!eliteEndurance.Value)
            {
                return;
            }

            if (skills.Endurance.Level != 51)
            {
                skills.Endurance.SetLevel(51);
            }
        }

        private void EliteHealth()
        {
            if (!eliteHealth.Value)
            {
                return;
            }

            if (skills.Health.Level != 51)
            {
                skills.Health.SetLevel(51);
            }
        }

        private void EliteHideout()
        {
            if (!eliteHideout.Value)
            {
                return;
            }

            if (skills.HideoutManagement.Level != 51)
            {
                skills.HideoutManagement.SetLevel(51);
            }
        }

        private void EliteHMG()
        {
            if (!eliteHMG.Value)
            {
                return;
            }

            if (skills.HMG.Level != 51)
            {
                skills.HMG.SetLevel(51);
            }
        }

        private void EliteImmunity()
        {
            if (!eliteImmunity.Value)
            {
                return;
            }

            if (skills.Immunity.Level != 51)
            {
                skills.Immunity.SetLevel(51);
            }
        }

        private void EliteIntellect()
        {
            if (!eliteIntellect.Value)
            {
                return;
            }

            if (skills.Intellect.Level != 51)
            {
                skills.Intellect.SetLevel(51);
            }
        }

        private void EliteLightVests()
        {
            if (!eliteLightVests.Value)
            {
                return;
            }

            if (skills.LightVests.Level != 51)
            {
                skills.LightVests.SetLevel(51);
            }
        }

        private void EliteLMG()
        {
            if (!eliteLMG.Value)
            {
                return;
            }

            if (skills.LMG.Level != 51)
            {
                skills.LMG.SetLevel(51);
            }
        }

        private void EliteMagDrills()
        {
            if (!eliteMagDrills.Value)
            {
                return;
            }

            if (skills.MagDrills.Level != 51)
            {
                skills.MagDrills.SetLevel(51);
            }
        }

        private void EliteMemory()
        {
            if (!eliteMemory.Value)
            {
                return;
            }

            if (skills.Memory.Level != 51)
            {
                skills.Memory.SetLevel(51);
            }
        }

        private void EliteMelee()
        {
            if (!eliteMelee.Value)
            {
                return;
            }

            if (skills.Melee.Level != 51)
            {
                skills.Melee.SetLevel(51);
            }
        }

        private void EliteMetabolism()
        {
            if (!eliteMetabolism.Value)
            {
                return;
            }

            if (skills.Metabolism.Level != 51)
            {
                skills.Metabolism.SetLevel(51);
            }
        }

        private void ElitePerception()
        {
            if (!elitePerception.Value)
            {
                return;
            }

            if (skills.Perception.Level != 51)
            {
                skills.Perception.SetLevel(51);
            }
        }

        private void ElitePistol()
        {
            if (!elitePistol.Value)
            {
                return;
            }

            if (skills.Pistol.Level != 51)
            {
                skills.Pistol.SetLevel(51);
            }
        }

        private void EliteProne()
        {
            if (!eliteProne.Value)
            {
                return;
            }

            if (skills.ProneMovement.Level != 51)
            {
                skills.ProneMovement.SetLevel(51);
            }
        }

        private void EliteRecoil()
        {
            if (!eliteRecoil.Value)
            {
                return;
            }

            if (skills.RecoilControl.Level != 51)
            {
                skills.RecoilControl.SetLevel(51);
            }
        }

        private void EliteRevolver()
        {
            if (!eliteRevolver.Value)
            {
                return;
            }

            if (skills.Revolver.Level != 51)
            {
                skills.Revolver.SetLevel(51);
            }
        }

        private void EliteSearch()
        {
            if (!eliteSearch.Value)
            {
                return;
            }

            if (skills.Search.Level != 51)
            {
                skills.Search.SetLevel(51);
            }
        }

        private void EliteShotgun()
        {
            if (!eliteShotgun.Value)
            {
                return;
            }

            if (skills.Shotgun.Level != 51)
            {
                skills.Shotgun.SetLevel(51);
            }
        }

        private void EliteSniper()
        {
            if (!eliteSniper.Value)
            {
                return;
            }

            if (skills.Sniper.Level != 51)
            {
                skills.Sniper.SetLevel(51);
            }
        }

        private void EliteSMG()
        {
            if (!eliteSMG.Value)
            {
                return;
            }

            if (skills.SMG.Level != 51)
            {
                skills.SMG.SetLevel(51);
            }
        }

        private void EliteStrength()
        {
            if (!eliteStrength.Value)
            {
                return;
            }

            if (skills.Strength.Level != 51)
            {
                skills.Strength.SetLevel(51);
            }
        }

        private void EliteStress()
        {
            if (!eliteStress.Value)
            {
                return;
            }

            if (skills.StressResistance.Level != 51)
            {
                skills.StressResistance.SetLevel(51);
            }
        }

        private void EliteSurgery()
        {
            if (!eliteSurgery.Value)
            {
                return;
            }

            if (skills.Surgery.Level != 51)
            {
                skills.Surgery.SetLevel(51);
            }
        }

        private void EliteThrowing()
        {
            if (!eliteThrowing.Value)
            {
                return;
            }

            if (skills.Throwing.Level != 51)
            {
                skills.Throwing.SetLevel(51);
            }
        }

        private void EliteTroubleShooting()
        {
            if (!eliteTroubleShooting.Value)
            {
                return;
            }

            if (skills.TroubleShooting.Level != 51)
            {
                skills.TroubleShooting.SetLevel(51);
            }
        }

        private void EliteVitality()
        {
            if (!eliteVitality.Value)
            {
                return;
            }

            if (skills.Vitality.Level != 51)
            {
                skills.Vitality.SetLevel(51);
            }
        }

        private void EliteRepair()
        {
            if (!eliteRepair.Value)
            {
                return;
            }

            if (skills.WeaponTreatment.Level != 51)
            {
                skills.WeaponTreatment.SetLevel(51);
            }
        }

        #endregion

        public void RegisterConfig()
        {
            string mainSectionElite = "Easy Skill Options - Elite Toggles";

            instantSearch = Instance.Config.Bind(
               "General",
               "Instant Search",
               false,
               "Instantly search containers");

            instantCrafting = Instance.Config.Bind(
               "Crafting",
               "Instant Crafting",
               false,
               "Instantly craft in the hideout (this will raise your crafting skill to elite permanantly.)");

            unlimtedCrafting = Instance.Config.Bind(
               "Crafting",
               "Unlimted Crafting",
               false,
               "Unlimited crafts in the hideout (this will raise your crafting skill to elite permanantly.)");

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

            eliteCrafting = Instance.Config.Bind(
               mainSectionElite,
               "Toggle Elite Crafting",
               false,
               "Enables elite Crafting");

            eliteCovert = Instance.Config.Bind(
               mainSectionElite,
               "Toggle Elite Covert movement",
               false,
               "Enables elite Covert movement");

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

            eliteHideout = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Hideout management",
              false,
              "Enables Hideout management");

            eliteHMG = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite HMGs",
              false,
              "Enables elite HMGs");

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

            eliteLMG = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite LMGs",
              false,
              "Enables elite LMGs");

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

            eliteMelee = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Melee",
              false,
              "Enables elite Melee");

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

            eliteProne = Instance.Config.Bind(
               mainSectionElite,
               "Toggle Elite Prone movement",
               false,
               "Enables elite Prone movement");

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

            eliteSMG = Instance.Config.Bind(
               mainSectionElite,
               "Toggle Elite SMGs",
               false,
               "Enables elite SMGs");

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

            eliteRepair = Instance.Config.Bind(
              mainSectionElite,
              "Toggle Elite Weapon Maintenance",
              false,
              "Enables elite Weapon Maintenance");
        }
    }
}