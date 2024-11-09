using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class Constants
    {
        // Screen size
        public const int ScreenWidth = 1600;  // Screen width
        public const int ScreenHeight = 900 + HUDHeight;  // Screen height
        public const int HUDWidth = 0;
        public const int HUDHeight = OriginalHeight / 4;
        // Original resolution in which the sprites are scaled to.
        public const int OriginalWidth = 800;
        public const int OriginalHeight = 480;
        // Scaling calculations
        public const float ScaleX = (float)ScreenWidth / OriginalWidth;
        // Miku 

        public const float ScaleY = (float)(ScreenHeight) / (OriginalHeight + HUDHeight);
        // Miku size

        public const int MikuHeight = 40;
        public const int MikuWidth = 40;
        public const float MikuSpeedX = 2f;
        public const float MikuSpeedY = 2f;
        public const int MikuMaxDamageCycles = 6;
        public const double MikuColorChangeInterval = 0.05;
        public const int MikuStartingHealth = 12;
        public const int PointsPerHP = 4;
        public const double MikuInvincibilityTimer = 2.5;
        public const int MikuStartingPositionX = 370;
        public const int MikuStartingPositionY = 330;
        // Standard size
        public const int StandardHeight = 16;
        public const int StandardWidth = 16;
        // Animation time
        public const int AnimationTime = 1;
        // Collision values
        public const int CollisionPushDistance = 2;
        // Blocks
        public const int BlockWidth = 50;
        //is this height wrong? doors should be twice as tall as blocks; 42 x 2 =/= 88
        public const int BlockHeight = 42;
        // Doors
        //also not sure if this should be 102; i'm just putting in the magic numbers we have.
        public const int DoorWidth = 102;
        public const int DoorHeight = 88;
        // Aquamentus
        public const int AquamentusHeight = 80;
        public const int AquamentusWidth = 80;
        public const int AquamentusHitboxWidth = 80;
        public const int AquamentusHitboxHeight = 80;
        public const float AquamentusMaxX = 100f;
        public const float AquamentusMinX = 10f;
        public const float AquamentusSpeed = 80f;
        public const float AquamentusThrowCooldown = 3f;    
        public const int AquamentusFireballXOffset = 10;
        public const int AquamentusFireballYOffset = 30;
        //not sure what either of these do, keeping them here.      
        public const float AquamentusFrameTime = 0.1f;
        public const float AquamentusFrameTimer = 0f;
        // Blade Trap
        public const float BladeTrapActiveTime = 10f;
        public const float BladeTrapHiddenTime = 2f;
        public const int BladeTrapHeight = 60;
        public const int BladeTrapWidth = 60;
        // Fireballs
        public const float FireballSpeed = 150f;
        public const int FireballHeight = 24;
        public const int FireballWidth = 48;
        // Gel
        public const float GelJumpSpeed = 50f;
        public const float GelJumpCooldown = 1f;
        public const float GelJumpRange = 50f;
        //seems a little tall, idk
        public const int GelHeight = 60;
        public const int GelWidth = 32;
        //should this be this size? I'm just going with what's in the file.
        public const int GelHitboxWidth = 45;
        public const int GelHitboxHeight = 40;
        // Goriya
        public const float GoriyaSpeed = 2f;
        public const float GoriyaThrowCooldown = 2f;
        public const float GoriyaChangeDirectionCooldown = 2f;
        public const int GoriyaHeight = 40;
        public const int GoriyaWidth = 45;
        public const float GoriyaProjectileOffset = 10f;
        //its at this point that I ask if we need all of these hitboxes to be different
        //its easier to change this way at least for different sized objects
        //if we wanna make a REALLY big goriya at least we can just change out the hitbox.
        public const int GoriyaHitboxWidth = 45;
        public const int GoriyaHitboxHeight = 40;
        // Goriya Projectiles
        public const float GoriyaProjectileSpeed = 200f;
        public const int GoriyaProjectileHeight = 30;
        public const int GoriyaProjectileWidth = 30;
        // Keese
        public const float KeeseSpeed = 100f;
        public const int KeeseHeight = 60;
        public const int KeeseWidth = 60;
        public const int KeeseHitboxWidth = 45;
        public const int KeeseHitboxHeight = 40;
        // Stalfos
        //I DONT KNOW WHY BUT THEYRE FAST AS FUCK
        public const float StalfosSpeed = 2f;
        public const float StalfosChangeDirectionCooldown = 2f;
        public const int StalfosHeight = 40;
        public const int StalfosWidth = 40;
        public const int StalfosHitboxWidth = 45;
        public const int StalfosHitboxHeight = 40;
        // Wallmasters
        public const float WallmasterJumpSpeed = 80f;
        public const float WallmasterJumpCooldown = 1f;
        public const float WallmasterJumpRange = 100f;
        public const int WallmasterHeight = 30;
        public const int WallmasterWidth = 30;
        //different sized hitboxes compared to the others.
        public const int WallmasterHitboxWidth = 30;
        public const int WallmasterHitboxHeight = 30;
        // Zol
        public const float ZolJumpSpeed = 50f;
        public const float ZolJumpCooldown = 1f;
        public const float ZolJumpRange = 50f;
        public const int ZolHeight = 60;
        public const int ZolWidth = 60;
        public const int ZolHitboxHeight = 60;
        public const int ZolHitboxWidth = 60;
        // Arrows
        public const float ArrowLingerTime = .25f;
        public const int ArrowWidth = 20;
        public const int ArrowHeight = 20;
        public const int ArrowSpeed = 3;
        public static readonly Vector2 ArrowMaxDistance = new Vector2(150, 150);
        // Bombs
        public const double BombStillTime = 2;
        public const double BombLingerTime = .5;
        public const float BombOffsetX = 50;
        public const float BombOffsetY = 50;
        public const double ExplosionFrameDuration = .5;
        // Boomerang
        public const int BoomerangSpeed = 10;
        public const int BoomerangWidth = 24;
        public const int BoomerangHeight = 32;
        public static readonly Vector2 BoomerangMaxDistance = new Vector2(150, 150);
        public const float BoomerangTimePerFrame = .05f;
        // Fire
        //maybe we'll need more here, but this is the only magic number in the file.
        public const double FireLingerTime = 1;
        // Sword
        public const double SwordTimeOnScreen = 0.30;
        public const float SwordOffsetX = 35f;
        public const float SwordOffsetY = 35f;
        //these values go unused, but if we need the sword distance vector again they're here.
        public const float SwordMaxDistanceX = 150f;
        public const float SwordMaxDistanceY = 150f;
        //big ol square sword
        public const int SwordWidth = 40;
        public const int SwordHeight = 40;
        //Wall Constants
        public static readonly Vector2 top1Position = new Vector2(0, 0);
        public static readonly Vector2 top2Position = new Vector2(450, 0);
        public static readonly Vector2 bot1Position = new Vector2(0, 392);
        public static readonly Vector2 bot2Position = new Vector2(350, 392);
        public static readonly Vector2 left1Position = new Vector2(0, 0);
        public static readonly Vector2 left2Position = new Vector2(0, 284);
        public static readonly Vector2 right1Position = new Vector2(700, 0);
        public static readonly Vector2 right2Position = new Vector2(700, 284);
        public static readonly Vector2 middleHorizontalSize = new Vector2(100, 80);
        public static readonly Vector2 middleVerticalSize = new Vector2(90, 88);
        public static readonly Vector2 horizontalWallSize = new Vector2(350, 87);
        public static readonly Vector2 verticalWallSize = new Vector2(100, 196);
        public static readonly Vector2 topMiddlePosition = new Vector2(350, 0);
        public static readonly Vector2 botMiddlePosition = new Vector2(350, 392);
        public static readonly Vector2 rightMiddlePosition = new Vector2(700, 196);
        public static readonly Vector2 leftMiddlePosition = new Vector2(0, 196);
        public static readonly Vector2 horizontalMiddleSize = new Vector2(100, 65);
        public static readonly Vector2 verticalMiddleSize = new Vector2(80, 88);

        // HUD Inventory Counter
        public const int HUDNumberSpriteDimensionX = 25;
        public const int HUDNumberSpriteDimensionY = 20;
        public const int coinsHUDPosX = 300;
        public const int coinsHUDPosY = -86;
        public const int keysHUDPosX = 300;
        public const int keysHUDPosY = -54;
        public const int bombsHUDPosX = 300;
        public const int bombsHUDPosY = -34;

        // HUD Health
        public const int hpHUDPosX = 550;
        public const int hpHUDPosY = -35;
        public const int HUDHPSpriteDimensionX = 25;
        public const int HUDHPSpriteDimensionY = 18;

        public const int FloorSizeX = 600;
        public const int FloorSizeY = 306;
    }
}