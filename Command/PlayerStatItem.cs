using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda.Command
{
    class PlayerStatItem : ICommand
    {
        private readonly Link _link;
        private IItems item;
        public PlayerStatItem(Link link, IItems items)
        {
            _link = link;
            item = items;
        }

        public void Execute()
        {
            // cast to access the getItemType
            ClassItems statItem = (ClassItems)item;
            //add the item to link's inventory and delete it off the screen
            if (statItem.getItemType() == "key")
            {
                _link.inventory.addKey();
            }
            if (statItem.getItemType() == "map")
            {
                _link.inventory.setMap(true);
            }
            //I'm still adding the keys to the inventory because they should probably show up in the HUD?
            _link.inventory.addItem(item);
            item.exists = false;
        }
    }
}