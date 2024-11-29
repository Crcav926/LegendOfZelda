using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using LegendOfZelda.Sounds;

namespace LegendOfZelda
{
    internal class RoomObjectManager
    {
        private static RoomObjectManager instance = new RoomObjectManager();
        //temporary public for testing purposes
        public List<ICollideable> blocks = LevelLoader.Instance.getBlocks();
        private List<ICollideable> movers = LevelLoader.Instance.getMovers();
        //for any items on the ground
        public List<ICollideable> staticItems = new List<ICollideable>();
        public List<ICollideable> projectiles = new List<ICollideable>();
        public Link link;
        private string room;
        //for the drop table
        private int DeathCounter = 0;
        public Room currentRoom = new Room(LevelLoader.Instance.getBlocks(), LevelLoader.Instance.getMovers(), "testRoom");
        public int Localcounter = 0;


        public static RoomObjectManager Instance
        {
            get
            {
                return instance;
            }
        }

        //we keep this here because the death counter is kept here.
        //Also because since this is a singleton its easier to access this method.
        public String GetItemName (char c)
        {
            (int, char) key = (DeathCounter, c);
            Debug.WriteLine($"Death counter is {DeathCounter}");
            return DropDictionary.GetDropName(key);
        }

        // Called everytime to see if you want to be dropping a key on last enemy death
        public String GetKey()
        {
            string roomNumber = LevelLoader.Instance.room;
            Debug.WriteLine($"Checking if its a drop room, room: {roomNumber}");
            // Attempt to retrieve the key only if it is in one of the specified rooms.

                (string, int) key = (roomNumber, Localcounter);
                Debug.WriteLine($"Local counter is {Localcounter}");
                return DropDictionary.GetDropKey(key);
          
        }


        public RoomObjectManager() 
        {
            // CHANGE THIS TO == THE MOVERS AND BLOCKS OF THE CURRENT ROOM
            movers = LevelLoader.Instance.getMovers();
            blocks = LevelLoader.Instance.getBlocks();
            this.room = LevelLoader.Instance.getRoom();
        }
        public List<ICollideable> getMovers()
        {
            // NOTE TO SELF - DO NOT CHANGE THIS CLASS IF POSSIBLE
            return movers;
            //foreach (ICollideable p in projectiles)
            //{
                //nevermind holy frick no frames
                //moveList.Add(p);
            //}
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
            currentRoom = LevelLoader.Instance.getCurrentRoom();
            // TODO: Check if the room changed instead of if they're the same list, in case we want to remove enemies (will add in morning)
            if (movers != currentRoom.getMovers())
            {
                movers = currentRoom.getMovers();
                foreach (ICollideable item in link.inventory.weapons)
                {
                    movers.Add((ICollideable)item);
                }
                movers.Add((ICollideable)Link.Instance.sword);
            }
            if (blocks != currentRoom.getStatics())
            {
                blocks = currentRoom.getStatics();
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
                        //update the local death counter
                        Localcounter++;

                        movers.Remove(movers[i]);
                    }
                }
            }
        }
        public void addLink(Link link)
        {
            this.link = link;
        }
        public void addProjectile(ICollideable proj)
        {
            projectiles.Add(proj);
        }
        public void addProjectileToMovers()
        {
            foreach(ICollideable test in projectiles)
            {
                movers.Add(test);
            }
            projectiles.Clear();
        }
        public void removeProjectileFromMovers(ICollideable proj)
        {
            movers.Remove(proj);
        }
        private void addWalls()
        {
            // Walls are 100 pixels thick wide and 87 pixels thick tall
            // Dimensions of the rooms are 800 / 480
            // Wall topMiddle = new Wall(new Microsoft.Xna.Framework.Rectangle(350, 0, 100, 80));
            // Wall botMiddle = new Wall(new Microsoft.Xna.Framework.Rectangle(350, 392, 100, 80));
            // Wall leftMiddle = new Wall(new Microsoft.Xna.Framework.Rectangle(0, 196, 90, 88));
            // Wall rightMiddle = new Wall(new Microsoft.Xna.Framework.Rectangle(700, 196, 90, 88));

        }
        //for reset
        public void Clear()
        {
            staticItems.Clear();
            movers.Clear();
        }
    }
}
