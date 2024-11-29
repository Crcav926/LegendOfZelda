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
    internal class CommStart : ICommand
    {
        Game1 myGame;
        public CommStart(Game1 game) 
        {
            myGame = game;
        }
        public void Execute()
        {
            if (Globals.inMenus)
            {
                Debug.WriteLine("Started Game");
                //UnPause the game and make menu disappear.
                myGame.setPause(false);
                myGame.menu.Start();
                myGame.reloadTextures();
                SoundMachine.Instance.PlaySound("theme");
            }

           
        }
    }
}
