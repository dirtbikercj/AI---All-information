import { DependencyContainer } from "tsyringe";

import { IPreAkiLoadMod } from "@spt-aki/models/external/IPreAkiLoadMod";
import { ILogger } from "@spt-aki/models/spt/utils/ILogger";
import { IPostDBLoadMod } from "@spt-aki/models/external/IPostDBLoadMod";
import { DatabaseServer } from "@spt-aki/servers/DatabaseServer";
import { IDatabaseTables } from "@spt-aki/models/spt/server/IDatabaseTables";
import { LogTextColor } from "@spt-aki/models/spt/logging/LogTextColor";

class DEasyLevelingOptions implements IPreAkiLoadMod, IPostDBLoadMod
{
    private database: DatabaseServer
    private logger: ILogger
    private mod;
    private modConfig = require("../config/config.json");

    public preAkiLoad(container: DependencyContainer): void
    {
        this.logger = container.resolve<ILogger>("WinstonLogger");
        this.mod = require("../package.json");
    }

    public postDBLoad(container: DependencyContainer): void 
    {
        // Get all in-memory Json
        const database = container.resolve<DatabaseServer>("DatabaseServer").getTables();

        this.adjustRates(database);
    }

    public adjustRates(database: IDatabaseTables): void
    {
        const skillFatiquePerPoint = database.globals.config.SkillFatiguePerPoint;
        const skillFreshEffectiveness = database.globals.config.SkillFreshEffectiveness;
        const skillFreshPoints = database.globals.config.SkillFreshPoints;
        const skillMinEffectiveness = database.globals.config.SkillMinEffectiveness;
        const skillPointsBeforeFatique = database.globals.config.SkillPointsBeforeFatigue;

        const simpleLevelingRate = Math.ceil(this.modConfig.SimpleLevelingRate);

        if (this.modConfig.EnableMod && !this.modConfig.EnableAdvancedAdjustments)
        {
            database.globals.config.SkillAtrophy = this.modConfig.EnableSkillAtrophy;
            
            if (!this.modConfig.EnableSkillFatique)
            {
                database.globals.config.SkillFatiguePerPoint = skillFatiquePerPoint * 0;                                        // Fatique added per point gained
                database.globals.config.SkillFatigueReset = 1;                                                                  // Fatique reset time after last action
                database.globals.config.SkillPointsBeforeFatigue = skillPointsBeforeFatique * 1000;                             // Skill points gained needed to trigger fatique
            
                this.logger.logWithColor("EasyLevelingOptions: Skill Fatique disabled", LogTextColor.GREEN)
            }
            
            database.globals.config.SkillFreshEffectiveness = skillFreshEffectiveness * simpleLevelingRate;      // Progression while fresh multiplier
            database.globals.config.SkillFreshPoints = skillFreshPoints * simpleLevelingRate;                    // Amount of fresh skill points
            database.globals.config.SkillMinEffectiveness = skillMinEffectiveness * simpleLevelingRate;          // Minimum skill point multiplier
           
            this.logger.logWithColor(`EasyLevelingOptions: Simple rate Enabled. Multiplier = ${simpleLevelingRate}`, LogTextColor.GREEN)
        }
        else if (this.modConfig.EnableMod && this.modConfig.EnableAdvancedAdjustments)
        {
            database.globals.config.SkillFatiguePerPoint = this.modConfig.SkillFatiguePerPoint;                                 // Fatique added per point gained
            database.globals.config.SkillFatigueReset = this.modConfig.SkillFatigueReset;                                       // Fatique reset time after last action
            database.globals.config.SkillPointsBeforeFatigue = this.modConfig.SkillPointsBeforeFatigue;                         // Skill points gained needed to trigger fatique
            database.globals.config.SkillExpPerLevel = this.modConfig.SkillExpPerLevel;                                         // Base EXP per level
            database.globals.config.SkillFreshEffectiveness = this.modConfig.SkillFreshEffectiveness;                           // Progression while fresh multiplier
            database.globals.config.SkillFreshPoints = this.modConfig.SkillFreshPoints;                                         // Amount of fresh skill points
            database.globals.config.SkillMinEffectiveness = this.modConfig.SkillMinEffectiveness;                               // Minimum skill point multiplier

            this.logger.logWithColor("EasyLevelingOptions: Advanced adjustments Enabled", LogTextColor.GREEN)
        }
        else
        {
            this.logger.info("EasyLevelingOptions: Status-Disabled");
        }

        if (this.modConfig.EnableEliteSkillChanges)
        {
            //Elite Skills
            database.globals.config.Health.Effects.HeavyBleeding.EliteVitalityDuration = this.modConfig.HeavyBleeding.EliteVitalityDuration;
            database.globals.config.Health.Effects.LightBleeding.EliteVitalityDuration = this.modConfig.LightBleeding.EliteVitalityDuration;
            database.globals.config.SkillsSettings.HideoutManagement.EliteSlots.Generator.Slots = this.modConfig.EliteSlots.Generator.Slots;
            database.globals.config.SkillsSettings.Crafting.EliteExtraProductions = this.modConfig.Crafting.EliteSlots;
            database.globals.config.SkillsSettings.LightVests.WearChanceRepairLVestsReduceEliteLevel = this.modConfig.LightVests.WearChanceRepairLVestsReduceEliteLevel;
            database.globals.config.SkillsSettings.HeavyVests.WearChanceRepairLVestsReduceEliteLevel = this.modConfig.HeavyVests.WearChanceRepairLVestsReduceEliteLevel;
            database.globals.config.SkillsSettings.WeaponTreatment.WearChanceRepairGunsReduceEliteLevel = this.modConfig.WeaponTreatment.WearChanceRepairGunsReduceEliteLevel;
            database.globals.config.SkillsSettings.Intellect.WearChanceReduceEliteLevel = this.modConfig.Intellect.WearChanceReduceEliteLevel;
            database.globals.config.SkillsSettings.Charisma.BonusSettings.EliteBonusSettings.ScavCaseDiscount = this.modConfig.Charisma.ScavCaseDiscount;
            database.globals.config.SkillsSettings.Charisma.BonusSettings.EliteBonusSettings.FenceStandingLossDiscount = this.modConfig.Charisma.FenceStandingLossDiscount;
            database.globals.config.SkillsSettings.Charisma.BonusSettings.EliteBonusSettings.RepeatableQuestExtraCount = this.modConfig.Charisma.RepeatableQuestExtraCount;
            database.globals.config.SkillsSettings.TroubleShooting.EliteDurabilityChanceReduceMult = this.modConfig.TroubleShooting.EliteDurabilityChanceReduceMult;
            database.globals.config.SkillsSettings.TroubleShooting.EliteAmmoChanceReduceMult = this.modConfig.TroubleShooting.EliteAmmoChanceReduceMult;
            database.globals.config.SkillsSettings.TroubleShooting.EliteMagChanceReduceMult = this.modConfig.TroubleShooting.EliteMagChanceReduceMult;

            this.logger.logWithColor("EasyLevelingOptions: Elite Skill adjustments Enabled", LogTextColor.GREEN)
        }

        if (this.modConfig.EnableExhaustionChanges)
        {
            database.globals.config.Health.Effects.Exhaustion.DefaultDelay = this.modConfig.Exhaustion.DefaultDelay;
            database.globals.config.Health.Effects.Exhaustion.DefaultResidueTime = this.modConfig.Exhaustion.DefaultResidueTime;
            database.globals.config.Health.Effects.Exhaustion.Damage = this.modConfig.Exhaustion.Damage;
            database.globals.config.Health.Effects.Exhaustion.DamageLoopTime = this.modConfig.Exhaustion.DamageLoopTime;
            
            this.logger.logWithColor("EasyLevelingOptions: Exhaustion adjustments Enabled", LogTextColor.GREEN)
        }
    }
}

module.exports = { mod: new DEasyLevelingOptions() }