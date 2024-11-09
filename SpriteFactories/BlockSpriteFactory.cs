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
            "Floor1", new List<Rectangle> {  new Rectangle(1, 192, 192, 112) }
            },
            {
            "FloorVoid", new List<Rectangle> {  new Rectangle(1, 192, 192, 112) }
            },
            {
            "FloorItemRoom", new List<Rectangle> {  new Rectangle(1, 192, 192, 112) }
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
            },
            {
            "UpDoorWall", new List<Rectangle>{ new Rectangle(815, 11, 32, 32) }
            },
            {
            "LeftDoorWall", new List<Rectangle>{ new Rectangle(815, 44, 32, 32) }
            },
            {
            "RightDoorWall", new List<Rectangle>{ new Rectangle(815, 77, 32, 32) }
            },
            {
            "DownDoorWall", new List<Rectangle>{ new Rectangle(815, 110, 32, 32) }
            },
            {
            "UpDoorOpen", new List<Rectangle>{ new Rectangle(848, 11, 32, 32) }
            },
            {
            "LeftDoorOpen", new List<Rectangle>{ new Rectangle(848, 44, 32, 32) }
            },
            {
            "RightDoorOpen", new List<Rectangle>{ new Rectangle(848, 77, 32, 32) }
            },
            {
            "DownDoorOpen", new List<Rectangle>{ new Rectangle(848, 110, 32, 32) }
            },
            {
            "UpDoorLocked", new List<Rectangle>{ new Rectangle(881, 11, 32, 32) }
            },
            {
            "LeftDoorLocked", new List<Rectangle>{ new Rectangle(881, 44, 32, 32) }
            },
            {
            "RightDoorLocked", new List<Rectangle>{ new Rectangle(881, 77, 32, 32) }
            },
            {
            "DownDoorLocked", new List<Rectangle>{ new Rectangle(881, 110, 32, 32) }
            },
            {
            "UpDoorClosed", new List<Rectangle>{ new Rectangle(914, 11, 32, 32) }
            },
            {
            "LeftDoorClosed", new List<Rectangle>{ new Rectangle(914, 44, 32, 32) }
            },
            {
            "RightDoorClosed", new List<Rectangle>{ new Rectangle(914, 77, 32, 32) }
            },
            {
            "DownDoorClosed", new List<Rectangle>{ new Rectangle(914, 110, 32, 32) }
            },
            {
            "UpDoorSecretBombableWall", new List<Rectangle>{ new Rectangle(947, 11, 32, 32) }
            },
            {
            "LeftDoorSecretBombableWall", new List<Rectangle>{ new Rectangle(947, 44, 32, 32) }
            },
            {
            "RightDoorSecretBombableWall", new List<Rectangle>{ new Rectangle(947, 77, 32, 32) }
            },
            {
            "DownDoorSecretBombableWall", new List<Rectangle>{ new Rectangle(947, 110, 32, 32) }
            },


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
