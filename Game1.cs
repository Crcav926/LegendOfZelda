using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LegendOfZelda
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Texture2D texture;
        private KeyboardController keyboardController;
        public ArrayList sprites;
        ArrayList controllerList;
        IEnemy Gel;
        IEnemy Zol;
        IEnemy Keese;
        IEnemy Stalfol;
        IEnemy Goriya;
        IEnemy Wallmaster;
        IEnemy BladeTrap;
        IEnemy Aquamentus;

        public int currentSprite { get; set; }
        public Texture2D linkTexture;
        public Texture2D itemTexture;
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
            controllerList = new ArrayList();
            sprites = new ArrayList();
            // Need discuss where to initialize
            keyboardController = new KeyboardController();
            // Initializes keyboard controller
            controllerK = new KeyboardCont(this);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

 // Load the texture for the sprite sheet
            Texture2D texture = Content.Load<Texture2D>("enemySpriteSheet");
            Texture2D Bossture = Content.Load<Texture2D>("bossSpriteSheet");


            SpriteFactory spriteFactory = new SpriteFactory(_spriteBatch, texture);
            SpriteFactory spriteFactory2 = new SpriteFactory(_spriteBatch, Bossture);

            // Use the factory to create the sprites
            Gel = spriteFactory.CreateGel();
            Zol = spriteFactory.CreateZol();
            Keese = spriteFactory.CreateKeese();
            Stalfol = spriteFactory.CreateStalfol();
            Goriya = spriteFactory.CreateGoriya();
            Wallmaster = spriteFactory.CreateWallmaster();
            BladeTrap = spriteFactory.CreateBladeTrap();
            Aquamentus = spriteFactory2.CreateAquamentus();
            sprites.Add(Gel);
            sprites.Add(Zol);
            sprites.Add(Keese);
            sprites.Add(Stalfol);
            sprites.Add(Goriya);
            sprites.Add(Wallmaster);
            sprites.Add(BladeTrap);
            sprites.Add(Aquamentus);
            // TODO: use this.Content to load your game content here

            keyboardController.RegisterCommand(Keys.O, new PreviousSpriteCommand(this));
            keyboardController.RegisterCommand(Keys.P, new NextSpriteCommand(this));

            //load texture sheets
            linkTexture = Content.Load<Texture2D>("LinkSpriteSheet");
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
            // Let the keyboard controller handle input
            keyboardController.Update();

            // Ensure the sprite is correctly referenced
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }

            IEnemy current = (IEnemy)sprites[currentSprite];
            current.Update(gameTime);
            current.Draw();
            
            // TODO: Add your update logic here
            controllerK.Update();
            base.Update(gameTime);
            // Calls link update, which updates his Sprite and Items
            LinkCharacter.Update(gameTime);
            // Updates sprites in Item classes
            item1.Update(gameTime);
            item2.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
            
            IEnemy current = (IEnemy)sprites[currentSprite];
            current.Draw();

            _spriteBatch.Begin();
            // Calls Link's Draw method
            LinkCharacter.Draw(_spriteBatch);
            
            item1.Draw(_spriteBatch);
            item2.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}