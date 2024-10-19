using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class Constants
    {
        // Screen size
        public const int ScreenWidth = 1600;  // Screen width
        public const int ScreenHeight = 960;  // Screen height
        // Original resolution in which the sprites are scaled to.
        public const int OriginalWidth = 800;
        public const int OriginalHeight = 480;
        // Scaling calculations
        public const float ScaleX = (float)ScreenWidth / OriginalWidth;
        public const float ScaleY = (float)ScreenHeight / OriginalHeight;
        // Miku size
        public const int MikuHeight = 40;
        public const int MikuWidth = 40;
        // Standard size
        public const int StandardHeight = 16;
        public const int StandardWidth = 16;
        // Animation time
        public const int AnimationTime = 1;
        // Boomerang
        public const int BoomerangSpeed = 10;
        public const int BoomerangWidth = 24;
        public const int BoomerangHeight = 32;
        public static readonly Vector2 BoomerangMaxDistance = new Vector2(150, 150);
        public const float BoomerangTimePerFrame = .05f;
        // Arrow
        public const int ArrowSpeed = 3;
        public static readonly Vector2 ArrowMaxDistance = new Vector2(150, 150);
        // Bomb
        public const double ExplosionFrameDuration = .5;
        // Aquamentus
        public const int AquamentusHeight = 100;
        public const int AquamentusWidth = 100;
        public const float AquamentusThrowCooldown = 3f;    
        public const float AquamentusThrowTimer = 0f;       
        public const float AquamentusFrameTime = 0.1f;
        public const float AquamentusFrameTimer = 0f;
    }
}