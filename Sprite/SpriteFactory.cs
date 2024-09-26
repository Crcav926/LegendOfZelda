using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

public class SpriteFactory
{
    private SpriteBatch spriteBatch;
    private Texture2D texture;

    public SpriteFactory(SpriteBatch spriteBatch, Texture2D texture)
    {
        this.spriteBatch = spriteBatch;
        this.texture = texture;
    }

    // Load the Gel sprite
    public IEnemy CreateGel()
    {
        List<Rectangle> gelFrames = new List<Rectangle>
        {
            new Rectangle(1, 11, 8, 15),
            new Rectangle(10, 11, 8, 15),
            new Rectangle(19, 11, 8, 15),
            new Rectangle(28, 11, 8, 15),
            new Rectangle(37, 11, 8, 15),
            new Rectangle(46, 11, 8, 15),
            new Rectangle(55, 11, 8, 15),
            new Rectangle(64, 11, 8, 15),
            new Rectangle(1, 28, 8, 15),
            new Rectangle(10, 28, 8, 15),
            new Rectangle(19, 28, 8, 15),
            new Rectangle(28, 28, 8, 15),
            new Rectangle(55, 28, 8, 15),
            new Rectangle(64, 28, 8, 15)
        };
        return new Gel(spriteBatch, new Vector2(300, 200), texture, gelFrames);
    }

    // Load the Zol sprite
    public IEnemy CreateZol()
    {
        List<Rectangle> zolFrames = new List<Rectangle>
        {
            new Rectangle(77, 11, 16, 16),
            new Rectangle(94, 11, 16, 16),
            new Rectangle(111, 11, 16, 16),
            new Rectangle(128, 11, 16, 16),
            new Rectangle(145, 11, 16, 16),
            new Rectangle(162, 11, 16, 16),
            new Rectangle(77, 28, 16, 16),
            new Rectangle(94, 28, 16, 16),
            new Rectangle(145, 28, 16, 16),
            new Rectangle(162, 28, 16, 16)
        };
        return new Zol(spriteBatch, new Vector2(300, 200), texture, zolFrames);
    }

    // Load the Keese sprite
    public IEnemy CreateKeese()
    {
        List<Rectangle> keeseFrames = new List<Rectangle>
        {
            new Rectangle(183, 11, 16, 16),
            new Rectangle(200, 11, 16, 16),
            new Rectangle(183, 28, 16, 16),
            new Rectangle(200, 28, 16, 16)
        };
        return new Keese(spriteBatch, new Vector2(300, 200), texture, keeseFrames);
    }

    // Load the Stalfol sprite
    public IEnemy CreateStalfol()
    {
        List<Rectangle> stalfolFrames = new List<Rectangle>
        {
            new Rectangle(1, 59, 16, 16)
        };
        List<Rectangle> swordFrames = new List<Rectangle>
        {
            new Rectangle(18, 59, 8, 16),
            new Rectangle(54, 59, 16, 16),
            new Rectangle(27, 59, 8, 16),
            new Rectangle(72, 59, 16, 16),
            new Rectangle(36, 59, 8, 16),
            new Rectangle(88, 59, 16, 16),
            new Rectangle(45, 59, 8, 16),
            new Rectangle(104, 59, 16, 16)
        };
        return new Stalfol(spriteBatch, new Vector2(300, 200), texture, stalfolFrames, swordFrames);
    }


    public IEnemy CreateGoriya()
    {
        List<Rectangle> upFrames = new List<Rectangle>
    {
        new Rectangle(238, 11, 16, 16),
        new Rectangle(238, 28, 16, 16),
    };

        List<Rectangle> downFrames = new List<Rectangle>
    {
         new Rectangle(221, 11, 16, 16),
         new Rectangle(221, 28, 16, 16),
    };

        List<Rectangle> leftFrames = new List<Rectangle>
    {
        new Rectangle(370, 146, 16, 16),
        new Rectangle(370, 163, 16, 16),
        new Rectangle(387, 146, 16, 16),
        new Rectangle(387, 163, 16, 16),
    };

        List<Rectangle> rightFrames = new List<Rectangle>
    {
         new Rectangle(255, 11, 16, 16),
        new Rectangle(255, 28, 16, 16),
        new Rectangle(272, 11, 16, 16),
        new Rectangle(272, 28, 16, 16),
    };

        List<Rectangle> projectileFrames = new List<Rectangle>
    {
        new Rectangle(289, 11, 8, 16),
        new Rectangle(298, 11, 8, 16),
        new Rectangle(307, 11, 8, 16),
    };

        return new Goriya(spriteBatch, new Vector2(300, 200), texture, upFrames, downFrames, leftFrames, rightFrames, projectileFrames);
    }

    // Load the Wallmaster sprite
    public IEnemy CreateWallmaster()
    {
        List<Rectangle> gelFrames = new List<Rectangle>
        {
            new Rectangle(392, 11, 17, 19),
            new Rectangle(410, 11, 17, 19),
        };
        return new Gel(spriteBatch, new Vector2(300, 200), texture, gelFrames);
    }

}