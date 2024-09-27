using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace LegendOfZelda
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        
        public Texture2D linkTexture;
        public Texture2D itemTexture;
        public Texture2D blockTexture;
        public Block block;
        public Link LinkCharacter;
        public List<ClassItems> items = new List<ClassItems>();
        public List<ClassItems> staticItems = new List<ClassItems>();
        private ClassItems item1;
        private ClassItems item2;


        private IController controllerK;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Initializes keyboard controller
            controllerK = new KeyboardCont(this);
        
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //load texture sheets
            linkTexture = Content.Load<Texture2D>("LinkSpriteSheet");
            blockTexture = Content.Load<Texture2D>("ZeldaTileSheet");
            block = new Block(blockTexture);
            itemTexture = Content.Load<Texture2D>("itemSpriteFinal");
            // Have 0 to be the default facing left
            LinkCharacter = new Link(linkTexture, itemTexture);
            
            // format is texture sheet, x cord, y cord.
            item1 = new ClassItems(itemTexture, 600,200);
            item2 = new ClassItems(itemTexture, 200, 200);

            //add the items to the item collection
            staticItems.Add(item1);
            items.Add(item2);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            // TODO: Add your update logic here
            controllerK.Update();
            base.Update(gameTime);
            // Calls link update, which updates his Sprite and Items
            LinkCharacter.Update(gameTime);
            block.Update(gameTime);
            // Updates sprites in Item classes
            item1.Update(gameTime);
            item2.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            // Calls Link's Draw method
            LinkCharacter.Draw(_spriteBatch);
            
            block.Draw(_spriteBatch);
            item1.Draw(_spriteBatch);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}