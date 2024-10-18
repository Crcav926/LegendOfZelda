using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ObjectManagementExamples;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using LegendOfZelda.Collision;
using System.Xml;

namespace LegendOfZelda
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Texture2D texture;
        private KeyboardCont keyboardController;
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
        private List<ILinkItem> inventory = new List<ILinkItem>();
        private Boomerang boomerang;
        public List<ClassItems> items = new List<ClassItems>();
        public List<ClassItems> staticItems = new List<ClassItems>();
        private ClassItems item1;
        private ClassItems item2;
        public List<IEnemy> enemies = new List<IEnemy>();
        private List<Block> blocks;
        private List<ICollideable> movers;
        private ISprite background;
        private ISprite walls;

        private IController controllerK;

        //For collisions
        detectionManager collisionDetector;
        CollisionHandler collHandler;

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
            keyboardController = new KeyboardCont(this);
            // Initializes keyboard controller

            controllerK = new KeyboardCont(this);
            // TEMP
            //init the collision stuff
            collisionDetector = new detectionManager();
            collHandler = new CollisionHandler(collisionDetector);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load the texture for the sprite sheet
            Texture2D texture = Content.Load<Texture2D>("enemySpriteSheet");
            Texture2D Bossture = Content.Load<Texture2D>("bossSpriteSheet");
            Texture2D BackgroundTure = Content.Load<Texture2D>("ZeldaTileSheet");
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            background = new Sprite(BackgroundTure, new List<Rectangle>() { new Rectangle(1, 192, 192, 112) });
            walls = new Sprite(BackgroundTure, new List<Rectangle>() { new Rectangle(521, 11, 256, 176) });

            LevelLoading levelLoading = new LevelLoading();
            blocks = levelLoading.Load();
            movers = levelLoading.getMovers();

            //All this sprite loading will be moved later to either the level loader or an enemy manager
            // Use the factory to create the sprites
            // Refactored Enemies
            // TODO: Be Eaten by LevelLoader
            Aquamentus = new Aquamentus(new Vector2(400, 200));
            BladeTrap = new BladeTrap(new Vector2(350, 200));
            Gel = new Gel(new Vector2(200, 200));
            Goriya = new Goriya(new Vector2(100, 200));
            Keese = new Keese(new Vector2(300, 300));
            // Stalfol = new Stalfol(new Vector2(100, 300));
            Zol = new Zol(new Vector2(100, 200));
            Wallmaster = new Wallmaster(new Vector2(50, 100));

            enemies.Add(BladeTrap);
            enemies.Add(Aquamentus);
            enemies.Add(Gel);
            enemies.Add(Goriya);
            enemies.Add(Keese);
            // enemies.Add(Stalfol);
            enemies.Add(Zol);
            enemies.Add(Wallmaster);

            //load texture sheets
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            LinkCharacter = new Link();
            blockTexture = Content.Load<Texture2D>("ZeldaTileSheet");
            block = new Block(new Vector2(100, 300), "dirt");
            itemTexture = Content.Load<Texture2D>("itemSpriteFinal");
            // Have 0 to be the default facing left
            // inventory.Add();
            // format is texture sheet, x cord, y cord.
            item1 = new ClassItems(itemTexture, 600, 200); 
            item2 = new ClassItems(itemTexture, 200, 200);

            //add the items to the item collection
            staticItems.Add(item1);
            items.Add(item2);

            // for now I"m adding the hitboxes to the collision detector here it should be moved to level loader though
            //load hitboxes
            collisionDetector.addHitbox(LinkCharacter, 1);
            foreach (Block block in blocks) {
                collisionDetector.addHitbox(block, 0);
            }
            foreach (ICollideable mover in movers)
            {
                collisionDetector.addHitbox(mover, 1);
            }
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
            // update collision
            collisionDetector.update();
            collHandler.update();
            //Update the current enemy to have the correct sprite and draw it
            // The enemies use their own sprite batch so this must be outside the other sprite batch begin.
            foreach(IEnemy enemy in enemies)
            {
                enemy.Update(gameTime);
            }
            foreach (ICollideable mover in movers)
            {
                mover.Update(gameTime);
            }
            foreach (ClassItems itemM in items)
            {
                itemM.Update(gameTime);
            }
            foreach (ClassItems itemS in staticItems)
            {
                itemS.Update(gameTime);
            }
            //Update the keyboard controller
            controllerK.Update();
            base.Update(gameTime);
            // Calls link update, which updates his Sprite and Items
            LinkCharacter.Update(gameTime);
            block.Update(gameTime);
            // Updates sprites in Item classes

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            
            

            _spriteBatch.Begin();
            walls.Draw(_spriteBatch, new Rectangle(0, 0, 800, 480), Color.White);
            background.Draw(_spriteBatch, new Rectangle(100, 88, 600, 305), Color.White);
            foreach (Block block in blocks)
            {
                block.Draw(_spriteBatch);
            }
            foreach (IEnemy enemy in enemies)
            {
                // enemy.Draw(_spriteBatch);
            }
            foreach (ICollideable mover in movers)
            {
                mover.Draw(_spriteBatch);
            }
            // Calls Link's Draw method
            LinkCharacter.Draw(_spriteBatch);
             //draws all items in item lists
            foreach (ClassItems itemM in items)
            {
                itemM.Draw(_spriteBatch);
            }
            foreach (ClassItems itemS in staticItems)
            {
                itemS.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}