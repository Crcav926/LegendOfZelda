using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ObjectManagementExamples;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using LegendOfZelda.Collision;
using System.Xml;
using Microsoft.VisualBasic;
using System.Diagnostics;
using Microsoft.Xna.Framework.Audio;
using LegendOfZelda.Sounds;
using LegendOfZelda.HUD;
using System.ComponentModel.Design;

namespace LegendOfZelda
{
    public class Menu
    {
        private ISprite sprite;
        private ISprite gameModeButton;
        private ISprite adventureButton;
        private ISprite rogueButton;
        private ISprite textureButton;
        private ISprite defaultButton;
        private ISprite holidayButton;

        public Menu(Game1 game)
        {
            Debug.WriteLine("Created Menu");
            sprite = MenuSpriteFactory.Instance.CreateMenu();
            gameModeButton = MenuSpriteFactory.Instance.CreateGameMode();
            adventureButton = MenuSpriteFactory.Instance.CreateAdventure();
            rogueButton = MenuSpriteFactory.Instance.CreateRogue();
            textureButton = MenuSpriteFactory.Instance.CreateTexture();
            defaultButton = MenuSpriteFactory.Instance.CreateDefault();
            holidayButton = MenuSpriteFactory.Instance.CreateHoliday();


        }

        public void Draw(SpriteBatch s)
        {
            // Draw the menu if its up.
            if (Globals.inMenus)
            {
                //draw the background
                Rectangle destinationRectangle = new Rectangle(0, 0, Constants.OriginalWidth, Constants.OriginalHeight);
                sprite.Draw(s, destinationRectangle, Color.White);
                //draw the shading to show which one is selected
                Rectangle drGameMode = new Rectangle(380, 100, 142, 32);
                Rectangle drAdventure= new Rectangle(428, 140, 137, 58);
                Rectangle drRogue = new Rectangle(578, 140, 137, 58);
                Rectangle drTexture = new Rectangle(380, 220, 101, 37);
                Rectangle drDefault = new Rectangle(428, 260, 137, 58);
                Rectangle drHoliday = new Rectangle(578, 260, 137, 58);
                gameModeButton.Draw(s, drGameMode, Color.White);
                // this is totally data drivable or something but its literally 3:34 AM rn.
                if (Globals.mode == 0)
                {
                    adventureButton.Draw(s, drAdventure, Color.White);
                    rogueButton.Draw(s, drRogue, Color.Gray);
                }
                else
                {
                    adventureButton.Draw(s, drAdventure, Color.Gray);
                    rogueButton.Draw(s, drRogue, Color.White);
                }
                textureButton.Draw(s, drTexture, Color.White);
                if (Globals.tex == 0)
                {
                    defaultButton.Draw(s, drDefault, Color.White);
                    holidayButton.Draw(s, drHoliday, Color.Gray);
                }
                else
                {
                    defaultButton.Draw(s, drDefault, Color.Gray);
                    holidayButton.Draw(s, drHoliday, Color.White);
                }
            }
        }
        public void Update(GameTime gameTime)
        {
            //the menu doesn't super need to update other than the buttons changing.
        }
      
        public void Start()
        {
            Globals.inMenus = false;
        }
    }
}
