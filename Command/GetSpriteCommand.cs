using LegendOfZelda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PreviousSpriteCommand : ICommand
{
    private Game1 game;

    public PreviousSpriteCommand(Game1 game)
    {
        this.game = game;
    }

    public void Execute()
    {
        game.currentSprite--;
        if (game.currentSprite < 0)
        {
            game.currentSprite = game.sprites.Count - 1; // Loop back to the last sprite
        }
    }
}

public class NextSpriteCommand : ICommand
{
    private Game1 game;

    public NextSpriteCommand(Game1 game)
    {
        this.game = game;
    }

    public void Execute()
    {
        game.currentSprite++;
        if (game.currentSprite >= game.sprites.Count)
        {
            game.currentSprite = 0; // Loop back to the first sprite
        }
    }
}