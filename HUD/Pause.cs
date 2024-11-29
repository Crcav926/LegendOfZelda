using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ObjectManagementExamples;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace LegendOfZelda.HUD {
    public class PausedHUD
{
        ISprite pausedInventory;
        private HUDSpriteFactory hudSF;
        public PausedHUD()
        {
            hudSF = HUDSpriteFactory.Instance;
            pausedInventory = hudSF.CreatePauseInventory();
        }

    public void Update(GameTime gameTime)
    {

    }
    public void Draw(SpriteBatch spriteBatch)
    {
        pausedInventory.Draw(spriteBatch,new Rectangle(0,-Constants.HUDHeight,Constants.PausedInventoryWidth,Constants.PausedInventoryHeight), Color.White);

    }
}
}
