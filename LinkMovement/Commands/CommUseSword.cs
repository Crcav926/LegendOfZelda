﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.LinkItems
{
    internal class CommUseSword : ICommand
    {
            Link LinkCharacter;
            public CommUseSword(Link link)
            {
                LinkCharacter = link;
            }
            public void Execute()
            {
                LinkCharacter.SwordAttack();
                LinkCharacter.SwordAttack();
            }
    }
}