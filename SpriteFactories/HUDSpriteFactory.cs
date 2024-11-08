using LegendOfZelda;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ObjectManagementExamples;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using LegendOfZelda.LinkMovement;

namespace LegendOfZelda
{
    public class HUDSpriteFactory
    {
        // Allows us to get the texture, but can't set.
        public Texture2D HUDSpriteSheet { get; private set; }
        // More private Texture2Ds follow

        private static HUDSpriteFactory instance = new HUDSpriteFactory();

        public static HUDSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private HUDSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            HUDSpriteSheet = content.Load<Texture2D>("HUDSpriteSheet");
        }


        private static Dictionary<String, List<Rectangle>> SpriteFrames = new Dictionary<String, List<Rectangle>>()
    {
        { "HUD", new List<Rectangle>()
            {
                new Rectangle(258, 11, 256, 56)
            }
        }, { "X", new List<Rectangle>()
            {
                new Rectangle(519, 117, 8, 8)
            }
        },{ "0", new List<Rectangle>()
            {
                new Rectangle(528, 117, 8, 8)
            }
        },{ "1", new List<Rectangle>()
            {
                new Rectangle(537, 117, 8, 8)
            }
        },{ "2", new List<Rectangle>()
            {
                new Rectangle(546, 117, 8, 8)
            }
        },{ "3", new List<Rectangle>()
            {
                new Rectangle(555, 117, 8, 8)
            }
        },{ "4", new List<Rectangle>()
            {
                new Rectangle(564, 117, 8, 8)
            }
        },{ "5", new List<Rectangle>()
            {
                new Rectangle(573, 117, 8, 8)
            }
        }, { "6", new List<Rectangle>()
            {
                new Rectangle(582, 117, 8, 8)
            }
        },{ "7", new List<Rectangle>()
            {
                new Rectangle(591, 117, 8, 8)
            }
        },{ "8", new List<Rectangle>()
            {
                new Rectangle(600, 117, 8, 8)
            }
        },{ "9", new List<Rectangle>()
            {
                new Rectangle(609, 117, 8, 8)
            }
        },{ "A", new List<Rectangle>()
            {
                new Rectangle(618, 117, 8, 8)
            }
        },{ "Empty", new List<Rectangle>()
            {
                new Rectangle(627, 117, 8, 8)
            }
        },{ "Half", new List<Rectangle>()
            {
                new Rectangle(636, 117, 8, 8)
            }
        },{ "Full", new List<Rectangle>()
            {
                new Rectangle(645, 117, 8, 8)
            }
        },{ "Level", new List<Rectangle>()
            {
                new Rectangle(584, 1, 64, 40)
            }
        }
    };


        public ISprite CreateHUD()
        {
            return new Sprite(HUDSpriteSheet, SpriteFrames["HUD"]);
        }


        public ISprite CreateX()
        {
            return new Sprite(HUDSpriteSheet, SpriteFrames["X"]);
        }

        public ISprite Create0()
        {
            return new Sprite(HUDSpriteSheet, SpriteFrames["0"]);

        }

        public ISprite Create1()
        {
            return new Sprite(HUDSpriteSheet, SpriteFrames["1"]);
        }

        public ISprite Create2()
        {
            return new Sprite(HUDSpriteSheet, SpriteFrames["2"]);
        }

        public ISprite Create3()
        {
            return new Sprite(HUDSpriteSheet, SpriteFrames["3"]);
        }

        public ISprite Create4()
        {
            return new Sprite(HUDSpriteSheet, SpriteFrames["4"]);
        }

        public ISprite Create5()
        {
            return new Sprite(HUDSpriteSheet, SpriteFrames["5"]);

        }

        public ISprite Create6()
        {
            return new Sprite(HUDSpriteSheet, SpriteFrames["6"]);

        }

        public ISprite Create7()
        {
            return new Sprite(HUDSpriteSheet, SpriteFrames["7"]);

        }

        public ISprite Create8()
        {
            return new Sprite(HUDSpriteSheet, SpriteFrames["8"]);

        }

        public ISprite Create9()
        {
            return new Sprite(HUDSpriteSheet, SpriteFrames["9"]);

        }

        public ISprite CreateEmptyHP()
        {
            return new Sprite(HUDSpriteSheet, SpriteFrames["Empty"]);

        }

        public ISprite CreateHalfHP()
        {
            return new Sprite(HUDSpriteSheet, SpriteFrames["Half"]);

        }

        public ISprite CreateFullHP()
        {
            return new Sprite(HUDSpriteSheet, SpriteFrames["Full"]);

        }


        public ISprite CreateLevelCount()
        {
            return new Sprite(HUDSpriteSheet, SpriteFrames["Level"]);

        }

    }
}
