using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ObjectManagementExamples;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public interface ICollideable
    {
        //this interface is mostly just so that I can put any collideable object in the collision struct

        public Rectangle getHitbox();

        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch spriteBatch);


    }
}
