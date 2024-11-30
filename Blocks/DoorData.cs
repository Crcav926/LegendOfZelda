using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class DoorData
    {
        public static Dictionary<int, String> DoorPlacement = new Dictionary<int, String>()
    {
        // 0 = left, 1 = right, 3 = down, 2 = up
        { 0, "LeftDoorOpen"},
        { 1, "RightDoorOpen"},
        { 3, "DownDoorOpen"},
        { 2, "UpDoorOpen"}
    };
        public static Dictionary<int, String> WallPlacement = new Dictionary<int, String>()
    {
        // 0 = left, 1 = right, 2 = down, 3 = up
        { 0, "LeftDoorWall"},
        { 1, "RightDoorWall"},
        { 3, "DownDoorWall"},
        { 2, "UpDoorWall"}
    };

        public static String GetDoorPlacement(int spriteValue)
        {
            return DoorPlacement[spriteValue];
        }
        public static String GetWallPlacement(int spriteValue)
        {
            return WallPlacement[spriteValue];
        }
    }
}
