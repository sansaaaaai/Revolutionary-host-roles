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
        public static bool IsLadderOrNun(Vector2 position)
        {
            /*
 -------------昇降機かいだん---------------
上:(4.542149,14.2624)
下:(4.532301,9.709933)
//xほぼ変化なし
-------------------------------------------
-------------プルプル----------------
右:(9.810959,8.9246)
左:(5.59947,8.9246)
//y変化なし
-------------------------------------------
-----ーーしゃわーかいだん--------
上:(12.87232,-3.351996)
下:(12.87169,-5.755963)
//xほぼ変化なし
 */
            bool IsSyo = 4.3f < position.x && position.x < 4.8f && 9.6f < position.y && position.y < 14.4f;
            bool IsNun = 5.4f < position.x && position.x < 9.9f && 8.8f <= position.y && position.y <= 9.1f;
            bool IsShawa = 12.7f <= position.x && position.x < 13f && -3.2f <= position.y && position.y <= -5.9f;
            return IsSyo || IsNun || IsShawa;
        }
        public static void SetLastPlace()
        {
            if (!AmongUsClient.Instance.AmHost) return;
            foreach (PlayerControl p in PlayerControl.AllPlayerControls)
            {
                Vector2 now = new(p.transform.position.x, p.transform.position.y);

                bool IsSyo = 4.3f < now.x && now.x < 4.8f && 9.6f < now.y && now.y < 14.4f;
                bool IsNun = 5.4f < now.x && now.x < 9.9f && 8.8f <= now.y && now.y <= 9.1f;
                bool IsShawa = 12.7f <= now.x && now.x < 13f && -3.2f <= now.y && now.y <= -5.9f;
                if (p.Is(CustomRoles.AntiTeleporter))
                {
                    if (LastPlace.ContainsKey(p.PlayerId))//Key入ってて
                    {
                        Vector2 Out = new(1, 1);
                        if (!IsLadderOrNun(now))
                        {
                            if (LastPlace[p.PlayerId] != Out)//わいたことあったから
                            {

                                LastPlace[p.PlayerId] = now;
                            }
                        }
                        else
                        {
                            if (IsSyo) LastPlace[p.PlayerId] = new Vector2(4.542149f, 14.2624f);
                            else if (IsNun) LastPlace[p.PlayerId] = new Vector2(9.810959f, 8.9246f);
                            else if (IsShawa) LastPlace[p.PlayerId] = new Vector2(12.87232f, -3.351996f);
                        }
                    }
                    else LastPlace.Add(p.PlayerId, new Vector2(1, 1));//わいたことなかったらそのままLastPlaceのvalueは(1,1)になり、次はそのまま湧いてRandomSpawnPatchによってvalueが登録されます。
                    AntiTeleporter.SendRPC(p.PlayerId);
                }

            }
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