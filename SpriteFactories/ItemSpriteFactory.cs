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
            },
            { "Explosion", new List<Rectangle>()
                {
                // Animation Frames
                new Rectangle(135, 35, 16, 18),
                new Rectangle(152, 35, 16, 18),
                new Rectangle(169, 35, 16, 18),
            }
        },{ "OrangeRupee", new List<Rectangle>()
            {
                // Single orange Rupee
                new Rectangle(72, 0, 8, 16)
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
    }

}
