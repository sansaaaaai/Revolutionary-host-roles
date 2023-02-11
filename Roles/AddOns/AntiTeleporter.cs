using System.Collections.Generic;
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
            }
        }
      
    }
}