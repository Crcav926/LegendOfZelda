﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class NextItemComm : ICommand
    {
        Game1 myGame;
        int maxIndex;
        public NextItemComm(Game1 game)
        {
            myGame = game;
            maxIndex = SpriteItemData.ListLength();
        }
        public void Execute()
        {
            //this is no longer needed functionality
        }
    }
}