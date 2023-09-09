using System;
using System.Linq;
using UnityEngine;
using AmongUs.GameOptions;

using static TownOfHost.Options;

namespace TownOfHost.Roles.Core;

public class SimpleRoleInfo
{
    public Type ClassType;
    public Func<PlayerControl, RoleBase> CreateInstance;
    public CustomRoles RoleName;
    public Func<RoleTypes> BaseRoleType;
    public CustomRoleTypes CustomRoleType;
    public CountTypes CountType;
    public Color RoleColor;
    public string RoleColorCode;
    public int ConfigId;
    public TabGroup Tab;
    public OptionItem RoleOption => CustomRoleSpawnChances[RoleName];
    public bool IsEnable = false;
    public OptionCreatorDelegate OptionCreator;
    public string ChatCommand;
    public bool RequireResetCam;
    private Func<AudioClip> introSound;
    public AudioClip IntroSound => introSound?.Invoke();
    private Func<bool> canMakeMadmate;
    public bool CanMakeMadmate => canMakeMadmate?.Invoke() == true;
    /// <summary>
    /// 人数設定の最小人数, 最大人数, 一単位数
    /// </summary>
    public IntegerValueRule AssignCountRule;
    /// <summary>
    /// 人数設定に対し何人単位でアサインするか
    /// 役職の抽選回数 = 設定人数 / AssignUnitCount
    /// </summary>
    public int AssignUnitCount => AssignCountRule?.Step ?? 1;
    /// <summary>
    /// 実際にアサインされる役職の内訳
    /// </summary>
    public CustomRoles[] AssignUnitRoles;

    private SimpleRoleInfo(
        Type classType,
        Func<PlayerControl, RoleBase> createInstance,
        CustomRoles roleName,
        Func<RoleTypes> baseRoleType,
        CustomRoleTypes customRoleType,
        CountTypes countType,
        int configId,
        OptionCreatorDelegate optionCreator,
        string chatCommand,
        string colorCode,
        bool requireResetCam,
        TabGroup tab,
        Func<AudioClip> introSound,
        Func<bool> canMakeMadmate,
        IntegerValueRule assignCountRule,
        CustomRoles[] assignUnitRoles
    )
    {
        ClassType = classType;
        CreateInstance = createInstance;
        RoleName = roleName;
        BaseRoleType = baseRoleType;
        CustomRoleType = customRoleType;
        CountType = countType;
        ConfigId = configId;
        OptionCreator = optionCreator;
        RequireResetCam = requireResetCam;
        this.introSound = introSound;
        this.canMakeMadmate = canMakeMadmate;
        ChatCommand = chatCommand;
        AssignCountRule = assignCountRule;
        AssignUnitRoles = assignUnitRoles;

        if (colorCode == "")
            colorCode = customRoleType switch
            {
                CustomRoleTypes.Impostor or CustomRoleTypes.Madmate => "#ff1919",
                CustomRoleTypes.Crewmate => "#8cffff",
                _ => "#ffffff"
            };
        RoleColorCode = colorCode;

        _ = ColorUtility.TryParseHtmlString(colorCode, out RoleColor);

        if (tab == TabGroup.MainSettings)
            tab = CustomRoleType switch
            {
                CustomRoleTypes.Impostor => TabGroup.ImpostorRoles,
                CustomRoleTypes.Madmate => TabGroup.ImpostorRoles,
                CustomRoleTypes.Crewmate => TabGroup.CrewmateRoles,
                CustomRoleTypes.Neutral => TabGroup.NeutralRoles,
                _ => tab
            };
        Tab = tab;

        CustomRoleManager.AllRolesInfo.Add(roleName, this);
    }
    public static SimpleRoleInfo Create(
        Type classType,
        Func<PlayerControl, RoleBase> createInstance,
        CustomRoles roleName,
        Func<RoleTypes> baseRoleType,
        CustomRoleTypes customRoleType,
        int configId,
        OptionCreatorDelegate optionCreator,
        string chatCommand,
        string colorCode = "",
        bool requireResetCam = false,
        TabGroup tab = TabGroup.MainSettings,
        Func<AudioClip> introSound = null,
        Func<bool> canMakeMadmate = null,
        CountTypes? countType = null,
        IntegerValueRule assignCountRule = null,
        CustomRoles[] assignUnitRoles = null
    )
    {
        countType ??= customRoleType == CustomRoleTypes.Impostor ?
            CountTypes.Impostor :
            CountTypes.Crew;
        assignCountRule ??= customRoleType == CustomRoleTypes.Impostor ?
            new(1, 3, 1) :
            new(1, 15, 1);
        assignUnitRoles ??= Enumerable.Repeat(roleName, assignCountRule.Step).ToArray();

        return
            new(
                classType,
                createInstance,
                roleName,
                baseRoleType,
                customRoleType,
                countType.Value,
                configId,
                optionCreator,
                chatCommand,
                colorCode,
                requireResetCam,
                tab,
                introSound,
                canMakeMadmate,
                assignCountRule,
                assignUnitRoles
            );
    }
    public static SimpleRoleInfo CreateForVanilla(
        Type classType,
        Func<PlayerControl, RoleBase> createInstance,
        RoleTypes baseRoleType,
        string colorCode = "",
        bool canMakeMadmate = false
    )
    {
        CustomRoles roleName;
        CustomRoleTypes customRoleType;
        CountTypes countType = CountTypes.Crew;

        switch (baseRoleType)
        {
            case RoleTypes.Engineer:
                roleName = CustomRoles.Engineer;
                customRoleType = CustomRoleTypes.Crewmate;
                break;
            case RoleTypes.Scientist:
                roleName = CustomRoles.Scientist;
                customRoleType = CustomRoleTypes.Crewmate;
                break;
            case RoleTypes.GuardianAngel:
                roleName = CustomRoles.GuardianAngel;
                customRoleType = CustomRoleTypes.Crewmate;
                break;
            case RoleTypes.Impostor:
                roleName = CustomRoles.Impostor;
                customRoleType = CustomRoleTypes.Impostor;
                countType = CountTypes.Impostor;
                break;
            case RoleTypes.Shapeshifter:
                roleName = CustomRoles.Shapeshifter;
                customRoleType = CustomRoleTypes.Impostor;
                countType = CountTypes.Impostor;
                break;
            default:
                roleName = CustomRoles.Crewmate;
                customRoleType = CustomRoleTypes.Crewmate;
                break;
        }
        return
            new(
                classType,
                createInstance,
                roleName,
                () => baseRoleType,
                customRoleType,
                countType,
                -1,
                null,
                null,
                colorCode,
                false,
                TabGroup.MainSettings,
                null,
                () => canMakeMadmate,
                new(1, 15, 1),
                new CustomRoles[1] { roleName }
            );
    }
    public delegate void OptionCreatorDelegate();
}