using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ObjectManagementExamples;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace LegendOfZelda.HUD
{
    public class HUDMap
    {

        private HUDSpriteFactory hudSF;
        ISprite mapSprite;
        ISprite levelCountSprite;
        private ISprite room1Sprite;
        private ISprite room2Sprite;
        //private ISprite room2Sprite;
        //private ISprite room2Sprite;
        //private ISprite room2Sprite;
        //private ISprite room2Sprite;
        //private ISprite room2Sprite;
        //private ISprite room2Sprite;
        //private ISprite room2Sprite;
        //private ISprite room2Sprite;
        //private ISprite room2Sprite;
        //private ISprite room2Sprite;
        //private ISprite room2Sprite;
        //private ISprite room2Sprite;
        //private ISprite room2Sprite;
        //private ISprite room2Sprite;
        //private ISprite room2Sprite;
        //private ISprite room2Sprite;
        //private ISprite room2Sprite;
        //private ISprite room2Sprite;
        //private ISprite room2Sprite;

        private Link link;
        public HUDMap()
        {
            hudSF = HUDSpriteFactory.Instance;
            // Hard coded 1 as we are only creating level 1.
            // Can adjust if ever considering the full game.
            levelCountSprite = hudSF.Create1();

            mapSprite = hudSF.CreateLevelCount();
            room1Sprite = hudSF.CreateHUDMapBlock();
            room2Sprite = hudSF.CreateHUDMapBlock();

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mapSprite.Draw(spriteBatch, new Rectangle(50,-105,200,88), Color.White);
            levelCountSprite.Draw(spriteBatch, new Rectangle(200,-105,25,17), Color.White);
            room1Sprite.Draw(spriteBatch, new Rectangle(10, 10, 70, 30), Color.White);

        }
    }
}
