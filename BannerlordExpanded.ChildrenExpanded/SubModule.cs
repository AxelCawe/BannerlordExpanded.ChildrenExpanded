using BannerlordExpanded.ChildrenExpanded.Settings;
using HarmonyLib;
using System.Reflection;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;


namespace BannerlordExpanded.ChildrenExpanded
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();

        }

        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();

        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            Harmony.DEBUG = true;
            base.OnBeforeInitialModuleScreenSetAsRoot();
            new Harmony("BannerlordExpanded.ChildrenExpanded").PatchAll(Assembly.GetExecutingAssembly());

        }

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);
            CheckSettingsValid();
        }


        void CheckSettingsValid()
        {
            if (Config.Instance.BecomeInfantAge > Config.Instance.BecomeChildAge)
            {
                InformationManager.DisplayMessage(new InformationMessage(new TextObject("{=BE_ChildrenExpanded_Settings_ChildrenLords_Error_01}[BE_ChildrenExpanded]: Mod Settings Error -> Become Infant Age value is greater than Become Child Age value. Mod has auto-patched for Become Child Age to align with Become Infant Age").ToString()));
                Config.Instance.BecomeChildAge = Config.Instance.BecomeInfantAge;
            }

            if (Config.Instance.BecomeChildAge > Config.Instance.BecomeTeenagerAge)
            {
                InformationManager.DisplayMessage(new InformationMessage(new TextObject("{=BE_ChildrenExpanded_Settings_ChildrenLords_Error_02}[BE_ChildrenExpanded]: Mod Settings Error -> Become Child Age value is greater than Become Teenager Age value. Mod has auto-patched for Become Teenager Age to align with Become Child Age").ToString()));
                Config.Instance.BecomeTeenagerAge = Config.Instance.BecomeChildAge;
            }

            if (Config.Instance.BecomeTeenagerAge > Config.Instance.HeroComesOfAge)
            {
                InformationManager.DisplayMessage(new InformationMessage(new TextObject("{=BE_ChildrenExpanded_Settings_ChildrenLords_Error_03}[BE_ChildrenExpanded]: Mod Settings Error -> Become Teenager Age value is greater than Hero Comes Of Age value. Mod has auto-patched for Hero Comes Of Age to align with Become Teenager Age").ToString()));
                Config.Instance.HeroComesOfAge = Config.Instance.BecomeTeenagerAge;
            }
        }
    }
}