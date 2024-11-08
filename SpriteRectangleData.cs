using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    internal class SpriteRectangleData2
    {
        public static Dictionary<int, List<Rectangle>> SpriteFrames = new Dictionary<int, List<Rectangle>>()
    {
        // 0 = left, 1 = right, 2 = down, 3 = up
        { 0, new List<Rectangle>()
            {
                new Rectangle(103, 11, 16, 16),
                new Rectangle(120, 11, 16, 16)
            }
        },
        { 1, new List<Rectangle>()
            {
                new Rectangle(35, 11, 16, 16),
                new Rectangle(52, 11, 16, 16)
            }
        },{ 2, new List<Rectangle>()
            {
                new Rectangle(1, 11, 16, 16),
                new Rectangle(18, 11, 16, 16)
            }
        },{ 3, new List<Rectangle>()
            {
                new Rectangle(69, 11, 16, 16),
                new Rectangle(86, 11, 16, 16)
            }
        }
    };

        public static List<Rectangle> GetRectangleData(int spriteValue)
        {
            return SpriteFrames[spriteValue];
        }

    }
}
