
using System.Globalization;
using HarmonyLib;
using Sentry;
using UnityEngine;
using static TownOfHost.Translator;

namespace TownOfHost
{
    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    class PingTrackerUpdatePatch
    {
        static void Postfix(PingTracker __instance)
        {
            __instance.text.alignment = TMPro.TextAlignmentOptions.TopRight;
            __instance.text.text += Main.credentialsText;
            if (Options.NoGameEnd.GetBool()) __instance.text.text += $"\r\n" + Utils.ColorString(Color.red, GetString("NoGameEnd"));
            if (Options.IsStandardHAS) __instance.text.text += $"\r\n" + Utils.ColorString(Color.yellow, GetString("StandardHAS"));
            if (Options.CurrentGameMode == CustomGameMode.HideAndSeek) __instance.text.text += $"\r\n" + Utils.ColorString(Color.red, GetString("HideAndSeek"));
            if (!GameStates.IsModHost) __instance.text.text += $"\r\n" + Utils.ColorString(Color.red, GetString("Warning.NoModHost"));
            if (DebugModeManager.IsDebugMode) __instance.text.text += "\r\n" + Utils.ColorString(Color.green, "デバッグモード");

            var offset_x = 1.2f; //右端からのオフセット
            if (HudManager.InstanceExists && HudManager._instance.Chat.ChatButton.active) offset_x += 0.8f; //チャットボタンがある場合の追加オフセット
            if (FriendsListManager.InstanceExists && FriendsListManager._instance.FriendsListButton.Button.active) offset_x += 0.8f; //フレンドリストボタンがある場合の追加オフセット
            __instance.GetComponent<AspectPosition>().DistanceFromEdge = new Vector3(offset_x, 0f, 0f);
        /*
#if DEBUG
            __instance.text.text += $"\n({PlayerControl.LocalPlayer.transform.position.x},{PlayerControl.LocalPlayer.transform.position.y},{PlayerControl.LocalPlayer.transform.position.z})";
#endif
       */
            if (!GameStates.IsLobby) return;
            if (Options.IsStandardHAS && !CustomRoles.Sheriff.IsEnable() && !CustomRoles.SerialKiller.IsEnable() && CustomRoles.Egoist.IsEnable())
                __instance.text.text += $"\r\n" + Utils.ColorString(Color.red, GetString("Warning.EgoistCannotWin"));

        }
    }
    [HarmonyPatch(typeof(VersionShower), nameof(VersionShower.Start))]
    class VersionShowerStartPatch
    {
        static TMPro.TextMeshPro SpecialEventText;
        public static string Authors = Utils.ColorString(Color.yellow, GetString("Author"));
        public static string Developers = Utils.ColorString(Color.blue, GetString("Developers"));
        public static string Sansai = Utils.ColorString(Color.green, GetString("sansai"));
        public static string GKT = Utils.ColorString(Palette.Orange, GetString("GKT"));
        public static string NemuA = Utils.ColorString(Color.red, GetString("NemuA"));
        public static string Haron = "<color=#00fa9a>" + GetString("haron") + "</color>";
        static void Postfix(VersionShower __instance)
        {
            Main.credentialsText = $"\r\n<color={Main.ModColor}>{Main.ModName}</color> v{Main.PluginVersion}";
#if DEBUG
            //Main.credentialsText += $"\r\n<color={Main.ModColor}>{ThisAssembly.Git.Branch}({ThisAssembly.Git.Commit})</color>";
#endif
            var credentials = Object.Instantiate(__instance.text);
            credentials.text = Main.credentialsText;
            credentials.alignment = TMPro.TextAlignmentOptions.TopRight;
            credentials.transform.position = new Vector3(4.6f, 3.2f, 0);

            ErrorText.Create(__instance.text);
            if (Main.hasArgumentException && ErrorText.Instance != null)
            {
                ErrorText.Instance.AddError(ErrorCode.Main_DictionaryError);
            }

            if (SpecialEventText == null)
            {
                SpecialEventText = Object.Instantiate(__instance.text);
                SpecialEventText.text = "";
                SpecialEventText.color = Color.white;
                SpecialEventText.fontSize += 2.5f;
                SpecialEventText.alignment = TMPro.TextAlignmentOptions.Top;
                SpecialEventText.transform.position = new Vector3(0, 0.5f, 0);
            }
            SpecialEventText.enabled = TitleLogoPatch.amongUsLogo != null;
            if (Main.IsInitialRelease)
            {
                SpecialEventText.text = $"Happy Birthday to {Main.ModName}!";
                ColorUtility.TryParseHtmlString(Main.ModColor, out var col);
                SpecialEventText.color = col;
            }
            if (Main.IsChristmas && CultureInfo.CurrentCulture.Name == "ja-JP")
            {
                //このソースコ―ドを見た人へ。口外しないでもらえると嬉しいです...
                //To anyone who has seen this source code. I would appreciate it if you would keep your mouth shut...
                SpecialEventText.text = "何とは言いませんが、特別な日ですね。\n<size=15%>\n\n末永く爆発しろ</size>";
                SpecialEventText.color = Utils.GetRoleColor(CustomRoles.Lovers);
            }



            var amongUsLogo = GameObject.Find("bannerLogo_AmongUs");
            if (amongUsLogo == null) return;
            var langId = TranslationController.InstanceExists ? TranslationController.Instance.currentLanguage.languageID : SupportedLangs.English;
            /*=============製作者の名前=====================*/
            var credentials_2 = UnityEngine.Object.Instantiate<TMPro.TextMeshPro>(__instance.text);
            credentials_2.transform.position = new Vector3(0, 334f, 0);
            string credentialsText = "";
            credentialsText += "";
            credentials_2.SetText(credentialsText);

            credentials_2.alignment = TMPro.TextAlignmentOptions.Center;
            credentials_2.fontSize *= 0.9f;

            var RHRName = UnityEngine.Object.Instantiate(credentials_2);
            RHRName.transform.position = new Vector3(0, -0.2f, 0);
            RHRName.SetText(string.Format($"{(langId != SupportedLangs.Japanese ? "<size=125%>" : "<size=100%>")}" + Authors + " : " + Sansai + "\n" + Developers + " : " + Sansai + " " + Haron + " " + GKT + " " + NemuA + "</size>"));

            credentials.transform.SetParent(amongUsLogo.transform);
            RHRName.transform.SetParent(amongUsLogo.transform);
            /*=============製作者の名前=====================*/

        }
    }

    [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
    class TitleLogoPatch
    {
        public static GameObject amongUsLogo;
        static void Postfix(MainMenuManager __instance)
        {
            if ((amongUsLogo = GameObject.Find("bannerLogo_AmongUs")) != null)
            {
                amongUsLogo.transform.localScale *= 0.4f;
                amongUsLogo.transform.position += Vector3.up * 0.25f;
            }

            var tohLogo = new GameObject("titleLogo_TOH");
            tohLogo.transform.position = Vector3.up;
            tohLogo.transform.localScale *= 1.2f;
            var renderer = tohLogo.AddComponent<SpriteRenderer>();
            renderer.sprite = Utils.LoadSprite("TownOfHost.Resources.RHRlogo.png", 300f);
        }

    }
    [HarmonyPatch(typeof(ModManager), nameof(ModManager.LateUpdate))]
    class ModManagerLateUpdatePatch
    {
        public static void Prefix(ModManager __instance)
        {
            __instance.ShowModStamp();

            LateTask.Update(Time.deltaTime);
            CheckMurderPatch.Update();
        }
        public static void Postfix(ModManager __instance)
        {
            var offset_y = HudManager.InstanceExists ? 1.6f : 0.9f;
            __instance.ModStamp.transform.position = AspectPosition.ComputeWorldPosition(
                __instance.localCamera, AspectPosition.EdgeAlignments.RightTop,
                new Vector3(0.4f, offset_y, __instance.localCamera.nearClipPlane + 0.1f));
        }
    }
}