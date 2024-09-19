using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    internal class SpriteItemData
    {
        public static List<List<Rectangle>> SpriteFrames = new List<List<Rectangle>>();

        public SpriteItemData()
        {
            // 0 = no item, 1 vertical arrow, 2 horizontal arrow, 3 boomerang
            //0
            List<Rectangle> noItem = new List<Rectangle>();
            noItem.Add(new Rectangle(0, 11, 1, 1));
            //1
            List<Rectangle> vertArrow = new List<Rectangle>();
            vertArrow.Add(new Rectangle(1, 185, 8, 16));
            //2
            List<Rectangle> horizArrow = new List<Rectangle>();
            horizArrow.Add(new Rectangle(10, 185, 16, 16));
            //3
            List<Rectangle> boomer = new List<Rectangle>();
            boomer.Add(new Rectangle(64, 185, 8, 16));
            boomer.Add(new Rectangle(73, 185, 8, 16));
            boomer.Add(new Rectangle(82, 185, 8, 16));
        }

        
        public static List<Rectangle> GetRectangleData(int spriteValue)
        {
            // return the list of frames
            return SpriteFrames[spriteValue];
            
        }


    }
}
