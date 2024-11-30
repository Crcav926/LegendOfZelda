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
    public class EndScreenSpriteFactory
    {
        // Allows us to get the texture, but can't set.
        public Texture2D MenuSpriteSheet { get; private set; }
        // More private Texture2Ds follow

        private static EndScreenSpriteFactory instance = new EndScreenSpriteFactory();

        public static EndScreenSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EndScreenSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            MenuSpriteSheet = content.Load<Texture2D>("ZeldaGameEndScreens");
        }


        private static Dictionary<String, List<Rectangle>> SpriteFrames = new Dictionary<String, List<Rectangle>>()
        {
           
            { "Quit", new List<Rectangle>()
                {
                    new Rectangle(26, 453, 128 ,53)
                }
            },
            { "Restart", new List<Rectangle>()
                {
                    new Rectangle(163, 453, 128, 53)
                }
            },
            { "GameOver", new List<Rectangle>()
                {
                    new Rectangle(0, 0, 767, 431)
                }
            },
            { "Win", new List<Rectangle>()
                {
                    new Rectangle(0, 518, 767, 437)
                }
            }
        };
        public ISprite CreateQuit()
        {
            return new Sprite(MenuSpriteSheet, SpriteFrames["Quit"]);
        }
        public ISprite CreateRestart()
        {
            return new Sprite(MenuSpriteSheet, SpriteFrames["Restart"]);
        }
        public ISprite CreateGameOver()
        {
            return new Sprite(MenuSpriteSheet, SpriteFrames["GameOver"]);
        }
        public ISprite CreateWin()
        {
            return new Sprite(MenuSpriteSheet, SpriteFrames["Win"]);
        }
    }
}
