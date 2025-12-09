using BannerlordExpanded.ChildrenExpanded.Settings;
using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;

namespace Some_Bandits_Are_Now_Children.Patches
{
    [HarmonyPatch(typeof(MobileParty), "CreateParty")]
    public static class AddChildBanditsPatch
    {
        [HarmonyPostfix]
        static void PostFix(ref MobileParty __result)
        {
            if (__result.IsBandit && Config.Instance.BanditChildrenActive)
            {
                // Correction
                {
                    if (Config.Instance.MinPercentOfBanditChildrenToAdd > Config.Instance.MaxPercentOfBanditChildrenToAdd)
                    {
                        int temp = Config.Instance.MinPercentOfBanditChildrenToAdd;
                        Config.Instance.MinPercentOfBanditChildrenToAdd = Config.Instance.MaxPercentOfBanditChildrenToAdd;
                        Config.Instance.MaxPercentOfBanditChildrenToAdd = temp;
                    }
                }

                foreach (TroopRosterElement troop in __result.MemberRoster.GetTroopRoster())
                {

                    CharacterObject childObject = CharacterObject.Find(troop.Character.StringId + "_children");
                    CharacterObject childFemaleObject = CharacterObject.Find(troop.Character.StringId + "_children_female");

                    float numberPercent = new Random().Next(Config.Instance.MinPercentOfBanditChildrenToAdd, Config.Instance.MaxPercentOfBanditChildrenToAdd + 1);
                    int numToAdd = TaleWorlds.Library.MathF.Floor(numberPercent / 100f * troop.Number);
                    if (childObject != null && childFemaleObject != null) numToAdd /= 2;
                    if (childObject != null)
                    {
                        __result.AddElementToMemberRoster(childObject, numToAdd);
                        __result.MemberRoster.RemoveTroop(troop.Character, numToAdd);
                    }
                    //mobileParty.AddElementToMemberRoster(childObject, MathF.Floor((float)GlobalSettings<MCMSettings>.Instance.minPercentOfChildrenToAdd / 100f * troop.Number)); 
                    if (childFemaleObject != null)
                    {
                        __result.AddElementToMemberRoster(childFemaleObject, numToAdd);
                        __result.MemberRoster.RemoveTroop(troop.Character, numToAdd);
                    }
                }
            }
        }
    }
}
