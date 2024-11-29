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
    public class MenuSpriteFactory
    {
        // Allows us to get the texture, but can't set.
        public Texture2D MenuSpriteSheet { get; private set; }
        // More private Texture2Ds follow

        private static MenuSpriteFactory instance = new MenuSpriteFactory();

        public static MenuSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private MenuSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            MenuSpriteSheet = content.Load<Texture2D>("menuSheet");
        }


        private static Dictionary<String, List<Rectangle>> SpriteFrames = new Dictionary<String, List<Rectangle>>()
        {
            { "Menu", new List<Rectangle>()
                {
                    new Rectangle(0, 0, Constants.MenuWidth, Constants.MenuHeight)
                }
            },
            { "GameMode", new List<Rectangle>()
                {
                    new Rectangle(7, 437, 142,32)
                }
            },
            { "Adventure", new List<Rectangle>()
                {
                    new Rectangle(162,437,137,58 )
                }
            },
            { "Rogue", new List<Rectangle>()
                {
                    new Rectangle(306,437, 137,58)
                }
            },
            { "Texture", new List<Rectangle>()
                {
                    new Rectangle(9 ,475,101,37 )
                }
            },
            { "Default", new List<Rectangle>()
                {
                    new Rectangle(161,503, 137,58)
                }
            },
            { "Holiday", new List<Rectangle>()
                {
                    new Rectangle(306,503, 137,58)
                }
            }
        };


        public ISprite CreateMenu()
        {
            return new Sprite(MenuSpriteSheet, SpriteFrames["Menu"]);
        }
        public ISprite CreateGameMode()
        {
            return new Sprite(MenuSpriteSheet, SpriteFrames["GameMode"]);
        }
        public ISprite CreateAdventure()
        {
            return new Sprite(MenuSpriteSheet, SpriteFrames["Adventure"]);
        }
        public ISprite CreateRogue()
        {
            return new Sprite(MenuSpriteSheet, SpriteFrames["Rogue"]);
        }
        public ISprite CreateTexture()
        {
            return new Sprite(MenuSpriteSheet, SpriteFrames["Texture"]);
        }
        public ISprite CreateDefault()
        {
            return new Sprite(MenuSpriteSheet, SpriteFrames["Default"]);
        }
        public ISprite CreateHoliday()
        {
            return new Sprite(MenuSpriteSheet, SpriteFrames["Holiday"]);
        }


    }
}
