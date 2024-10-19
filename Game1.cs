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
using Microsoft.VisualBasic;

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
        private List<ICollideable> blocks;
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
            _graphics.PreferredBackBufferWidth = Constants.ScreenWidth;
            _graphics.PreferredBackBufferHeight = Constants.ScreenHeight;
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
            collHandler = new CollisionHandler();
            collisionDetector = new detectionManager(collHandler);
            
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

            // TODO: Get absorbed by Level Loader as well so it can support custom backgrounds and walls
            background = new Sprite(BackgroundTure, new List<Rectangle>() { new Rectangle(1, 192, 192, 112) });
            walls = new Sprite(BackgroundTure, new List<Rectangle>() { new Rectangle(521, 11, 256, 176) });
            // TODO: Make this fully within level loader. Not yet added b/c it would mess up a lot of commands and we don't have time to fix it rn
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            LinkCharacter = new Link();

            LevelLoader.Instance.Load("Room1.xml");
            RoomObjectManager.Instance.addLink(LinkCharacter);
            RoomObjectManager.Instance.Update();

            blocks = LevelLoader.Instance.getBlocks();
            movers = LevelLoader.Instance.getMovers();

            //load texture sheets
            
            // for now I"m adding the hitboxes to the collision detector here it should be moved to level loader though
            // load hitboxes
            collisionDetector.addHitbox(LinkCharacter, 1);
            foreach (ICollideable block in blocks) {
                collisionDetector.addHitbox(block, 0);
            }
            foreach (ICollideable mover in movers)
            {
                collisionDetector.addHitbox(mover, 1);
            }
        }

        protected override void Update(GameTime gameTime)
        {
            blocks = LevelLoader.Instance.getBlocks();
            movers = LevelLoader.Instance.getMovers();
            // Let the keyboard controller handle input
            keyboardController.Update();
            RoomObjectManager.Instance.Update();

            // Ensure the sprite is correctly referenced
            foreach (IController controller in controllerList)
            {
                controller.Update();
            }
            // update collision
            collisionDetector.update();
            //collHandler.update();
            //Update the current enemy to have the correct sprite and draw it
            // The enemies use their own sprite batch so this must be outside the other sprite batch begin.
            foreach (ICollideable mover in movers)
            {
                mover.Update(gameTime);
            }
            //Update the keyboard controller
            controllerK.Update();
            base.Update(gameTime);
            // Calls link update, which updates his Sprite and Items
            LinkCharacter.Update(gameTime);
            // Updates sprites in Item classes

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here


            var matrix = Matrix.CreateScale(Constants.ScaleX, Constants.ScaleY, 1.0f);

            _spriteBatch.Begin(transformMatrix: matrix);
            walls.Draw(_spriteBatch, new Rectangle(0, 0, 800, 480), Color.White);
            background.Draw(_spriteBatch, new Rectangle(100, 88, 600, 305), Color.White);
            foreach (ICollideable block in blocks)
            {
                block.Draw(_spriteBatch);
            }
            foreach (ICollideable mover in movers)
            {
                mover.Draw(_spriteBatch);
            }
            // Calls Link's Draw method
            LinkCharacter.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}