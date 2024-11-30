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
        private ISprite menuSprite;
        private ISprite gameOverSprite;
        private ISprite winSprite;
        private ISprite gameModeButton;
        private ISprite adventureButton;
        private ISprite rogueButton;
        private ISprite textureButton;
        private ISprite defaultButton;
        private ISprite holidayButton;
        private ISprite quitButton;
        private ISprite restartButton;

        public Menu(Game1 game)
        {
            Debug.WriteLine("Created Menu");
            menuSprite = MenuSpriteFactory.Instance.CreateMenu();
            gameOverSprite = EndScreenSpriteFactory.Instance.CreateGameOver();
            winSprite = EndScreenSpriteFactory.Instance.CreateWin();
            gameModeButton = MenuSpriteFactory.Instance.CreateGameMode();
            adventureButton = MenuSpriteFactory.Instance.CreateAdventure();
            rogueButton = MenuSpriteFactory.Instance.CreateRogue();
            textureButton = MenuSpriteFactory.Instance.CreateTexture();
            defaultButton = MenuSpriteFactory.Instance.CreateDefault();
            holidayButton = MenuSpriteFactory.Instance.CreateHoliday();
            quitButton = EndScreenSpriteFactory.Instance.CreateQuit();
            restartButton = EndScreenSpriteFactory.Instance.CreateRestart();

        }

        public void Draw(SpriteBatch s)
        {
            // Draw the menu if its up.
            if (Globals.inMenus)
            {
                if(Globals.menuType == 0)
                {
                    //draw the background
                    Rectangle destinationRectangle = new Rectangle(0, 0, Constants.OriginalWidth, Constants.OriginalHeight);
                    menuSprite.Draw(s, destinationRectangle, Color.White);
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
                else if(Globals.menuType == 1)
                {
                    //draw the background
                    Rectangle destinationRectangle = new Rectangle(0, 0, Constants.OriginalWidth, Constants.OriginalHeight);
                    if(Globals.winMode == 1)
                    {
                        winSprite.Draw(s, destinationRectangle, Color.White);
                    }
                    else
                    {
                        gameOverSprite.Draw(s, destinationRectangle, Color.White);
                    }
                    //draw the shading to show which one is selected
                    Rectangle drQuit = new Rectangle(200, 400, 128, 53);
                    Rectangle drRestart= new Rectangle(350, 400, 128, 53);
                    // this is totally data drivable or something but its literally 3:34 AM rn.
                    if (Globals.gameOverMode == 0)
                    {
                        restartButton.Draw(s, drRestart, Color.White);
                        quitButton.Draw(s, drQuit, Color.Gray);
                    }
                    else
                    {
                        restartButton.Draw(s, drRestart, Color.Gray);
                        quitButton.Draw(s, drQuit, Color.White);
                    }
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
            Globals.menuType = 0;
        }
    }
}
