﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command
{
    class PlayerBlockBottom : ICommand
    {
        private readonly Link _link;

        public PlayerBlockBottom(Link link) => _link = link;

        public void Execute()
        {
            //move link down one b/c he hit the bottom of a block
            _link.position = new Vector2(_link.position.X, _link.position.Y + Constants.CollisionPushDistance);
        }
    }
}