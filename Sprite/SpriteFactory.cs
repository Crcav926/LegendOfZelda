using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.ComponentModel;

public class SpriteFactory
{
    private SpriteBatch spriteBatch;
    private Texture2D texture;

    public SpriteFactory(SpriteBatch spriteBatch, Texture2D texture)
    {
        this.spriteBatch = spriteBatch;
        this.texture = texture;
    }

    public static SpriteFactory Instance
    {
        get
        {
            return Instance;
        }
    }

    public SpriteFactory()
    {
    }
    // Load the Stalfol sprite
    

    // Load the Wallmaster sprite
   
}