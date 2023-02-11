using System.Collections.Generic;
using Hazel;
using UnityEngine;

namespace TownOfHost
{
    public static class AntiTeleporter
    {
        public static Dictionary<byte, Vector2> LastPlace = new();
        public static void Init()
        {
            LastPlace = new();
        }
        public static void Add(byte id)
        {
            if (AmongUsClient.Instance.AmHost)
            {
                Vector2 v = new(1, 1);
                LastPlace.Add(id, v);
                if (AmongUsClient.Instance.AmHost) SendRPC(id);
            }
        }
        public static void SendRPC(byte playerid)
        {
            MessageWriter writer;
            writer = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, (byte)CustomRPC.SetAntiTeleporterPosition, SendOption.Reliable, -1);
            writer.Write(playerid);
            writer.Write(LastPlace[playerid].x);
            writer.Write(LastPlace[playerid].y);
            AmongUsClient.Instance.FinishRpcImmediately(writer);
        }
        public static void ReceiveRPC(MessageReader reader)
        {
            byte playerId = reader.ReadByte();
            float x = (float)reader.ReadByte();
            float y = (float)reader.ReadByte();
            Vector2 v = new(1, 1);
            if (!LastPlace.ContainsKey(playerId)) LastPlace.Add(playerId, v);
            else
            {
                Vector2 vTwo = new(x, y);
                LastPlace[playerId] = vTwo;
            }
        }

    }
}