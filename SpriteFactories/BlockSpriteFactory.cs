using LegendOfZelda;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ObjectManagementExamples;
using System.Collections.Generic;
using System;

namespace LegendOfZelda
{
    public class BlockSpriteFactory
    {
        public static Dictionary<String, List<Rectangle>> frames = new Dictionary<String, List<Rectangle>>()
            {
            {
            "Floor", new List<Rectangle> { new Rectangle(984, 11, 16, 16) }
            },
            {
            "Block", new List<Rectangle>{ new Rectangle(1001, 11, 16, 16) }
            },
            {
            "PushableBlock", new List<Rectangle>{ new Rectangle(1001, 11, 16, 16) }
            },
            {
            "FishStatue", new List<Rectangle>{ new Rectangle(1018, 11, 16, 16) }
            },
            {
            "DragonStatue", new List<Rectangle>{ new Rectangle(1035, 11, 16, 16) }
            },
            {
            "DarkVoid", new List<Rectangle>{ new Rectangle(984, 28, 16, 16) }
            },
            {
            "Dirt", new List<Rectangle>{ new Rectangle(1001, 28, 16, 16) }
            },
            {
            "dirt", new List<Rectangle>{ new Rectangle(1001, 28, 16, 16) }
            },
            {
            "Water", new List<Rectangle>{ new Rectangle(1018, 28, 16, 16) }
            },
            {
            "Staircase", new List<Rectangle>{ new Rectangle(1035, 28, 16, 16) }
            },
            {
            "Bricks", new List<Rectangle> { new Rectangle(984, 45, 16, 16) }
            },
            {
            "Ladder", new List<Rectangle> { new Rectangle(1001, 45, 16, 16) }
            }
        };
        private Texture2D texture;
        // More private Texture2Ds follow

        private static BlockSpriteFactory instance = new BlockSpriteFactory();

        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BlockSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            texture = content.Load<Texture2D>("ZeldaTileSheet");
        }

        public ISprite CreateSprite(String type)
        {
            return new Sprite(texture, frames[type]);
        }

    }

}
