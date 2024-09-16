using TaleWorlds.Core;

namespace BannerlordExpanded.ChildrenExpanded.Patches
{
    public class ExecuteTroopPatchReplacerMethod
    {
        public static BodyMeshMaturityType ReturnFalseBody(int age)
        {
            return BodyMeshMaturityType.Adult;
        }
    }
}
