using BannerlordExpanded.ChildrenExpanded.Settings;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using TaleWorlds.CampaignSystem.ViewModelCollection.Party;
using TaleWorlds.Core;

namespace BannerlordExpanded.ChildrenExpanded.Patches
{
    [HarmonyPatch(typeof(PartyCharacterVM), "ExecuteExecuteTroop")]
    public static class ExecuteTroopPatch
    {

        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            if (Config.Instance.CanExecuteChildren)
            {

                MethodInfo ignoreFunc = typeof(FaceGen).GetMethod("GetMaturityTypeWithAge", BindingFlags.Static | BindingFlags.Public);
                MethodInfo trueFunc = typeof(ExecuteTroopPatch).GetMethod("ReturnFalseBody", BindingFlags.Static | BindingFlags.NonPublic);

                foreach (var instruction in instructions)
                {
                    if (instruction.opcode == OpCodes.Call && instruction.Calls(ignoreFunc))
                        yield return new CodeInstruction(OpCodes.Call, trueFunc);
                    else
                        yield return instruction;
                }

            }
        }


        static BodyMeshMaturityType ReturnFalseBody(float age)
        {
            return BodyMeshMaturityType.Adult;
        }
    }

}

