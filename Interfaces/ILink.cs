using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public interface ILink
    {

        /*
         * Updates Link to move up
         */
        public void Move(Vector2 direction);
    }
}
