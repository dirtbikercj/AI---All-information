using Aki.Reflection.Patching;
using EFT;
using System.Reflection;


namespace EasySkillOptions.Patches
{
    internal class InstantSearchPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod() =>
                typeof(GameWorld).GetMethod("OnGameStarted", BindingFlags.Public | BindingFlags.Instance);

        [PatchPostfix]
        private static void Postfix(GameWorld __instance)
        {
            var skills = __instance.MainPlayer.Skills;

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
    }
}
