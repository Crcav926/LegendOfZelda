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
        //for any items on the ground
        public List<ICollideable> staticItems = new List<ICollideable>();

        public Link link;
        private string room;
        private int DeathCounter = 0;
        public static RoomObjectManager Instance
        {
            get
            {
                return instance;
            }
        }
        private Dictionary<int, string> ClassB = new Dictionary<int, string>()
        {
            {1, "Bomb"},
            {2, "OrangeRupee"},
            {3, "Clock"},
            {4, "OrangeRupee"},
            {5, "Heart"},
            {6, "Bomb"},
            {7, "OrangeRupee"},
            {8, "Bomb"},
            {9, "Heart"},
            {0, "Heart"},
        };

        private Dictionary<int, string> ClassC = new Dictionary<int, string>()
        {
            {1, "OrangeRupee"},
            {2, "Heart"},
            {3, "OrangeRupee"},
            {4, "BlueRupee"},
            {5, "Heart"},
            {6, "Clock"},
            {7, "OrangeRupee"},
            {8, "OrangeRupee"},
            {9, "OrangeRupee"},
            {0, "BlueRupee"},
        };

        private Dictionary<int, string> ClassD = new Dictionary<int, string>()
        {
            {1, "Heart"},
            {2, "Unknown"},
            {3, "OrangeRupee"},
            {4, "Heart"},
            {5, "Unknown"},
            {6, "Heart"},
            {7, "Heart"},
            {8, "Heart"},
            {9, "OrangeRupee"},
            {0, "Heart"},
        };

        public String GetItemName (Type Etype)
        {
            String result;
            if (Etype == typeof(Goriya))
            {
                result = ClassB[DeathCounter];
            } else if (Etype == typeof(Stalfol) || Etype == typeof(Zol) || Etype == typeof(Wallmaster))
            {
                result = ClassC[DeathCounter];
            } else
            {
                result = ClassD[DeathCounter];
            }
            return result;
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
            //This is super scuffed because sometimes (especially on start up) blocks is null.
            List<ICollideable> standStills = new List<ICollideable>();
            if (blocks != null)
            {
                foreach (ICollideable block in blocks)
                {
                    standStills.Add(block);
                }
            }
            foreach (ICollideable item in staticItems)
            {
                standStills.Add(item);
            }
            return standStills;
        }
        public List<ICollideable> getGroundItems()
        {
            return staticItems;
        }
        public void Update()
        {
            // TODO: Check if the room changed instead of if they're the same list, in case we want to remove enemies (will add in morning)
            if (movers != LevelLoader.Instance.getMovers())
            {
                movers = LevelLoader.Instance.getMovers();
                movers.Add(link);
                foreach (IItems item in link.inventory.items)
                {
                    movers.Add((ICollideable)item);
                }
            }
            if (blocks != LevelLoader.Instance.getBlocks())
            {
                blocks = LevelLoader.Instance.getBlocks();
                addWalls();
            }
            for(int i = 0; i < movers.Count; i++)
            {
                if(movers[i] is IEnemy)
                {
                    IEnemy enemy1 = (IEnemy)movers[i];
                    if (!enemy1.isAlive())
                    {
                        if (DeathCounter < 9)
                        {
                            DeathCounter++;
                        } else
                        {
                            DeathCounter  = 0;
                        }
                        movers.Remove(movers[i]);
                    }
                }
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
