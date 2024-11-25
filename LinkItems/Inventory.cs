using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{

    
    public class Inventory
    {

        private static Inventory instance = new Inventory();

        public static Inventory Instance
        {
            get
            {
                return instance;
            }
        }

        public List<IItems> items;
        public List<IItems> weapons;
        public int numKeys;
        public bool hasMap;
        public int coins;
        public int numBombs;
        public IItems key1Item;
        public IItems key2Item;
    
        public Inventory() 
        { 
            items = new List<IItems>();
            weapons= new List<IItems>();
            
            numKeys = 0;
            hasMap = false;
            coins= 0;
            numBombs = 0;
        }
        public void UpdateInventory()
        {
            key1Item = weapons[0];
            if (weapons.Count > 1)
            {
                key2Item = weapons[1];
            }
        }
        public void rotateItems()
        {
            foreach (IItems weapon in weapons)
            {
                //Debug.WriteLine($"In inventory {weapon.ToString}");
            }
            if (weapons.Count > 1)
            {
                List<IItems> temp  = new List<IItems>();
                temp.Add(weapons[weapons.Count - 1]);
               
                for (int i = 0; i < weapons.Count-1; i++)
                {
                    temp.Add(weapons[i]);
                }
                weapons = temp;
            }
            else
            {
                Debug.WriteLine("Cannot rotate, you only have 1 item!");
            }
        }
        public void addItem(IItems item)
        {
            //add item to inventory
            //All of the ground items are class items because of how the parser,xml, and collsion works.
            if (item is ClassItems)
            {
                ClassItems temp = (ClassItems)item;
                String itemName = temp.getItemType();
                //these are currently the 2 weapons we can pick up.
                if (itemName == "CreateBoomerangSprite")
                {
                    weapons.Add(Link.Instance.boomerang);
                }
                if (itemName == "Bow")
                {
                    weapons.Add(Link.Instance.arrow);
                }
                items.Add(item);
                Debug.WriteLine("Added to static items list");
            }
            else
            {
                if (key1Item == null)
                {
                    key1Item = item;
                    weapons.Add(item);
                    Debug.WriteLine("added to key1");
                } else if (key2Item == null) {
                    key2Item = item;
                    weapons.Add(item);
                    Debug.WriteLine("Added to key2");
                } else
                {
                    weapons.Add(item);
                    Debug.WriteLine("added to weapons list");
                }
                
            }
            //Prints inventory for debugging
            //Debug.WriteLine($"Current inventory is");
            foreach (IItems item2 in items)
            {
                if (item2 is not ClassItems)
                {
                    //Debug.WriteLine($"{item2.ToString()}");
                }
                else
                {
                    ClassItems item3 = (ClassItems)item2;
                   // Debug.WriteLine($"{item3.getItemType()}");
                }
            }
        }

        public IItems removeItem(IItems item)
        {
            IItems removedItem = item;
            if (weapons.Remove(item))
            {
                Debug.WriteLine("Returned " + removedItem.ToString());
                return removedItem;
            }


            return null;
        }

        public void addCoins(int amount)
        {
            coins = coins + amount;
        }
        public void setMap(bool mapStatus)
        {
            //when miku picks up a map set to true and maybe set to false on death?
            hasMap = mapStatus;
        }

        public int getNumKeys() {
            //open the door if keys>0
            return numKeys; 
        }
        public void addKey()
        {
            //call when miku picks up a key
            numKeys++;
        }
        public void removeKey()
        {
            // call when miku uses key on a locked door
            numKeys--;
        }

        public void addBomb()
        {
            numBombs++;
        }

        //for reset
        public void Clear()
        {
            items.Clear();
            weapons.Clear();
            numKeys = 0;
            hasMap = false;
            coins = 0;
            numBombs = 0;
            key1Item = null;
            key2Item = null;
        }

    }
}
