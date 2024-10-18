using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class Constants
    {
        // Global scaling
        public const float GlobalScale = 4.0f;
        // Screen size
        public const int ScreenWidth = 1920;  // Screen width
        public const int ScreenHeight = 1080;  // Screen height
        // Original resolution in which the sprites are scaled to.
        public const int OriginalWidth = 256;
        public const int OriginalHeight = 176;
        // Scaling calculations
        public const float ScaleX = (float)ScreenWidth / OriginalWidth;
        public const float ScaleY = (float)ScreenHeight / OriginalHeight;
        // Miku size
        public const int MikuHeight = 16;
        public const int MikuWidth = 16;
        // Standard size
        public const int StandardHeight = 16;
        public const int StandardWidth = 16;
        // Aquamentus
        public const int AquamentusHeight = 100;
        public const int AquamentusWidth = 100;
        public const float AquamentusThrowCooldown = 3f;    
        public const float AquamentusThrowTimer = 0f;       
        public const float AquamentusFrameTime = 0.1f;
        public const float AquamentusFrameTimer = 0f;
    }
}