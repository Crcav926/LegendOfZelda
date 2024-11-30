using LegendOfZelda.HUD;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace LegendOfZelda.LinkMovement
{
    internal class CommLinkMove : ICommand
    {
        Link link;
        Vector2 linkDirection;
        PausedHUD pausedHUD;
        Game1 myGame;
        public CommLinkMove(Game1 game, Link link, Vector2 direction)
        {
            this.link = link;
            linkDirection = direction;
            myGame = game;
            pausedHUD = PausedHUD.Instance;
        }
        public void Execute()
        {
            if (!myGame.paused)
            {
                //TODO: remove this, get this check out of CommLinkMove
                if (this.link.currentHealth != 0)
                {
                    this.link.setState(new LinkMoveState(this.link));
                    this.link.Move(linkDirection);
                }
            } else
            {
                if (linkDirection.X < 0 && pausedHUD.weaponIndex > 0)
                {
                    pausedHUD.goLeft();
                    Debug.WriteLine("Go Left: " + pausedHUD.weaponIndex);
                }
                if (linkDirection.X > 0 && pausedHUD.weaponIndex < 3)
                {
                    pausedHUD.goRight();
                    Debug.WriteLine("Go Right: " + pausedHUD.weaponIndex);
                }
                
            }

        }



    }
}
