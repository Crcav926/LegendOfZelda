using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    internal class SpriteRectangleData
    {
        // public Vector2 Up = new Vector2(0, 1);
        public static Dictionary<Vector2, List<Rectangle>> SpriteFrames = new Dictionary<Vector2, List<Rectangle>>()
    {
        // 0 = left, 1 = right, 2 = down, 3 = up
        { new Vector2(-1, 0), new List<Rectangle>()
            {
                // Left Rectangles
                new Rectangle(120, 11, 16, 16),
                new Rectangle(103, 11, 16, 16)
            }
        },
        { new Vector2(1, 0), new List<Rectangle>()
            {
                // Right Rectangles
                new Rectangle(35, 11, 16, 16),
                new Rectangle(52, 11, 16, 16)
            }
        },{ new Vector2(0, 1), new List<Rectangle>()
            {
                // Down Rectangles
                new Rectangle(1, 11, 16, 16),
                new Rectangle(18, 11, 16, 16)
            }
        },{ new Vector2(0, -1), new List<Rectangle>()
            {
                // Up Rectangles
                new Rectangle(86, 11, 16, 16),
                new Rectangle(69, 11, 16, 16)
            }
        }
    };

        public static List<Rectangle> GetRectangleData(Vector2 spriteValue)
        {
            return SpriteFrames[spriteValue];
        }

    }
}
