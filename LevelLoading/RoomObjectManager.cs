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
        private List<ICollideable> blocks = LevelLoader.Instance.getBlocks();
        private List<ICollideable> movers = LevelLoader.Instance.getMovers();
        private Link link;
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
        public void Update()
        {
            if (movers != LevelLoader.Instance.getMovers())
            {
                movers = LevelLoader.Instance.getMovers();
                movers.Add(link);
            }
            if (blocks != LevelLoader.Instance.getBlocks())
            {
                blocks = LevelLoader.Instance.getBlocks();
                addWalls();
            }
        }
        public void addLink(Link link)
        {
            this.link = link;
        }

        private void addWalls()
        {
            // Walls are 100 pixels thick wide and 87 pixels thick tall
            // Dimensions of the rooms are 800 / 480

            Wall top = new Wall(new Microsoft.Xna.Framework.Rectangle(0, 0, 800, 87));
            Wall bot = new Wall(new Microsoft.Xna.Framework.Rectangle(0, 392, 800, 87));
            Wall left1 = new Wall(new Microsoft.Xna.Framework.Rectangle(0, 0, 100, 196));
            Wall left2 = new Wall(new Microsoft.Xna.Framework.Rectangle(0, 284, 100, 196));
            Wall right1 = new Wall(new Microsoft.Xna.Framework.Rectangle(700, 0, 100, 196));
            Wall right2 = new Wall(new Microsoft.Xna.Framework.Rectangle(700, 284, 100, 196));

            blocks.Add(top);
            blocks.Add(bot);
            blocks.Add(left1);
            blocks.Add(left2);
            blocks.Add(right1);
            blocks.Add(right2);

        }
    }
}
