using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.Collision
{
    internal class collisionHandler
    {
        //when we figure out the .NET stuff it won't be a list anymore.
        //this is temporary
        List<Rectangle> collisions;
        public collisionHandler(detectionManager collisionDetector)
        {
            collisions = collisionDetector.getCollisions();
        }

        public void update()
        {
            //right now for every collision just something in the middle of screen
        }

    }
}
