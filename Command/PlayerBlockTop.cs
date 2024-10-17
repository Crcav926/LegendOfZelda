using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command
{
    class PlayerBlockTop : ICommand
    {
        private readonly Link _link;

        public PlayerBlockTop(Link link) => _link = link;

        public void Execute()
        {
            _link.position = new Vector2(_link.position.X, _link.position.Y + 1);
        }
    }
}