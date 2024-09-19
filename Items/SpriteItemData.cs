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
        public static List<Rectangle> projEnd = new List<Rectangle> { new Rectangle(53, 185, 8, 16) };
        public static List<Rectangle> bomb = new List<Rectangle> { new Rectangle(129, 185, 8, 16), new Rectangle(138, 185, 16, 16), new Rectangle(155, 185, 16, 16), new Rectangle(172, 185, 16, 16) };
        public static List<Rectangle> fire = new List<Rectangle> { new Rectangle(191, 185, 16, 16), new Rectangle(210, 185, 16, 16), new Rectangle(227, 185, 16, 16), new Rectangle(244, 185, 16, 16), new Rectangle(261, 185, 16, 16) };
        public static List<Rectangle> ladder = new List<Rectangle> { new Rectangle(280, 185, 16, 16) };
        public static List<Rectangle> meat = new List<Rectangle> { new Rectangle(299, 185, 8, 16) };

        // missing : gem, triangle, paper, hearts, fairy, compass, clock, and bow

        public static List<List<Rectangle>> SpriteFrames = new List<List<Rectangle>> { 
            noItem, vertArrow, horizArrow, boomer, projEnd, bomb, fire, ladder, meat };

       

        
        public static List<Rectangle> GetRectangleData(int spriteValue)
        {
            // return the list of frames
            return SpriteFrames[spriteValue];
            
        }

        public static int ListLength() { return SpriteFrames.Count; }


    }
}
