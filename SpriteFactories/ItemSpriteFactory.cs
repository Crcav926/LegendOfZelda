using LegendOfZelda;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ObjectManagementExamples;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace LegendOfZelda
{
    public class ItemSpriteFactory
    {
        // Allows us to get the texture, but can't set.
        public Texture2D itemSpriteFinal { get; private set; }
        // More private Texture2Ds follow

        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            itemSpriteFinal = content.Load<Texture2D>("itemSpriteFinal");
        }


        private static Dictionary<String, List<Rectangle>> SpriteFrames = new Dictionary<String, List<Rectangle>>()
    {
        { "ArrowLeft", new List<Rectangle>()
            {
                // Left Rectangle
                new Rectangle(46, 57, 17, 7)
            }
        },{ "ArrowRight", new List<Rectangle>()
            {
                // Right Rectangle
                new Rectangle(7, 41, 16, 5)
            }
        },{ "ArrowDown", new List<Rectangle>()
            {
                // Down Arrow Rectangle
                new Rectangle(65, 56, 6, 16)
            }
        },{ "ArrowUp", new List<Rectangle>()
            {
                // Up Arrow Rectangle
                new Rectangle(1, 36, 5, 16)
            }
        },{ "MagicArrowLeft", new List<Rectangle>()
            {
                // Left Rectangle
                new Rectangle(45, 65, 18, 8)
            }
        },{ "MagicArrowRight", new List<Rectangle>()
            {
                // Right Rectangle
                new Rectangle(32, 40, 18, 8)
            }
        },{ "MagicArrowDown", new List<Rectangle>()
            {
                // Down Arrow Rectangle
                new Rectangle(74, 56, 7, 18)
            }
        },{ "MagicArrowUp", new List<Rectangle>()
            {
                // Up Arrow Rectangle
                new Rectangle(25, 35, 7, 18)
            }
        },{ "SwordLeft", new List<Rectangle>()
            {
                // Left Rectangle
                new Rectangle(11, 79, 17, 9)
            }
        },{ "SwordRight", new List<Rectangle>()
            {
                // Right Rectangle
                new Rectangle(11, 61, 17, 9)
            }
        },{ "SwordDown", new List<Rectangle>()
            {
                // Down Rectangle
                new Rectangle(0, 74, 10, 20)
            }
        },{ "SwordUp", new List<Rectangle>()
            {
                // Up Rectangle
                new Rectangle(0, 54, 10, 20)
            }
        },{ "Impact", new List<Rectangle>()
            {
                // Single Fire Rectangle
                new Rectangle(50, 40, 9, 8)
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
        },{ "MagicBoomerang", new List<Rectangle>()
            {
                // Animation Frames
                new Rectangle(88, 39, 7, 10),
                new Rectangle(94, 39, 10, 10),
                new Rectangle(105, 39, 10, 10)
            }
        },{ "Boomerang", new List<Rectangle>()
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
                new Rectangle(125, 35, 10, 18),
            }
        },{ "Explosion", new List<Rectangle>()
                {
                // Animation Frames
                new Rectangle(135, 35, 16, 18),
                new Rectangle(152, 35, 16, 18),
                new Rectangle(169, 35, 16, 18)
            }
        },{ "OrangeRupee", new List<Rectangle>()
            {
                // Single orange Rupee
                new Rectangle(72, 0, 8, 16)
            }
        },{ "NoItem", new List<Rectangle>()
            { 
                new Rectangle(0, 64, 1, 1) 
            }
        },{ "bow", new List<Rectangle>()
            {
                new Rectangle(144, 0, 9, 16)
            }
        },{ "HeartRed", new List<Rectangle>() 
            { 
                new Rectangle(0, 0, 7, 7) 
            }
        },{ "HalfHeart", new List<Rectangle>()
            { 
                new Rectangle(8, 0, 7, 7)
            }
        },{ "EmptyHeart", new List<Rectangle>()
            {
                new Rectangle(16, 0, 7, 7) 
            }
        },{ "HeartBlue", new List<Rectangle>()
            {
                new Rectangle(0, 8, 7, 7)
            }
        },{ "HeartBig", new List<Rectangle>()
            {
                new Rectangle(25, 0, 13, 13)
            }
        },{ "Fairy", new List<Rectangle>()
            {
                new Rectangle(40, 0, 8, 16),
                new Rectangle(48, 0, 8, 16)
            }
        },{ "Clock", new List<Rectangle>()
            {
                new Rectangle(58, 0, 11, 16)
            }
        },{ "JewelBlue", new List<Rectangle>()
            {
                new Rectangle(72, 16, 8, 16)
            }
        },{ "PotionRed", new List<Rectangle>()
            {
                new Rectangle(80, 0, 8, 16)
            }
        },{ "PotionBlue", new List<Rectangle>()
            {
                new Rectangle(80, 16, 8, 16)
            }
        },{ "Scroll", new List<Rectangle>()
            {
                new Rectangle(87, 0, 8, 16)
            }
        },{ "ScrollBlue", new List<Rectangle>()
            {
                new Rectangle(88, 16, 8, 16)
            }
        },{ "Meat", new List<Rectangle>()
            {
                new Rectangle(88, 0, 8, 16)
            }
        },{ "swordBlue", new List<Rectangle>()
            {
                new Rectangle(104, 16, 8, 16)
            }
        },{ "swordFancy", new List<Rectangle>()
            {
                new Rectangle(112, 0, 8, 16)
            }
        },{ "shield", new List<Rectangle>()
            {
                new Rectangle(120, 0, 8, 16)
            }
        },{ "boomerang", new List<Rectangle>()
            {
                new Rectangle(128, 0, 8, 16)
            }
        },{ "boomerangBlue", new List<Rectangle>()
            {
                new Rectangle(128, 16, 8, 16)
            }
        },{ "Candle", new List<Rectangle>()
            {
                new Rectangle(160, 0, 8, 16) 
            }
        },{ "CandleBlue", new List<Rectangle>()
            {
                new Rectangle(160, 16, 8, 16)
            }
        },{ "Ring", new List<Rectangle>() 
            {
                new Rectangle(169, 0, 8, 16)
            }
        },{ "RingBlue", new List<Rectangle>() {
                new Rectangle(169, 16, 8, 16)
            }
        },{ "RingIsh", new List<Rectangle>()
            {
                new Rectangle(176, 0, 8, 16)
            }
        },{ "Chain", new List<Rectangle>() 
            {
                new Rectangle(185, 0, 8, 16)
            }
        },{ "Logs", new List<Rectangle>()
            {
                new Rectangle(193, 0, 16, 16)
            }
        },{ "Ladder", new List<Rectangle>() 
            {
                new Rectangle(208, 0, 16, 16) 
            }
        },{ "Wand", new List<Rectangle>()
            { 
                new Rectangle(225, 0, 7, 16) 
            }
        },{ "HealthPack", new List<Rectangle>()
            { 
                new Rectangle(232, 0, 8, 16) 
            }
        },{ "Key", new List<Rectangle>()
            {
                new Rectangle(240, 0, 8, 16) 
            }
        },{ "Key2", new List<Rectangle>()
            {
            new Rectangle(248, 0, 8, 16) 
            }
        }, {"Compass", new List<Rectangle>()
            {
            new Rectangle(258, 0, 16, 16)
            }
        },{"Triforce", new List<Rectangle>()
            {
            new Rectangle(275, 1, 16, 16)
            }
        },{"TriforceBlue", new List<Rectangle>()
            {
            new Rectangle(275, 18, 16, 16)
            }
        },{ "Heart", new List<Rectangle>()
            {
                // Single orange Rupee
                new Rectangle(0, 0, 8, 8)
            }
        }
            ,{ "Clock", new List<Rectangle>()
            {
                // Single orange Rupee
                new Rectangle(60, 0, 8, 16)
            }
        }
            ,{ "BlueRupee", new List<Rectangle>()
            {
                // Single orange Rupee
                new Rectangle(72, 17, 8, 16)
            }
}
            ,{ "Unknown", new List<Rectangle>()
            {
                // Single orange Rupee
                new Rectangle(50, 0, 8, 16),
                new Rectangle(58, 0, 8, 16),
            }
}

    };



        public ISprite CreateSwordSprite(int i)
        {
            // 0 left, 1 right, 2 down, 3 up
            switch (i) {
                case 0: return new Sprite(itemSpriteFinal, SpriteFrames["SwordLeft"]);
                case 1: return new Sprite(itemSpriteFinal, SpriteFrames["SwordRight"]);
                case 2: return new Sprite(itemSpriteFinal, SpriteFrames["SwordDown"]);
                case 3: return new Sprite(itemSpriteFinal, SpriteFrames["SwordUp"]);
            }
            return new Sprite(itemSpriteFinal, SpriteFrames["SwordRight"]);

            }

        public ISprite CreateArrowSprite(int i)
        {
            switch (i)
            {
                case 0: return new Sprite(itemSpriteFinal, SpriteFrames["ArrowLeft"]);
                case 1: return new Sprite(itemSpriteFinal, SpriteFrames["ArrowRight"]);
                case 2: return new Sprite(itemSpriteFinal, SpriteFrames["ArrowDown"]);
                case 3: return new Sprite(itemSpriteFinal, SpriteFrames["ArrowUp"]);
            }
            return new Sprite(itemSpriteFinal, SpriteFrames["ArrowRight"]);

        }

        public ISprite CreateMagicArrowSprite(int i)
        {
            switch (i)
            {
                case 0: return new Sprite(itemSpriteFinal, SpriteFrames["MagicArrowLeft"]);
                case 1: return new Sprite(itemSpriteFinal, SpriteFrames["MagicArrowRight"]);
                case 2: return new Sprite(itemSpriteFinal, SpriteFrames["MagicArrowDown"]);
                case 3: return new Sprite(itemSpriteFinal, SpriteFrames["MagicArrowUp"]);
            }
            return new Sprite(itemSpriteFinal, SpriteFrames["ArrowRight"]);
        }
        public ISprite CreateImpactSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Impact"]);
        }
        public ISprite CreateBombSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Bomb"]);
        }
        public ISprite CreateExplosionSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Explosion"]);
        }
        public ISprite CreateBoomerangSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Boomerang"]);
        }
        public ISprite CreateMagicBoomerangSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["MagicBoomerang"]);
        }
        public ISprite CreateTornadoSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Tornado"]);
        }
        public ISprite CreateFireSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Fire"]);
        }
        public ISprite OrangeRupee()
        {
            Debug.WriteLine("Generated Orange Rupee Sprite");
            return new Sprite(itemSpriteFinal, SpriteFrames["OrangeRupee"]);
        }

        public ISprite CreateNoItemSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["NoItem"]);
        }

        public ISprite CreateBowSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["bow"]);
        }

        public ISprite CreateHeartRedSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["HeartRed"]);
        }

        public ISprite CreateHalfHeartSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["HalfHeart"]);
        }

        public ISprite CreateEmptyHeartSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["EmptyHeart"]);
        }

        public ISprite CreateHeartBlueSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["HeartBlue"]);
        }

        public ISprite CreateHeartBigSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["HeartBig"]);
        }

        public ISprite CreateFairySprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Fairy"]);
        }

        public ISprite CreateClockSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Clock"]);
        }

        public ISprite CreateJewelBlueSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["JewelBlue"]);
        }

        public ISprite CreatePotionRedSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["PotionRed"]);
        }

        public ISprite CreatePotionBlueSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["PotionBlue"]);
        }

        public ISprite CreateScrollSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Scroll"]);
        }

        public ISprite CreateScrollBlueSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["ScrollBlue"]);
        }

        public ISprite CreateMeatSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Meat"]);
        }

        public ISprite CreateSwordBlueSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["swordBlue"]);
        }

        public ISprite CreateSwordFancySprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["swordFancy"]);
        }

        public ISprite CreateShieldSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["shield"]);
        }

        public ISprite CreateBoomerangSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["boomerang"]);
        }

        public ISprite CreateBoomerangBlueSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["boomerangBlue"]);
        }

        public ISprite CreateCandleSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Candle"]);
        }

        public ISprite CreateCandleBlueSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["CandleBlue"]);
        }

        public ISprite CreateRingSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Ring"]);
        }

        public ISprite CreateRingBlueSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["RingBlue"]);
        }

        public ISprite CreateRingIshSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["RingIsh"]);
        }

        public ISprite CreateChainSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Chain"]);
        }

        public ISprite CreateLogsSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Logs"]);
        }

        public ISprite CreateLadderSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Ladder"]);
        }

        public ISprite CreateWandSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Wand"]);
        }

        public ISprite CreateHealthPackSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["HealthPack"]);
        }

        public ISprite CreateKeySprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Key"]);
        }

        public ISprite CreateKey2Sprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Key2"]);
        }

        public ISprite CreateCompassSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Compass"]);
        }

        public ISprite CreateTriforceSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["Triforce"]);
        }

        public ISprite CreateTriforceBlueSprite()
        {
            return new Sprite(itemSpriteFinal, SpriteFrames["TriforceBlue"]);
        }

    }

}
