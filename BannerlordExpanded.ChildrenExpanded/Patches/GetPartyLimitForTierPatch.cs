using BannerlordExpanded.ChildrenExpanded.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Library;

namespace Some_Bandits_Are_Now_Children.Patches
{
    [HarmonyPatch(typeof(DefaultClanTierModel), "GetPartyLimitForTier")]
    public static class GetPartyLimitForTierPatch
    {
        [HarmonyPostfix]
        static void PostFix(ref int __result, Clan clan, int clanTierToCheck)
        {
            if (Config.Instance.CustomPartyLimitForTierEnabled)
            {
                __result = MathF.Ceiling(__result * Config.Instance.CustomPartyLimitForTierMultiplier);
            }

        }
    }
}
