using LegendOfZelda;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using LegendOfZelda.LinkMovement;
using static System.Formats.Asn1.AsnWriter;
using System.Data;



namespace LegendOfZelda
{
    public class LinkSpriteFactory
    {
        public Texture2D linkSpriteSheet;
        // More private Texture2Ds follow
        // ...

        private static LinkSpriteFactory instance = new LinkSpriteFactory();

        public static LinkSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private LinkSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            linkSpriteSheet = content.Load<Texture2D>("LinkSpriteSheet");
             
            // More Content.Load calls follow
            //...
        }

        Dictionary<Vector2, List<Rectangle>> LinkStillFrames = new Dictionary<Vector2, List<Rectangle>>()
    {

        { new Vector2(-1, 0), new List<Rectangle>()
            {
                // Left Rectangles
                new Rectangle(120, 11, 16, 16),
            }
        },
        { new Vector2(1, 0), new List<Rectangle>()
            {
                // Right Rectangles
                new Rectangle(35, 11, 16, 16),
            }
        },{ new Vector2(0, 1), new List<Rectangle>()
            {
                // Down Rectangles
                new Rectangle(1, 11, 16, 16),
            }
        },{ new Vector2(0, -1), new List<Rectangle>()
            {
                // Up Rectangles
                new Rectangle(86, 11, 16, 16),
            }
        }
    };
        Dictionary<Vector2, List<Rectangle>> LinkSpriteFrames = new Dictionary<Vector2, List<Rectangle>>()
    {

        { new Vector2(-1, 0), new List<Rectangle>()
            {
                // Left Rectangles
                new Rectangle(120, 11, 16, 16),
                new Rectangle(103, 11, 16, 16)
            }
        },
        { new Vector2(1, 0), new List<Rectangle>()
            {
                // Right Rectangles
                new Rectangle(35, 11, 16, 16),
                new Rectangle(52, 11, 16, 16)
            }
        },{ new Vector2(0, 1), new List<Rectangle>()
            {
                // Down Rectangles
                new Rectangle(1, 11, 16, 16),
                new Rectangle(18, 11, 16, 16)
            }
        },{ new Vector2(0, -1), new List<Rectangle>()
            {
                // Up Rectangles
                new Rectangle(86, 11, 16, 16),
                new Rectangle(69, 11, 16, 16)
            }
        }
    };

        Dictionary<Vector2,List<Rectangle>> attackSpriteFrames = new Dictionary<Vector2, List<Rectangle>>()
    {
        { new Vector2(-1, 0), new List<Rectangle>()
            {
                // Left Rectangles
                new Rectangle(191, 11, 17, 17)
            }
        },
        { new Vector2(1, 0), new List<Rectangle>()
            {
                // Right Rectangles
                new Rectangle(157, 11, 17, 17)
            }
        },{ new Vector2(0, 1), new List<Rectangle>()
            {
                // Down Rectangles
                new Rectangle(140, 11, 17, 17)
            }
        },{ new Vector2(0, -1), new List<Rectangle>()
            {
                // Up Rectangles
                 new Rectangle(174, 11, 17, 17)
            }
        }
        };

        List<Rectangle> deathSpriteFrames = new List<Rectangle>()
        {
            //death animation: rotate then face down; explode. Might make the explosion frames a separate list.
            //rotate clockwise starting at down.
            //ok so in the original he rotates counterclockwise but close enough
            //I could make a dictionary that starts the animation in a different direction, but it only changes at most 3 frames so who cares
            new Rectangle(1, 11, 16, 16),
            new Rectangle(120, 11, 16, 16),
            new Rectangle(86, 11, 16, 16),
            new Rectangle(35, 11, 16, 16),
            //rotation 2
            new Rectangle(1, 11, 16, 16),
            new Rectangle(120, 11, 16, 16),
            new Rectangle(86, 11, 16, 16),
            new Rectangle(35, 11, 16, 16),
            //rotation 3
            new Rectangle(1, 11, 16, 16),
            new Rectangle(120, 11, 16, 16),
            new Rectangle(86, 11, 16, 16),
            new Rectangle(35, 11, 16, 16),
            //stand still for gray
            new Rectangle(1, 11, 16, 16),
            new Rectangle(1, 11, 16, 16),
            new Rectangle(1, 11, 16, 16),
            new Rectangle(1, 11, 16, 16),
            new Rectangle(1, 11, 16, 16),
            new Rectangle(1, 11, 16, 16),
            //gray
            new Rectangle(126, 224, 16, 16),
            new Rectangle(126, 224, 16, 16),
            new Rectangle(126, 224, 16, 16),
            new Rectangle(126, 224, 16, 16),
            // new Rectangle(126, 224, 16, 16),
            // new Rectangle(126, 224, 16, 16),
            // new Rectangle(126, 224, 16, 16),
            // new Rectangle(126, 224, 16, 16),
            //explode
            new Rectangle(143, 224, 16, 16),
            new Rectangle(160, 224, 16, 16),
            new Rectangle(177, 224, 16, 16),
            //we'll start at 3 rotations
        };


        // Don't think position should be a factor here, but it is here for simply a lack of time.
        public ISprite CreateLinkStillSprite(Vector2 direction)
        {
            return new Sprite(linkSpriteSheet, LinkStillFrames[direction]);
        }

        public ISprite CreateLinkAnimatedSprite(Vector2 direction) {
            return new Sprite(linkSpriteSheet, LinkSpriteFrames[direction]);
        }

        public ISprite CreateLinkAttackSprite(Vector2 direction)
        {
            return new Sprite(linkSpriteSheet, attackSpriteFrames[direction]);
        }

        public ISprite CreateLinkDeathSprite()
        {
            return new Sprite(linkSpriteSheet, deathSpriteFrames);
        }


    }





    // More public ISprite returning methods follow
    // ...
}


