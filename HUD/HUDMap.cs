using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ObjectManagementExamples;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace LegendOfZelda.HUD
{
    public class HUDMap
    {

        private static HUDMap instance = new HUDMap();

        public static HUDMap Instance
        {
            get
            {
                return instance;
            }
        }

        private HUDSpriteFactory hudSF;
        private ISprite mapSprite;
        private ISprite levelCountSprite;
        private ISprite dot;
        public Vector2 miniMapPos;

        public HUDMap()
        {
            miniMapPos = new Vector2(Constants.miniMapStartX, Constants.miniMapStartY);
            hudSF = HUDSpriteFactory.Instance;
            // Hard coded 1 as we are only creating level 1.
            // Can adjust if ever considering the full game.
            levelCountSprite = hudSF.Create1();

            mapSprite = hudSF.CreateLevelCount();
            dot = hudSF.CreateDot();

        }
        public void Reset()
        {
            miniMapPos = new Vector2(Constants.miniMapStartX, Constants.miniMapStartY);
        }
        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch , int pausedOffset)
        {
            if (Globals.hasMap)
            {
                mapSprite.Draw(spriteBatch, new Rectangle(Constants.HUDMapX, Constants.HUDMapY + pausedOffset, Constants.HUDMapDimensionX, Constants.HUDMapDimensionY), Color.White);
                levelCountSprite.Draw(spriteBatch, new Rectangle(Constants.HUDMapLevelX, Constants.HUDMapLevelY + pausedOffset, Constants.HUDMapLevelDimensionX, Constants.HUDMapLevelDimensionY), Color.White);
                dot.Draw(spriteBatch, new Rectangle((int)miniMapPos.X, (int)miniMapPos.Y + pausedOffset, Constants.dotSize, Constants.dotSize), Color.White);
                //room1Sprite.Draw(spriteBatch, new Rectangle(10, 10, 70, 30), Color.White);
            }
        }
    }
}
