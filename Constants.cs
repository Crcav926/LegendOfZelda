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
        public const int PausedInventoryWidth = OriginalWidth;
        public const int PausedInventoryHeight = OriginalHeight / 3;
        // Original resolution in which the sprites are scaled to.
        public const int OriginalWidth = 800;
        public const int OriginalHeight = 484;
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
        //HP HERE
        public const int MikuStartingHealth = 60;
        public const int PointsPerHP = 4;
        public const double MikuInvincibilityTimer = 2.5;
        public const int MikuStartingPositionX = 370;
        public const int MikuStartingPositionY = 330;
        public const double MikuDeathTime = 3.1;
        // Standard size
        public const int StandardHeight = 16;
        public const int StandardWidth = 16;
        // Animation time
        public const int AnimationTime = 1;
        // Collision values
        public const int CollisionPushDistance = 2;
        // Blocks
        public const int BlockWidth = 50;
        public const int BlockHeight = 44;
        // Doors
        //also not sure if this should be 102; i'm just putting in the magic numbers we have.
        public const int DoorWidth = 100;
        public const int DoorHeight = 88;
        // Walls
        //this is used for the wall sprite, NOT the hitboxes.
        public const int WallsWidth = 800;
        public const int WallsHeight = 484;
        // Floor
        public const int FloorWidth = 600;
        public const int FloorHeight = 308;
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
        //Ganon
        public const int GanonHeight = 80;
        public const int GanonWidth = 80;
        public const int GanonFireballXOffset = 10;
        public const int GanonFireballYOffset = 30;
        public const int GanonHitboxWidth = 80;
        public const int GanonHitboxHeight = 80;
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
        //DarkNut
        public const float DarkNutChangeDirectionCooldown = 1.5f;
        public const float DarkNutSpeed = 2.5f;
        //Dodongo
        public const float DodongoChangeDirectionCooldown = 1f;
        public const float DodongoSpeed = 2f;
        public const float DodongoSpeed2 = 10f;
        public const int DodongoDamage = 3;
        public const int DodongoHp = 10;
        public const int DodongoHitboxWidth1 = 65;
        public const int DodongoHitboxHeight1 = 60;
        public const int DodongoHeight1 = 60;
        public const int DodongoWidth1 = 60;
        public const int DodongoWidth2 = 102;
        public const int DodongoHitboxWidth2 = 105;
        public const int DodongoHitboxHeight2 = 60;
        //Gohma
        public const int GohmaHp = 10;
        public const float GohmaSpeed = 10f;
        public const int GohmaHeight = 60;
        public const int GohmaWidth = 170;
        public const int GohmaHitboxWidth = 175;
        public const int GohmaHitboxHeight = 60;
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
        public const int coinsHUDPosY = -87;
        public const int keysHUDPosX = 300;
        public const int keysHUDPosY = -54;
        public const int bombsHUDPosX = 300;
        public const int bombsHUDPosY = -34;
        // Sprite 1 HUD values
        public const int HUDSprite1X = 400;
        public const int HUDSprite1Y = -70;
        public const int HUDSprite2X = 475;
        public const int HUDSprite2Y = -70;
        public const int HUDSpriteWidth = 25;
        public const int HUDSpriteHeight = 40;
        // HUD Health
        public const int hpHUDPosX = 550;
        public const int hpHUDPosY = -35;
        public const int HUDHPSpriteDimensionX = 25;
        public const int HUDHPSpriteDimensionY = 18;
        public const int FloorSizeX = 600;
        public const int FloorSizeY = 306;

        // Minimap
        public const int HUDMapX = 55;
        public const int HUDMapY = -120;
        public const int HUDMapDimensionX = 192;
        public const int HUDMapDimensionY = 120;

        public const int HUDMapLevelX = 198;
        public const int HUDMapLevelY = -120;
        public const int HUDMapLevelDimensionX = 25;
        public const int HUDMapLevelDimensionY = 25;

        public const int dotSize = 9;
        public const int miniMapStartX = 133;
        public const int miniMapStartY = -24;

        //menu
        public const int MenuWidth = 768;
        public const int MenuHeight = 432;

        // HUD Map
        public const int MapSpriteX = 50;
        public const int MapSpriteY = -105;
        public const int MapSpriteWidth = 200;
        public const int MapSpriteHeight = 88;
        public const int LevelCountSpriteX = 200;
        public const int LevelCountSpriteY = -105;
        public const int LevelCountSpriteWidth = 25;
        public const int LevelCountSpriteHeight = 18;
        // Camera2D
        public const int HorizontalSlideDistance = 800;
        public const int VerticalSlideDistance = 480;
        public const float SlidingThreshold = 5f;
        public const float LerpFactor = 0.03f;
    }
}