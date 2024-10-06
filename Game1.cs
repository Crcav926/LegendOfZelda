using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ObjectManagementExamples;
using System;
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

        // Later these enemies will be moved out to level loader.
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
        public Texture2D blockTexture;
        public Block block;
        public Link LinkCharacter;
        // items was mostly for testing, static items is the stationary cyclable item.
        public List<ClassItems> items = new List<ClassItems>();
        public List<ClassItems> staticItems = new List<ClassItems>();
        private List<ILinkItem> inventory = new List<ILinkItem>();
        private ClassItems item1;
        private ClassItems item2;
        private Boomerang boomerang;

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

            //All this sprite loading will be moved later to either the level loader or an enemy manager
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

            
            //load texture sheets
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            LinkCharacter = new Link();
            blockTexture = Content.Load<Texture2D>("ZeldaTileSheet");
            block = new Block(blockTexture);
            itemTexture = Content.Load<Texture2D>("itemSpriteFinal");
            // Have 0 to be the default facing left

            //add the items to the item collection
            staticItems.Add(item1);
            items.Add(item2);
            // inventory.Add();

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

            //Update the current enemy to have the correct sprite and draw it
            // The enemies use their own sprite batch so this must be outside the other sprite batch begin.
            IEnemy current = (IEnemy)sprites[currentSprite];
            current.Update(gameTime);
            current.Draw();
            
            // TODO: Add your update logic here
            //Update the keyboard controller
            controllerK.Update();
            base.Update(gameTime);
            // Calls link update, which updates his Sprite and Items
            LinkCharacter.Update(gameTime);
            block.Update(gameTime);
            // Updates sprites in Item classes

            foreach(ILinkItem item in inventory)

            foreach (ClassItems itemM in items)
            {
                itemM.Update(gameTime);
            }
            foreach (ClassItems itemS in staticItems)
            {
                itemS.Update(gameTime);
            }
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
             //draws all items in item lists
            foreach (ClassItems item in items)
            {
                item.Draw(_spriteBatch);
            }
            foreach (ClassItems item in staticItems)
            {
                item.Draw(_spriteBatch);
            }
            block.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}