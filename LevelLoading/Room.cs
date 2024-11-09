using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    public class Room
    {
        private List<ICollideable> statics = new List<ICollideable>();
        private List<ICollideable> movers = new List<ICollideable>();
        private String name;
        private Vector2 offSet;
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
        public void Draw(SpriteBatch s)
        {
            foreach (ICollideable block in statics)
            {
                block.Draw(s);
            }
        }
        public List<ICollideable> getMovers()
        {
            return movers;
        }
        public List<ICollideable> getStatics()
        {
            return statics;
        }
    }
}
