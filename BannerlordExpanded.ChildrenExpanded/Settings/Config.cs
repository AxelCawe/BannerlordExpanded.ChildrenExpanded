using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace BannerlordExpanded.ChildrenExpanded.Settings
{
    public class Config : AttributeGlobalSettings<Config>
    {
        public override string Id => "BE_ChildrenLords";

        public override string DisplayName => "BE - Children Expanded";
        public override string FolderName => "BannerlordExpanded.ChildrenLords";
        public override string FormatType => "xml";

        [SettingPropertyBool("{=BE_ChildrenExpanded_Settings_ChildrenLords}Children Lords", IsToggle = true, RequireRestart = false)]
        [SettingPropertyGroup("{=BE_ChildrenExpanded_Settings_ChildrenLords}Children Lords", GroupOrder = 0)]
        public bool ChildrenLordsActive { get; set; } = true;

        [SettingPropertyInteger("{=BE_ChildrenExpanded_Settings_InfantAge}Become Infant Age", 1, 125, "0 Years", RequireRestart = false, Order = 2,
            HintText = "{=BE_ChildrenExpanded_Settings_InfantAge_Desc}Native: 3. Must be less than Become Child Age.")]
        [SettingPropertyGroup("{=BE_ChildrenExpanded_Settings_ChildrenLords}Children Lords", GroupOrder = 0)]
        public int BecomeInfantAge { get; set; } = 1;

        [SettingPropertyInteger("{=BE_ChildrenExpanded_Settings_ChildAge}Become Child Age", 1, 125, "0 Years", RequireRestart = false, Order = 3,
            HintText = "{=BE_ChildrenExpanded_Settings_ChildAge_Desc}Native: 6. Must be less than Become Teenager Age.")]
        [SettingPropertyGroup("{=BE_ChildrenExpanded_Settings_ChildrenLords}Children Lords", GroupOrder = 0)]
        public int BecomeChildAge { get; set; } = 3;

        [SettingPropertyInteger("{=BE_ChildrenExpanded_Settings_TeenagerAge}Become Teenager Age", 1, 125, "0 Years", RequireRestart = false, Order = 4,
            HintText = "{=BE_ChildrenExpanded_Settings_TeenagerAge_Desc}Native: 14. Must be less than Hero Comes Of Age.")]
        [SettingPropertyGroup("{=BE_ChildrenExpanded_Settings_ChildrenLords}Children Lords", GroupOrder = 0)]
        public int BecomeTeenagerAge { get; set; } = 6;

        [SettingPropertyInteger("{=BE_ChildrenExpanded_Settings_AdultAge}Hero Comes Of Age", 1, 125, "0 Years", RequireRestart = false, Order = 5,
            HintText = "{=BE_ChildrenExpanded_Settings_AdultAge_Desc}Native: 18. Must be less than Become Old Age.")]
        [SettingPropertyGroup("{=BE_ChildrenExpanded_Settings_ChildrenLords}Children Lords", GroupOrder = 0)]
        public int HeroComesOfAge { get; set; } = 10;

        [SettingPropertyInteger("{=BE_ChildrenExpanded_Settings_MarriageAge}Minimum Age For Marriage", 1, 125, "0 Years", RequireRestart = false, Order = 6,
        HintText = "{=BE_ChildrenExpanded_Settings_MarriageAge_Desc}Native: 18.")]
        [SettingPropertyGroup("{=BE_ChildrenExpanded_Settings_ChildrenLords}Children Lords", GroupOrder = 0)]
        public int MinAgeForMarriage { get; set; } = 10;

        [SettingPropertyBool("{=BE_ChildrenExpanded_Settings_CanExecuteChildren}Can Execute Children", RequireRestart = true, Order = 7,
        HintText = "{=BE_ChildrenExpanded_Settings_CanExecuteChildren_Desc}Native: False")]
        [SettingPropertyGroup("{=BE_ChildrenExpanded_Settings_ChildrenLords}Children Lords", GroupOrder = 0)]
        public bool CanExecuteChildren { get; set; } = true;


        [SettingPropertyGroup("{=BE_ChildrenExpanded_Settings_BanditChildren}Bandit Children", GroupOrder = 1)]
        [SettingPropertyBool("{=BE_ChildrenExpanded_Settings_BanditChildren}Bandit Children", IsToggle = true, RequireRestart = false)]
        public bool BanditChildrenActive { get; set; } = true;

        [SettingPropertyInteger("{=BE_ChildrenExpanded_Settings_BanditChildren_MinPercent}Minimum Percent Of Children To Add", 0, 100, Order = 0, HintText = "{=BE_ChildrenExpanded_Settings_BanditChildren_MinPercent_Desc}If I have 10 looters, setting it to 50% will result with at least 5 looter children.", RequireRestart = false)]
        [SettingPropertyGroup("{=BE_ChildrenExpanded_Settings_BanditChildren}Bandit Children", GroupOrder = 1)]
        public int MinPercentOfBanditChildrenToAdd { get; set; } = 20;
        [SettingPropertyInteger("{=BE_ChildrenExpanded_Settings_BanditChildren_MaxPercent}Maximum Percent Of Children To Add", 0, 100, Order = 1, HintText = "{=BE_ChildrenExpanded_Settings_BanditChildren_MaxPercent_Desc}If I have 10 looters, setting it to 50% will result with at most 5 looter children.", RequireRestart = false)]
        [SettingPropertyGroup("{=BE_ChildrenExpanded_Settings_BanditChildren}Bandit Children", GroupOrder = 1)]
        public int MaxPercentOfBanditChildrenToAdd { get; set; } = 20;


        [SettingPropertyBool("{=BE_ChildrenExpanded_Settings_MiscTweaks_PartyLimitEnabled}Enable Custom Party Limit", RequireRestart = true, Order = 1,
        HintText = "{=BE_ChildrenExpanded_Settings_MiscTweaks_PartyLimitEnabled_Desc}Whether to enable to adjust the limit for the amount of parties each clan can have.", IsToggle = true)]
        [SettingPropertyGroup("{=BE_ChildrenExpanded_Settings_MiscTweaks}Misc. Tweaks/{=BE_ChildrenExpanded_Settings_MiscTweaks_PartyLimit}Clan Party Limit", GroupOrder = 2)]
        public bool CustomPartyLimitForTierEnabled { get; set; } = false;
        [SettingPropertyInteger("{=BE_ChildrenExpanded_Settings_MiscTweaks_PartyLimitMultiplier}Limit Multiplier", 0, 100, Order = 2, HintText = "{=BE_ChildrenExpanded_Settings_MiscTweaks_PartyLimitMultiplier_Desc}Multiplies vanilla game's limit by this amount.", RequireRestart = false)]
        [SettingPropertyGroup("{=BE_ChildrenExpanded_Settings_MiscTweaks}Misc. Tweaks/{=BE_ChildrenExpanded_Settings_MiscTweaks_PartyLimit}Clan Party Limit", GroupOrder = 2)]
        public float CustomPartyLimitForTierMultiplier { get; set; } = 2;
    }
}
