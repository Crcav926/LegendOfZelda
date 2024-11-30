using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class collideWall: ICollideable
    {
        Rectangle theWall;
        public collideWall(Rectangle size)
        {
            theWall = size;
        }
        public Rectangle getHitbox()
        {
            return theWall;
        }
        public String getCollisionType()
        {
            return "Obstacle";
        }
        public void Update(GameTime gameTime)
        {
            //walls dont update for now.
        }

        public void Draw(SpriteBatch spritebatch)
        {
            //walls dont draw 
        }
    }
}
