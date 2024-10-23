using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.LinkItems
{
    public class Inventory
    {
        public List<IItems> items;
        public int numKeys;
        public bool hasMap;
        public Inventory() 
        { 
            items = new List<IItems>();
            numKeys = 0;
            hasMap = false;
        }
        public void addItem(IItems item)
        {
            //add item to inventory
            items.Add(item);
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
