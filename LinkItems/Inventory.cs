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
        public List<IItems> items;
        public List<IItems> weapons;
        public int numKeys;
        public bool hasMap;
        public Inventory() 
        { 
            items = new List<IItems>();
            weapons= new List<IItems>();
            numKeys = 0;
            hasMap = false;
        }
        public void addItem(IItems item)
        {
            //add item to inventory
            if (item is ClassItems)
            {
                items.Add(item);
                //Debug.WriteLine("Added to static items list");
            }
            else
            {
                weapons.Add(item);
               //Debug.WriteLine("added to weapons list");
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
    }
}
