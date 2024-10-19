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
        private string room;
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
            this.room = LevelLoader.Instance.getRoom();
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
            // TODO: Check if the room changed instead of if they're the same list, in case we want to remove enemies (will add in morning)
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

            Wall top1 = new Wall(new Microsoft.Xna.Framework.Rectangle(0, 0, 350, 87));
            Wall topMiddle = new Wall(new Microsoft.Xna.Framework.Rectangle(350, 0, 100, 80));
            Wall top2 = new Wall(new Microsoft.Xna.Framework.Rectangle(450, 0, 350, 87));
            Wall bot1 = new Wall(new Microsoft.Xna.Framework.Rectangle(0, 392, 350, 87));
            Wall botMiddle = new Wall(new Microsoft.Xna.Framework.Rectangle(350, 392, 100, 80));
            Wall bot2 = new Wall(new Microsoft.Xna.Framework.Rectangle(450, 392, 350, 87));
            Wall left1 = new Wall(new Microsoft.Xna.Framework.Rectangle(0, 0, 100, 196));
            Wall leftMiddle = new Wall(new Microsoft.Xna.Framework.Rectangle(0, 196, 90, 88));
            Wall left2 = new Wall(new Microsoft.Xna.Framework.Rectangle(0, 284, 100, 196));
            Wall right1 = new Wall(new Microsoft.Xna.Framework.Rectangle(700, 0, 100, 196));
            Wall rightMiddle = new Wall(new Microsoft.Xna.Framework.Rectangle(700, 196, 90, 88));
            Wall right2 = new Wall(new Microsoft.Xna.Framework.Rectangle(700, 284, 100, 196));

            blocks.Add(top1);
            blocks.Add(topMiddle);
            blocks.Add(top2);
            blocks.Add(bot1);
            blocks.Add(botMiddle);
            blocks.Add(bot2);
            blocks.Add(left1);
            blocks.Add(leftMiddle);
            blocks.Add(left2);
            blocks.Add(right1);
            blocks.Add(rightMiddle);
            blocks.Add(right2);

        }
    }
}
