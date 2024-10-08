using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ObjectManagementExamples;

namespace ObjectManagementExamples
{
    public static class Texture2DStorage
    {
        // Note that we are not using Game1's ContentLoader here (outside the scope of class methods) since it has not been instantiated yet
        private static Texture2D linkSpriteSheet;
        private static Texture2D itemSpriteSheet;
        // More private static Texture2D fields follow
        public static void LoadAllTextures(ContentManager content)
        {

            itemSpriteSheet = content.Load<Texture2D>("itemSpriteFinal");
            // More Content.Load calls
        }

        public static void UnloadAllTextures()
        {
            // unload all the Texture2Ds
            // Not needed right now.
        }

        public static Texture2D GetItemSpriteSheet()
        {
            return itemSpriteSheet;
        }

        // More public static Texture2D returning methods follow
        // ...

    }
}

