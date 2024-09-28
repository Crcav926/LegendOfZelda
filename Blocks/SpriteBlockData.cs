using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace LegendOfZelda
{
    //adapted from SpriteItemData to work for sprites with no animation.
    internal class SpriteBlockData
    {
        public static Rectangle floor = new Rectangle(984, 11, 16, 16);
        public static Rectangle block = new Rectangle(1001, 11, 16, 16);
        public static Rectangle fishStatue = new Rectangle(1018, 11, 16, 16);
        public static Rectangle dragonStatue = new Rectangle(1035, 11, 16, 16);
        public static Rectangle darkVoid = new Rectangle(984, 28, 16, 16);
        public static Rectangle dirt = new Rectangle(1001, 28, 16, 16);
        public static Rectangle water = new Rectangle(1018, 28, 16, 16);
        public static Rectangle staircase = new Rectangle(1035, 28, 16, 16);
        public static Rectangle bricks = new Rectangle(984, 45, 16, 16);
        public static Rectangle ladder = new Rectangle(1001, 45, 16, 16);
        //List of sprites
        public static List<Rectangle> Sprites = new List<Rectangle> { floor, block,
        fishStatue, dragonStatue, darkVoid, dirt, water, staircase, bricks, ladder};
        public static Rectangle GetRectangleData(int spriteValue)
        {
            // return the sprite we need.
            return Sprites[spriteValue];
        }
        public static int length = Sprites.Count;
    }
}