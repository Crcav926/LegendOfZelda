using LegendOfZelda;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

namespace LegendOfZelda
{
    internal class EnemySpriteFactory
    {
        private static EnemySpriteFactory instance = new EnemySpriteFactory();
        private static Texture2D enemySpriteSheet;
        private static Texture2D bossSpriteSheet;

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemySpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            bossSpriteSheet = content.Load<Texture2D>("bossSpriteSheet");
            enemySpriteSheet = content.Load<Texture2D>("enemySpriteSheet2");

            // More Content.Load calls follow
            //...
        }
        public ISprite CreateBladeTrapSprite()
        {
            List<Rectangle> bladeTrapFrames = new List<Rectangle>
            {
                new Rectangle(162, 59, 20, 20)
            };
            return new Sprite(enemySpriteSheet, bladeTrapFrames);
        }
        public ISprite CreateGelSprite()
        {
            List<Rectangle> gelFrames = new List<Rectangle>
            {
                new Rectangle(1, 11, 8, 15),
                new Rectangle(10, 11, 8, 15),
                new Rectangle(19, 11, 8, 15),
                new Rectangle(28, 11, 8, 15),
                new Rectangle(37, 11, 8, 15),
                new Rectangle(46, 11, 8, 15),
                new Rectangle(55, 11, 8, 15),
                new Rectangle(64, 11, 8, 15),
                new Rectangle(1, 28, 8, 15),
                new Rectangle(10, 28, 8, 15),
                new Rectangle(19, 28, 8, 15),
                new Rectangle(28, 28, 8, 15),
                new Rectangle(55, 28, 8, 15),
                new Rectangle(64, 28, 8, 15)
            };
            return new Sprite(enemySpriteSheet, gelFrames);
        }
        public ISprite CreateStalfolSprite()
        {
            List<Rectangle> stalfolFrames = new List<Rectangle>
        {
            new Rectangle(1, 59, 16, 16),
            // TODO: Find a second frame for the Stafols
            // new Rectangle(53, 45, 16, 16)
        };
            return new Sprite(enemySpriteSheet, stalfolFrames);
        }
        public ISprite CreateZolSprite()
        {
            List<Rectangle> zolFrames = new List<Rectangle>
        {
            new Rectangle(77, 11, 16, 16),
            new Rectangle(94, 11, 16, 16),
            new Rectangle(111, 11, 16, 16),
            new Rectangle(128, 11, 16, 16),
            new Rectangle(145, 11, 16, 16),
            new Rectangle(162, 11, 16, 16),
            new Rectangle(77, 28, 16, 16),
            new Rectangle(94, 28, 16, 16),
            new Rectangle(145, 28, 16, 16),
            new Rectangle(162, 28, 16, 16)
        };
            return new Sprite(enemySpriteSheet, zolFrames);
        }
        /*
         * Creates Sprite for Wallmaster enemy type
         */
        public ISprite CreateWallmasterSprite()
        {
            List<Rectangle> WallmasterFrames = new List<Rectangle>
        {
            new Rectangle(392, 11, 17, 19),
            new Rectangle(410, 11, 17, 19),
        };
            return new Sprite(enemySpriteSheet, WallmasterFrames);
        }
        public ISprite CreateKeeseSprite()
        {
            List<Rectangle> keeseFrames = new List<Rectangle>
        {
            new Rectangle(183, 11, 16, 16),
            new Rectangle(200, 11, 16, 16),
            new Rectangle(183, 28, 16, 16),
            new Rectangle(200, 28, 16, 16)
        };
            return new Sprite(enemySpriteSheet, keeseFrames);
        }
        public ISprite CreateUpGoriyaSprite()
        {
            List<Rectangle> upFrames = new List<Rectangle>
            {
                new Rectangle(238, 11, 16, 16),
                new Rectangle(306, 28, 16, 16)
            };
            return new Sprite(enemySpriteSheet, upFrames);
        }
        public ISprite CreateDownGoriyaSprite()
        {
            List<Rectangle> downFrames = new List<Rectangle>
            {
                 new Rectangle(221, 11, 16, 16),
                 new Rectangle(289, 28, 16, 16)
            };
            return new Sprite(enemySpriteSheet, downFrames);
        }
        public ISprite CreateLeftGoriyaSprite()
        {
            List<Rectangle> leftFrames = new List<Rectangle>
            {
                new Rectangle(370, 146, 16, 16),
                new Rectangle(387, 146, 16, 16),
            };
            return new Sprite(enemySpriteSheet, leftFrames);
        }
        public ISprite CreateRightGoriyaSprite()
        {
            List<Rectangle> rightFrames = new List<Rectangle>
            {
                new Rectangle(255, 11, 16, 16),
                new Rectangle(272, 11, 16, 16),
            };
            return new Sprite(enemySpriteSheet, rightFrames);
        }
        public ISprite CreateGoriyaProjectileSprite()
        {
            List<Rectangle> projectileFrames = new List<Rectangle>
            {
                new Rectangle(289, 11, 8, 16),
                new Rectangle(298, 11, 8, 16),
                new Rectangle(307, 11, 8, 16),
            };
            return new Sprite(enemySpriteSheet, projectileFrames);
        }

        public ISprite CreateAquamentusSprite()
        {

            List<Rectangle> AquamentusFrames = new List<Rectangle>
            {
                    new Rectangle(1, 11, 24, 32),
                    new Rectangle(26, 11, 24, 32),
                    new Rectangle(51, 11, 24, 32),
                    new Rectangle(76, 11, 24, 32)

             };
            return new Sprite(bossSpriteSheet, AquamentusFrames);
        }
        public ISprite CreateFireBallSprite()
        {
            List<Rectangle> fireball = new List<Rectangle>
            {
                    new Rectangle(101, 11, 8, 16),
                    new Rectangle(110, 11, 8, 16),
                    new Rectangle(119, 11, 8, 16),
                    new Rectangle(128, 11, 8, 16)
            };

            return new Sprite(bossSpriteSheet, fireball);
        }
        public ISprite CreateGanonSprite()
        {

            List<Rectangle> GanonFrames = new List<Rectangle>
            {
                    new Rectangle(40, 154, 32, 32),
                    new Rectangle(73, 154, 32, 32),
                    new Rectangle(106, 154, 32, 32),
                    new Rectangle(139, 154, 32, 32),
                    new Rectangle(172, 154, 32, 32)
             };
            return new Sprite(bossSpriteSheet, GanonFrames);
        }
        public ISprite CreateGanonVulnerableSprite()
        {

            List<Rectangle> GanonVulnerableFrames = new List<Rectangle>
            {
                    new Rectangle(205, 154, 32, 32)
             };
            return new Sprite(bossSpriteSheet, GanonVulnerableFrames);
        }
    }
}
