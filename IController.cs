using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda
{
    internal interface IController
    {
        public void Update();

        public void RegisterCommand(Keys key, ICommand command);
    }
}
