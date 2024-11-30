using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Vector2 multiplier = new Vector2(Constants.OriginalWidth, Constants.OriginalHeight);
        public Room(List<ICollideable> statics, List<ICollideable> movers, String RoomName, Vector2 offSet) 
        {
            this.statics = statics;
            this.movers = movers;
            name = RoomName;
            this.offSet = offSet;
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
        public String getRoomName()
        {
            return name;
        }
        public Vector2 GetOffSet()
        {
            return offSet;
        }
        public void AddDoor(int side)
        {
            statics.Add(new Door(Constants.DoorAreas[side] + (offSet * multiplier), DoorData.GetDoorPlacement(side), name, offSet, false));
        }
        public void AddWall(int side)
        {
            statics.Add(new Door(Constants.DoorAreas[side] + (offSet * multiplier), DoorData.GetWallPlacement(side), name, offSet, true));
        }
        public void AddLink()
        {
            movers.Add(Link.Instance);
        }
    }
}
