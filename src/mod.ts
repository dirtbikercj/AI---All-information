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
            
            database.globals.config.SkillFreshEffectiveness = skillFreshEffectiveness * this.modConfig.SimpleLevelingRate;      // Progression while fresh multiplier
            database.globals.config.SkillFreshPoints = skillFreshPoints * this.modConfig.SimpleLevelingRate;                    // Amount of fresh skill points
            database.globals.config.SkillMinEffectiveness = skillMinEffectiveness * this.modConfig.SimpleLevelingRate;          // Minimum skill point multiplier
           
            this.logger.logWithColor(`EasyLevelingOptions: Simple rate Enabled. Multiplier = ${this.modConfig.SimpleLevelingRate}`, LogTextColor.GREEN)
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
    }
}

module.exports = { mod: new DEasyLevelingOptions() }