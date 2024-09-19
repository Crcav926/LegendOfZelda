using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    internal class SpriteItemData
    {
        public static List<Rectangle> noItem = new List<Rectangle> { new Rectangle(0, 11, 1, 1) };
        public static List<Rectangle> vertArrow = new List<Rectangle> { new Rectangle(1, 185, 8, 16) };
        public static List<Rectangle> horizArrow = new List<Rectangle> { new Rectangle(10, 185, 16, 16) };
        public static List<Rectangle> boomer = new List<Rectangle> { new Rectangle(64, 185, 8, 16), new Rectangle(73, 185, 8, 16), new Rectangle(82, 185, 8, 16) };
        public static List<List<Rectangle>> SpriteFrames = new List<List<Rectangle>> { noItem, vertArrow, horizArrow, boomer };

       

        
        public static List<Rectangle> GetRectangleData(int spriteValue)
        {
            // return the list of frames
            return SpriteFrames[spriteValue];
            
        }

        public static int ListLength() { return SpriteFrames.Count; }


    }
}
