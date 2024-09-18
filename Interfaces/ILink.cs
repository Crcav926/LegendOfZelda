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
        public void MoveUp();
        /*
         * Updates Link to move down
         */
        public void MoveDown();
        /*
        * Updates Link to move left
        */
        public void MoveLeft();
        /*
         * Updates Link to move right
         */
        public void MoveRight();
    }
}
