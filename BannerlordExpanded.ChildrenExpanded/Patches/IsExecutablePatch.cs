using BannerlordExpanded.ChildrenExpanded.Settings;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.Party;

namespace BannerlordExpanded.ChildrenExpanded.Patches
{
    [HarmonyPatch(typeof(PartyScreenLogic), "IsExecutable")]
    public static class IsExecutablePatch
    {
        static void Postfix(ref bool __result, ref PartyScreenLogic.TroopType troopType, ref CharacterObject character, ref PartyScreenLogic.PartyRosterSide side)
        {
            if (Config.Instance.ChildrenLordsActive && Config.Instance.CanExecuteChildren && __result == false)
            {
                __result = troopType == PartyScreenLogic.TroopType.Prisoner
                           && side == PartyScreenLogic.PartyRosterSide.Right
                           && character.IsHero
                           && character.HeroObject.Age >= (float)Campaign.Current.Models.AgeModel.HeroComesOfAge
                           && (PlayerEncounter.Current == null || PlayerEncounter.Current.EncounterState == PlayerEncounterState.Begin);
            }
        }
    }
}
