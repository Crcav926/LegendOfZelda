using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class Room
    {
        private List<ICollideable> statics;
        private List<ICollideable> movers;
        private String name;
        public Room(List<ICollideable> statics, List<ICollideable> movers, String RoomName) 
        {
            this.statics = statics;
            this.movers = movers;
            name = RoomName;
        }
        public void Update(GameTime gameTime)
        {
            foreach (ICollideable mover in movers)
            {
                mover.Update(gameTime);
            }
        }
    }
}
