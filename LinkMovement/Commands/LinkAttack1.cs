using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace LegendOfZelda.HUD
{
    public class LinkAttack1 : ICommand
    {
        Link link;
        Dictionary<string, Action> attackActions;
        Inventory inven;
        Game1 myGame;
        PausedHUD pauseHUD;
        public LinkAttack1(Game1 game)
        {
            myGame = game;
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
            if (!myGame.paused)
            {
                if (inven.key1Item != null)
                {
                    string key = inven.key1Item.ToString();
                    //Debug.WriteLine("KEY 1 ITEM IS " + inven.key1Item);


                    if (attackActions.ContainsKey(key))
                    {
                        // Invokes the player attack based on key.
                        attackActions[key].Invoke();
                        attackActions[key].Invoke();
                    }
                }
            } else
            {
                inven.swap();
            }

        }
    }
}
