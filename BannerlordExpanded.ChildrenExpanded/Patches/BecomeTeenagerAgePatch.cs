using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BannerlordExpanded.ChildrenExpanded.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.GameComponents;

namespace BannerlordExpanded.ChildrenExpanded.Patches
{
    [HarmonyPatch(typeof(DefaultAgeModel), "get_BecomeTeenagerAge")]
    public static class BecomeTeenagerAgePatch
    {
        static void Postfix(ref int __result)
        {
            if (Config.Instance.ChildrenLordsActive)
                __result = Config.Instance.BecomeTeenagerAge;
        }
    }
}
