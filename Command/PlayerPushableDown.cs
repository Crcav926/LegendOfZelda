﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using LegendOfZelda.Sounds;

namespace LegendOfZelda.Command
{
    class PlayerPushableDown : ICommand
    {
        private readonly Link _link;
        private Block _block;
        public PlayerPushableDown(Link link, Block block)
        {
            _link = link;
            _block = block;
        }

        public void Execute()
        {
            SoundMachine.Instance.GetSound("moveBlock").Play();
            Debug.WriteLine("Collided with pusable on the bottom");
            _block.moveBlock(new Vector2(0, 1));
        }
    }
}