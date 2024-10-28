using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LegendOfZelda.Command
{
    class PlayerStatItem : ICommand
    {
        private readonly Link _link;
        private ClassItems item;
        public PlayerStatItem(Link link, ClassItems items)
        {
            _link = link;
            item = items;
        }

        public void Execute()
        {
            Debug.WriteLine("Miku picked up an Item!");
           
            //add the item to link's inventory and delete it off the screen
            if (item.getItemType() == "key")
            {
                _link.inventory.addKey();
            }
            if (item.getItemType() == "map")
            {
                _link.inventory.setMap(true);
            }
            //I'm still adding the keys to the inventory because they should probably show up in the HUD?
            Debug.WriteLine($"Added {item.getItemType()} to inventory");
            _link.inventory.addItem(item);

            //doing both to be safe
            item.exists = false;
            RoomObjectManager.Instance.staticItems.Remove(item);
        }
    }
}