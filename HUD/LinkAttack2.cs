using System.Collections.Generic;
using System;
using LegendOfZelda.LinkItems;
using System.Diagnostics;

namespace LegendOfZelda.HUD
{
    public class LinkAttack2 : ICommand
    {
        Link link;
        Dictionary<string, Action> attackActions;
        Inventory inven;
        public LinkAttack2()
        {
            inven = Inventory.Instance;
            link = Link.Instance;
            attackActions = new Dictionary<string, Action>
        {
            { "LegendOfZelda.Boomerang", link.BoomerangAttack },
            { "LegendOfZelda.Sword", link.SwordAttack },
            { "LegendOfZelda.Fire", link.FireAttack } ,
            { "LegendOfZelda.Bomb", link.BombAttack },
            { "LegendOfZelda.Arrow", link.ArrowAttack }
        };
        }



        public void Execute()
        {
            // HOTFIX - Call attack twice, one to change the state and one to throw the boomerang
            // Formerly would just change states than instantly change back
            string key = inven.key2Item.ToString();
            Debug.WriteLine("KEY 2 ITEM IS " + inven.key1Item);

            
            if (inven.key2Item != null && attackActions.ContainsKey(key))
            {
                // Invokes the player attack based on key.
                attackActions[key].Invoke();
                attackActions[key].Invoke();
            }
            else
            {
                Debug.WriteLine($"Attack '{key}' not found or inventory item is missing.");
            }
        }
    }
}
