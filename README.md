Easy Skill Options by dirtbikercj

Simple mod to either simply increase your leveling rate, or adjust them to your specific liking.

bool = true/false
number = 1, 1.2, 0.00010
integer = 1, 2, 3...

Config:

EnabledMod - Enables or disables mod. (Type: bool)

SimpleLevelingRate - Simple leveling multplier. (2 would be 2x normal rate)                     (Type: Integer)

EnableSkillFatique - Enables or disables skill fatique.                                         (Type: bool)

EnableSkillAtrophy - Enables or disables skill atrophy(skill regression).                       (Type: bool)

EnableAdvancedAdjustments - Enables advanced adjustments, when enabled skilling rates will be based off below numbers and SimpleLevelingRate will no longer do anything. (type: bool)

SkillMinEffectiveness - Minimum ammount of skills gain per action.                              (type: number)

SkillFatiquePerPoint - Skill Fatique added per skill point gained.                              (type: number)

SkillFreshEffectiveness - Skill point gain multiplier while fresh.                              (type: number)

SkillFreshPoints - Ammount of fresh skill points.                                               (type: number)

SkillPointsBeforeFatique - Ammount of skill points gained before skill fatique kicks in .       (type: number)

SkillFatiqueReset - Time before skill fatique resets.                                           (type: number)

SkillExpPerLevel - Ammount of base points needed to gain a level.                               (Type: number)


# EXHAUSTION #

EnableExhaustionChanges - Enables/Disables Exhaustion changes                                   (type: bool)
DefaultDelay - Delay before exhaustion kicks in                                                 (type: integer)                                      
DefaultResidueTime - No fucking idea what this is tbh                                           (Type: integer)
Damage - Damage per tick                                                                        (type: integer)
DamageLoopTime - Time between damage ticks                                                      (type: integer)

# Elite Skills #

EnableEliteSkillChanges - Enables/disables Elite skill changes                                  (type: bool)

If you know the game you know what this shit does, not wasting my time writing what they do. Use google and the wiki.
Some elite skills are handled client side. Ill looking into changing them at a later date, hence why some things might be missing at time of writing.