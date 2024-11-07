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
        }
    };


        public ISprite CreateHUD()
        {
            return new Sprite(HUDSpriteSheet, SpriteFrames["HUD"]);
        }

    }
}
