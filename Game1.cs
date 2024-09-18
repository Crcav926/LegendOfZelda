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
        public ISprite linkSprite;
        public Texture2D linkTexture;
        public Rectangle sourceRectangle;
        public Rectangle destinationRectangle;
        public Link LinkCharacter;
        public ClassItems items;
        public ISprite itemSprite;


        private IController controllerK;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            controllerK = new KeyboardCont(this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            linkTexture = Content.Load<Texture2D>("LinkSpriteSheet");
            // TODO: use this.Content to load your game content here
            // Have 0 to be the default facing left
            LinkCharacter = new Link(linkTexture);
            // items uses the same spritesheet as link character.
            itemSprite = new SpriteItem(linkTexture);
            items = new ClassItems(itemSprite);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            // TODO: Add your update logic here
            controllerK.Update();
            base.Update(gameTime);
            LinkCharacter.Update(gameTime);
            items.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            sourceRectangle = new Rectangle(103, 11, 16, 16);
            destinationRectangle = new Rectangle(400, 200, 60, 60);
            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            LinkCharacter.Draw(_spriteBatch);
            
            items.Draw(_spriteBatch);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}