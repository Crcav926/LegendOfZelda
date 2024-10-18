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
        // Block size
        public const int BlockHeight = 16;
        public const int BlockWidth = 16;
        // Standard size
        public const int DoorHeight = 32;
        public const int DoorWidth = 32;
        // Aquamentus
        public const int AquamentusHeight = 32;
        public const int AquamentusWidth = 24;
        public const float AquamentusSpeed = 80f;
        public const float AquamentusMaxX = 100f;
        public const float AquamentusMinX = 10f;
        public const float AquamentusThrowCooldown = 3f;
        public const int AquamentusFireballXOffset = 3;
        public const int AquamentusFireballYOffset = 9;

        //Blade Trap
        public const float BladeTrapActiveTime = 10f;
        public const float BladeTrapHiddenTime = 2f;
        public const int BladeTrapHeight = 16;
        public const int BladeTrapWidth = 16;

        //Fireballs
        public const float FireballSpeed = 150f;
        public const int FireballHeight = 10;
        public const int FireballWidth = 8;

        //Gel
        public const float GelJumpSpeed = 50f;
        public const float GelJumpRange = 50f;
        public const int GelHeight = 8;
        public const int GelWidth = 8;
        
        //Goriyas
        public const float GoriyaSpeed = 100f;
        public const float GoriyaThrowCooldown = 2f;
        public const float GoriyaChangeDirectionCooldown = 2f;
        public const int GoriyaHeight = 16;
        public const int GoriyaWidth = 16;
        public const float GoriyaProjectileOffset = 10f;

        //Goriya Projectile
        public const float GoriyaProjectileSpeed = 200f;
        public const int GoriyaProjectileHeight = 8;
        public const int GoriyaProjectileWidth = 8;

        //Keese
        public const float KeeseSpeed = 100f;
        public const int KeeseHeight = 16;
        public const int KeeseWidth = 16;

        //Stalfos
        public const float StalfosSpeed = 100f;
        public const float StalfosChangeDirectionCooldown = 2f;
        public const int StalfosHeight = 16;
        public const int StalfosWidth = 16;

        //Wallmasters
        public const float WallmasterJumpSpeed = 80f;
        public const float WallmasterJumpCooldown = 1f;
        public const float WallmasterJumpRange = 100f;
        public const int WallmasterHeight = 16;
        public const int WallmasterWidth = 16;

        //Zol
        public const float ZolJumpSpeed = 50f;
        public const float ZolJumpRange = 50f;
        public const int ZolHeight = 16;
        public const int ZolWidth = 16;
    }
}
