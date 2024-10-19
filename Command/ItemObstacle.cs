using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command
{
    class ItemObstacle : ICommand
    {
        private readonly IItems item;

        public ItemObstacle(IItems i) => item = i;

        public void Execute()
        {
            //take damage
            //command should be like item.goSplat();
        }
    }
}