using System.Collections.Generic;
using HarmonyLib;
using Hazel;
using UnityEngine;
using static TownOfHost.Options;

namespace TownOfHost
{
    public static class Reloader
    {
        private static readonly int Id = 300000;
        public static List<byte> playerIdList = new();

        private static OptionItem AfterReloadKillCool;
        public static OptionItem ReloadCoolDown;
        private static OptionItem CanReloadCount;
        public static Dictionary<byte, int> ReloadCount = new();


        public static void SetupCustomOption()
        {
            SetupRoleOptions(Id, TabGroup.ImpostorRoles, CustomRoles.Reloader);
            ReloadCoolDown = FloatOptionItem.Create(Id + 10, "Cooldown", new(10f, 60f, 2.5f), 50f, TabGroup.ImpostorRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Reloader]).SetValueFormat(OptionFormat.Seconds);
            CanReloadCount = IntegerOptionItem.Create(Id + 11, "CanReloadCount", new(0, 10, 1), 2, TabGroup.ImpostorRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Reloader]).SetValueFormat(OptionFormat.Times);
            AfterReloadKillCool = FloatOptionItem.Create(Id + 12, "AfterReloadKillCool", new(0f, 60f, 2.5f), 5f, TabGroup.ImpostorRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Reloader]).SetValueFormat(OptionFormat.Seconds);
        }
        public static void Init()
        {
            playerIdList = new();
            ReloadCount = new();
        }
        public static void Add(byte playerId)
        {
            playerIdList.Add(playerId);
            ReloadCount.Add(playerId, CanReloadCount.GetInt());
            if (AmongUsClient.Instance.AmHost) SendRPC(playerId);
        }
        public static bool IsEnable() => playerIdList.Count > 0;
        public static void SendRPC(byte playerid)
        {
            MessageWriter writer;
            writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetReloadCount, SendOption.Reliable, -1);
            writer.Write(playerid);
            writer.Write(ReloadCount[playerid]);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }
        public static void ReceiveRPC(MessageReader reader)
        {
            byte playerId = reader.ReadByte();
            int ReloadCo = reader.ReadInt32();
            if (!ReloadCount.ContainsKey(playerId)) ReloadCount.Add(playerId, CanReloadCount.GetInt());
            else ReloadCount[playerId] = ReloadCo;//既にKeyにplayeridが含まれてたら減らした段階の現在のReloadCountを送る
        }
        public static string SetMark(byte playerid)
        {
            return ReloadCount[playerid] > 0 ? Utils.ColorString(Utils.GetRoleColor(CustomRoles.Impostor), "(" + ReloadCount[playerid] + ")") : "";
        }
        public static void UseShapeShift(PlayerControl player)
        {
            if (ReloadCount[player.PlayerId] > 0)
            {
                ReloadCount[player.PlayerId]--;
                SendRPC(player.PlayerId);
                player.SetKillCooldown(AfterReloadKillCool.GetFloat() + 0.01f);//キルクール0のの際普通だとキルできないため
            }
        }
    }
    public static class Tricker
    {
        private static readonly int Id = 320000;
        public static List<byte> playerIdList = new();

        public static OptionItem TrickCoolDown;
        private static OptionItem CanTrickCount;
        public static Dictionary<byte, int> TrickCount = new();
        public static Dictionary<byte, bool> willTrick = new();

        public static void SetupCustomOption()
        {
            SetupRoleOptions(Id, TabGroup.ImpostorRoles, CustomRoles.Tricker);
            TrickCoolDown = FloatOptionItem.Create(Id + 10, "Cooldown", new(10f, 60f, 2.5f), 50f, TabGroup.ImpostorRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Tricker]).SetValueFormat(OptionFormat.Seconds);
            CanTrickCount = IntegerOptionItem.Create(Id + 11, "CanTrickCount", new(0, 10, 1), 2, TabGroup.ImpostorRoles, false).SetParent(CustomRoleSpawnChances[CustomRoles.Tricker]).SetValueFormat(OptionFormat.Times);
        }
        public static void Init()
        {
            playerIdList = new();
            TrickCount = new();
            willTrick = new();
        }
        public static void Add(byte playerId)
        {
            playerIdList.Add(playerId);
            TrickCount.Add(playerId, CanTrickCount.GetInt());
            willTrick.Add(playerId, false);
            if (AmongUsClient.Instance.AmHost) SendRPC(playerId);
        }
        public static bool IsEnable() => playerIdList.Count > 0;
        public static void SendRPC(byte playerid)
        {
            MessageWriter writer;
            writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetTrickCount, SendOption.Reliable, -1);
            writer.Write(playerid);
            writer.Write(TrickCount[playerid]);
            writer.Write(willTrick[playerid]);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }
        public static void ReceiveRPC(MessageReader reader)
        {
            byte playerId = reader.ReadByte();
            int ReloadCo = reader.ReadInt32();
            bool IsWill = reader.ReadBoolean();
            if (!TrickCount.ContainsKey(playerId)) TrickCount.Add(playerId, CanTrickCount.GetInt());
            else TrickCount[playerId] = ReloadCo;//既にKeyにplayeridが含まれてたら減らした段階の現在のTrickCountを送る
            if (!willTrick.ContainsKey(playerId)) willTrick.Add(playerId, false);
            else willTrick[playerId] = IsWill;
        }
        public static string SetMark(byte playerid)
        {
            string CountText = TrickCount[playerid] > 0 ? Utils.ColorString(Utils.GetRoleColor(CustomRoles.Impostor), "(" + TrickCount[playerid] + ")") : "";
            string IsOkText = willTrick[playerid] ? "(On)" : "";
            return CountText + IsOkText;
        }
        public static void UseShapeShift(PlayerControl player)
        {
            if (!willTrick[player.PlayerId])
            {
                if (TrickCount[player.PlayerId] > 0)
                {
                    TrickCount[player.PlayerId]--;
                    willTrick[player.PlayerId] = true;
                    SendRPC(player.PlayerId);//減らして出来るよー状態にする
                }
            }
        }
    }
}