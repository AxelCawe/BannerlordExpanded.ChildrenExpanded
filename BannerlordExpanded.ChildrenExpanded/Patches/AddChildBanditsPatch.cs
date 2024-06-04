using BannerlordExpanded.ChildrenExpanded.Settings;
using HarmonyLib;
using MCM.Abstractions.Base.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Library;

namespace Some_Bandits_Are_Now_Children.Patches
{
    [HarmonyPatch(typeof(MobileParty), "FillPartyStacks")]
    public static class AddChildBanditsPatch
    {
        [HarmonyPostfix]
        static void PostFix(MobileParty __instance, PartyTemplateObject pt, int troopNumberLimit = -1)
        {
            if (__instance.IsBandit && Config.Instance.BanditChildrenActive)
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

                foreach (TroopRosterElement troop in __instance.MemberRoster.GetTroopRoster())
                {
                    
                    CharacterObject childObject = CharacterObject.Find(troop.Character.StringId + "_children");
                    CharacterObject childFemaleObject = CharacterObject.Find(troop.Character.StringId + "_children_female");

                    float numberPercent = new Random().Next(Config.Instance.MinPercentOfBanditChildrenToAdd, Config.Instance.MaxPercentOfBanditChildrenToAdd + 1);
                    int numToAdd = TaleWorlds.Library.MathF.Floor(numberPercent / 100f * troop.Number);
                    if (childObject != null && childFemaleObject != null) numToAdd /= 2;

                    if (childObject != null) 
                    {
                        __instance.AddElementToMemberRoster(childObject, numToAdd);
                        __instance.MemberRoster.RemoveTroop(troop.Character, numToAdd);
                    }
                        //mobileParty.AddElementToMemberRoster(childObject, MathF.Floor((float)GlobalSettings<MCMSettings>.Instance.minPercentOfChildrenToAdd / 100f * troop.Number)); 
                    if (childFemaleObject != null)
                    {
                        __instance.AddElementToMemberRoster(childFemaleObject, numToAdd);
                        __instance.MemberRoster.RemoveTroop(troop.Character, numToAdd);
                    }
                }
            }
        }
    }
}
