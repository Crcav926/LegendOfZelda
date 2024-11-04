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
        // Standard size
        public const int StandardHeight = 16;
        public const int StandardWidth = 16;
        // Animation time
        public const int AnimationTime = 1;

        // Global scaling
        public const float GlobalScale = 4.0f;
        // Link
        public const int LinkHeight = 40;
        public const int LinkWidth = 40;
        public const int LinkMaxDamageCycles = 6;
        public const double LinkColorChangeInterval = 0.05;
        public const int LinkStartingHealth = 10;
        // Standard size
        public const int StandardHeight = 16;
        public const int StandardWidth = 16;
        // Block size
        public const int BlockHeight = 42;
        public const int BlockWidth = 50;
        // Standard size
        public const int DoorHeight = 88;
        public const int DoorWidth = 102;
        // Aquamentus
        public const int AquamentusHeight = 80;
        public const int AquamentusWidth = 80;
        public const float AquamentusSpeed = 80f;
        public const float AquamentusMaxX = 100f;
        public const float AquamentusMinX = 10f;
        public const float AquamentusThrowCooldown = 3f;
        public const int AquamentusFireballXOffset = 3;
        public const int AquamentusFireballYOffset = 9;

        //Blade Trap
        public const float BladeTrapActiveTime = 10f;
        public const float BladeTrapHiddenTime = 2f;
        public const int BladeTrapHeight = 42;
        public const int BladeTrapWidth = 50;

        //Fireballs
        public const float FireballSpeed = 150f;
        public const int FireballHeight = 24;
        public const int FireballWidth = 48;

        //Gel
        public const float GelJumpSpeed = 50f;
        public const float GelJumpRange = 50f;
        public const int GelHeight = 32;
        public const int GelWidth = 60;
        
        //Goriyas
        public const float GoriyaSpeed = 100f;
        public const float GoriyaThrowCooldown = 2f;
        public const float GoriyaChangeDirectionCooldown = 2f;
        public const int GoriyaHeight = 45;
        public const int GoriyaWidth = 40;
        public const float GoriyaProjectileOffset = 10f;

        //Goriya Projectile
        public const float GoriyaProjectileSpeed = 200f;
        public const int GoriyaProjectileHeight = 30;
        public const int GoriyaProjectileWidth = 30;

        //Keese
        public const float KeeseSpeed = 100f;
        public const int KeeseHeight = 45;
        public const int KeeseWidth = 40;

        //Stalfos
        public const float StalfosSpeed = 100f;
        public const float StalfosChangeDirectionCooldown = 2f;
        public const int StalfosHeight = 40;
        public const int StalfosWidth = 40;

        //Wallmasters
        public const float WallmasterJumpSpeed = 80f;
        public const float WallmasterJumpCooldown = 1f;
        public const float WallmasterJumpRange = 100f;
        public const int WallmasterHeight = 40;
        public const int WallmasterWidth = 40;

        //Zol
        public const float ZolJumpSpeed = 50f;
        public const float ZolJumpRange = 50f;
        public const int ZolHeight = 40;
        public const int ZolWidth = 40;

        //Arrows
        public const float ArrowSpeedX = 5f;
        public const float ArrowSpeedY = 5f;
        public const float ArrowMaxDistanceX = 150f;
        public const float ArrowMaxDistanceY = 150f;

        //Bombs
        public const float BombOffsetX = 50f;
        public const float BombOffsetY = 50f;
        public const float BombTimePerFrame = 0.3f;

         //Boomerang
        public const float BoomerangSpeedX = 5f;
        public const float BoomerangSpeedY = 5f;
        public const float BoomerangMaxDistanceX = 150f;
        public const float BoomerangMaxDistanceY = 150f;
        public const double BoomerangTimePerFrame = 0.05;
        public const int BoomerangWidth = 24;
        public const int BoomerangHeight = 32;
        //not sure why this one is a double while the rest are floats, i'm just copying over.

        //Fire
        public const double FireLingerTime = 0.50;
        //linger time actually goes unused right now, but i put it here anyway.
        public const float FireSpeedX = 5f;
        public const float FireSpeedY = 5f;
        public const float FireMaxDistanceX = 150f;
        public const float FireMaxDistanceY = 150f;

        //Sword
        public const double SwordTimeOnScreen = 0.40;
        //these almost certainly need reduced.
        public const float SwordOffsetX = 24f;
        public const float SwordOffsetY = 24f;
        public const float SwordMaxDistanceX = 150f;
        public const float SwordMaxDistanceY = 150f;
    }
}
