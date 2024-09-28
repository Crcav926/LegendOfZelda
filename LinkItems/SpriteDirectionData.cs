using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda
{
    internal class SpriteDirectionData
    {
        // public Vector2 Up = new Vector2(0, 1);
        public static Dictionary<Vector2, int> SpriteDirection = new Dictionary<Vector2, int>()
    {
        // 0 = left, 1 = right, 2 = down, 3 = up
        { new Vector2(-1, 0), 0 },
        { new Vector2(1, 0), 1},
        { new Vector2(0, 1), 2},
        { new Vector2(0, -1), 3 }
    };

        public static int GetDirection(Vector2 direction)
        {
            return SpriteDirection[direction];
        }

    }
}
