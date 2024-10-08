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
                enemySpriteSheet = content.Load<Texture2D>("bossSpriteSheet");

                // More Content.Load calls follow
                //...
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
            return new Sprite(enemySpriteSheet, AquamentusFrames);
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

            return new Sprite(enemySpriteSheet, fireball);
        }
    }
}
