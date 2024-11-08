using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.LinkItems
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
        public void addItem(IItems item)
        {
            //add item to inventory
            if (item is ClassItems)
            {
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

    }
}
