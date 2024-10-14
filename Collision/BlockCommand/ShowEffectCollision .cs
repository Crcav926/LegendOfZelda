using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LegendOfZelda
{
    public class ShowEffectCollision : ICommand
    {
        private readonly CollisionContext context;

        public ShowEffectCollision(CollisionContext context)
        {
            this.context = context;
        }

        public void Execute()
        //draw something out here
        {
            Console.WriteLine("Effect shown at collision area: " + context.CollisionRect);
        }
    }
}