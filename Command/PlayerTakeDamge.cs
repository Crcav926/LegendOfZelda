using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command
{
    class PlayerTakeDamage : ICommand
    {
        private readonly Link _link;

        public PlayerTakeDamage(Link link) => _link = link;

        public void Execute()
        {
            _link.TakeDamage();
        }
    }
}
