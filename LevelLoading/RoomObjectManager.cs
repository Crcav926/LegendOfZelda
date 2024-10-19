using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    internal class RoomObjectManager
    {
        private static RoomObjectManager instance = new RoomObjectManager();
        private List<ICollideable> blocks;
        private List<ICollideable> movers;
        public static RoomObjectManager Instance
        {
            get
            {
                return instance;
            }
        }
        public RoomObjectManager() 
        {
            movers = LevelLoader.Instance.getMovers();
            blocks = LevelLoader.Instance.getBlocks();
        }
        public List<ICollideable> getMovers()
        {
            return movers;
        }
        public List<ICollideable> getStandStills()
        {
            return blocks;
        }
        public void Update(GameTime gameTime)
        {
            movers = LevelLoader.Instance.getMovers();
            blocks = LevelLoader.Instance.getBlocks();
        }
    }
}
