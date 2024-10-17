using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command
{
    class PlayerTakeDamage : ICommand
    {
        private readonly ILinkState _link;

        public PlayerTakeDamage(ILinkState link) => _link = link;

        public void Execute()
        {
            _link.TakeDamage();
        }
    }
}
