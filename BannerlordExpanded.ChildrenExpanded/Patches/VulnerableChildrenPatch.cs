using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace BannerlordExpanded.ChildrenExpanded.Patches
{
    [HarmonyPatch(typeof(Agent), "EquipItemsFromSpawnEquipment", typeof(bool), typeof(bool), typeof(bool), typeof(int))]
    public static class VulnerableChildrenPatch
    {
        [HarmonyPostfix]
        public static void Postfix(Agent __instance)
        {
            if (__instance.IsHuman && __instance.Age < 18f)
                DisableInvulnerability(__instance);
        }

        internal static void DisableInvulnerability(Agent agent)
        {
            if (agent.IsHuman && agent.Age < 18f)
            {
                float age = agent.Age;
                float scale = agent.AgentScale;
                agent.Age = 18f;
                //AccessTools.PropertySetter(typeof(Agent), nameof(Agent.Age)).Invoke(agent, new object[] { 18f });

                SkinGenerationParams skinParams = GenerateSkinGenParams(agent);
                agent.AgentVisuals.AddSkinMeshes(skinParams, agent.BodyPropertiesValue, true, agent.Character != null && agent.Character.FaceMeshCache);
                AccessTools.Method(typeof(Agent), "SetInitialAgentScale").Invoke(agent, new object[] { scale });
                //AccessTools.PropertySetter(typeof(Agent), nameof(Agent.Age)).Invoke(agent, new object[] { age });
                agent.Age = age;
            }
        }
        internal static SkinGenerationParams GenerateSkinGenParams(Agent agent)
        {
            return new SkinGenerationParams((int)SkinMask.NoneVisible, agent.SpawnEquipment.GetUnderwearType(agent.IsFemale && agent.Age >= 14),
                    (int)agent.SpawnEquipment.BodyMeshType, (int)agent.SpawnEquipment.HairCoverType, (int)agent.SpawnEquipment.BeardCoverType,
                    (int)agent.SpawnEquipment.BodyDeformType, agent == Agent.Main, agent.Character.FaceDirtAmount, agent.IsFemale ? 1 : 0,
                    agent.Character.Race, false, false, 0);
        }
    }
}
