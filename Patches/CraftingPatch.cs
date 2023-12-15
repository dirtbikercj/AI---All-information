using Aki.Reflection.Patching;
using EFT;
using EFT.Hideout;
using EFT.InventoryLogic;
using HarmonyLib;
using System.Linq;
using System.Reflection;

namespace EasySkillOptions.Patches
{
    internal class InstantCraftingPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod() =>
                typeof(GClass1789).GetMethod("GetProducingItem", BindingFlags.Public | BindingFlags.Instance);

        [PatchPostfix]
        private static void Postfix(GClass1789 __instance, ref GClass1788 __result)
        {
            __result = new GClass1788(__instance._id, 0f, 1f);
        }
    }
}
