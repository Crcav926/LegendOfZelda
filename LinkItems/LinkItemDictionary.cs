using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    internal class LinkItemDictionary
    {
        private static Dictionary<String, List<Rectangle>> SpriteFrames = new Dictionary<String, List<Rectangle>>()
    {
        // 0 = left, 1 = right, 2 = down, 3 = up
        { "Arrow", new List<Rectangle>()
            {
                // Left Rectangle
                new Rectangle(46, 57, 17, 7),
                // Right Rectangle
                new Rectangle(7, 41, 16, 5),
                // Down Arrow Rectangle
                new Rectangle(65, 56, 6, 16),
                // Up Arrow Rectangle
                new Rectangle(1, 36, 5, 16),
                // Arrow Colliding
                new Rectangle(50, 40, 9, 8)
            }
        },
        { "MagicArrow", new List<Rectangle>()
            {
                // Left Rectangle
                new Rectangle(45, 65, 18, 8),
                // Right Rectangle
                new Rectangle(32, 40, 18, 8),
                // Down Arrow Rectangle
                new Rectangle(74, 56, 7, 18),
                // Up Arrow Rectangle
                new Rectangle(25, 35, 7, 18)
    }
        },{ "Sword", new List<Rectangle>()
            {
                // Left Rectangle
                new Rectangle(11, 79, 17, 9),
                // Right Rectangle
                new Rectangle(11, 61, 17, 9),
                // Down Rectangle
                new Rectangle(0, 74, 10, 20),
                // Up Rectangle
                new Rectangle(0, 54, 10, 20)
            }
        },{ "Fire", new List<Rectangle>()
            {
                // Single Fire Rectangle
                new Rectangle(188,36,16,16)
            }
        },{ "Tornado", new List<Rectangle>()
            {
                // Animation frames
                new Rectangle(207,36,16,16),
                new Rectangle(224,36,16,16),
                new Rectangle(241,36,16,16),
                new Rectangle(258,36,16,16)
            }
        },{ "Boomerang", new List<Rectangle>()
            {
                // Animation frames
                new Rectangle(62, 39, 5, 9),
                new Rectangle(70, 39, 8, 9),
                new Rectangle(79, 39, 8, 9)
            }
        },{ "MagicBoomerang", new List<Rectangle>()
            {
                // Animation Frames
                new Rectangle(88, 39, 7, 10),
                new Rectangle(94, 39, 10, 10),
                new Rectangle(105, 39, 10, 10)
            }
        },{ "Boomerang2", new List<Rectangle>()
            {
                // Animation Frames
                new Rectangle(61, 39, 6, 9),
                new Rectangle(69, 39, 9, 9),
                new Rectangle(78, 39, 9, 9),
                new Rectangle(87, 49, 9, 9),
                new Rectangle(87, 76, 9, 9),
                new Rectangle(87, 69, 9, 6),
                new Rectangle(87, 60, 9, 9)
            }
        },{ "Bomb", new List<Rectangle>()
            {
                // Animation Frames
                new Rectangle(124, 35, 11, 18),
                new Rectangle(135, 35, 16, 18),
                new Rectangle(152, 35, 16, 18),
                new Rectangle(169, 35, 16, 18)
            }
        }
    };
        public static List<Rectangle> GetRectangleData(String spriteValue)
        {
            return SpriteFrames[spriteValue];
        }
    }
}