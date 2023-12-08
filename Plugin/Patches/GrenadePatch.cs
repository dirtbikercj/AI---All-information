using Aki.Reflection.Patching;
using Comfort.Common;
using EFT;
using System;
using System.Linq;
using System.Reflection;

namespace EasySkillOptions.Patches
{
    internal class GrenadePatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return typeof(Player).GetMethods().First(m =>
                m.Name == "SetInHands" && m.GetParameters()[0].Name == "throwWeap");
        }

        [PatchPrefix]
        private static bool Prefix(Player __instance, GrenadeClass throwWeap)
        {
            if (Plugin.Instance.MainPlayer != null && Plugin.QuickGrenade.Value)
            {
                __instance.SetInHandsForQuickUse(throwWeap, null);
            }
            return !Plugin.QuickGrenade.Value;
        }
    }
}
