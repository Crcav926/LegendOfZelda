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
using System.Diagnostics;
using Microsoft.Xna.Framework.Audio;
using LegendOfZelda.Sounds;
using LegendOfZelda.HUD;

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
        public int currentSprite { get; set; }
        public Texture2D linkTexture;
        public Texture2D itemTexture;
        public Texture2D blockTexture;
        public Texture2D Bossture;
        public Texture2D BackgroundTure;
        public Texture2D HUDTexture;
        public Block block;
        private List<ILinkItem> inventory = new List<ILinkItem>();
        public List<ClassItems> items = new List<ClassItems>();
        
        public List<IEnemy> enemies = new List<IEnemy>();
        private List<ICollideable> blocks;
        private List<ICollideable> movers;
        private ISprite background;
        private ISprite walls;

        //private IController controllerK;
        private HUDManager hudManager;

        private KeyboardCont controllerK;


        //For collisions
        detectionManager collisionDetector;
        CollisionHandler collHandler;

        SoundMachine soundMachine = SoundMachine.Instance;


        ClassItems test;
        Block testBlock;


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
            // Temp load font for fps check.
            // font = Content.Load<SpriteFont>("font");

            // Load the texture for the sprite 


            itemTexture = Content.Load<Texture2D>("itemSpriteFinal");
            texture = Content.Load<Texture2D>("enemySpriteSheet");
            Bossture = Content.Load<Texture2D>("bossSpriteSheet");
            BackgroundTure = Content.Load<Texture2D>("ZeldaTileSheet");
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            HUDSpriteFactory.Instance.LoadAllTextures(Content);
            hudManager = new HUDManager(this);

            // TODO: Absorb into level loader
            BackgroundTure = Content.Load<Texture2D>("ZeldaTileSheet");


            // TODO: Get absorbed by Level Loader as well so it can support custom backgrounds and walls
            background = new Sprite(BackgroundTure, new List<Rectangle>() { new Rectangle(1, 192, 192, 112) });
            walls = new Sprite(BackgroundTure, new List<Rectangle>() { new Rectangle(521, 11, 256, 176) });

            LevelLoader.Instance.LoadAllContent(Content);
            LevelLoader.Instance.RegisterAllCommands(controllerK, this);
            LevelLoader.Instance.Load("Room1.xml");
            RoomObjectManager.Instance.Update();

            blocks = LevelLoader.Instance.getBlocks();
            movers = LevelLoader.Instance.getMovers();

          
            //I'll keep the theme song loaded here so it doesn't reset on room changes
            SoundEffect mikuSong = Content.Load<SoundEffect>("mikuSong");
            SoundEffectInstance modifier = mikuSong.CreateInstance();
            modifier.IsLooped = true;
            modifier.Volume = .3f;
            modifier.Play();

            test = new ClassItems(new Vector2(280, 300), "Triforce");
            RoomObjectManager.Instance.staticItems.Add(test);

            testBlock = new Block(new Vector2(250, 300), "PushableBlock");
            testBlock.movable = true;
            RoomObjectManager.Instance.blocks.Add(testBlock);
            
        }

        protected override void Update(GameTime gameTime)
        {
            blocks = LevelLoader.Instance.getBlocks();
            movers = LevelLoader.Instance.getMovers();
            // Let the keyboard controller handle input
            keyboardController.Update();
            RoomObjectManager.Instance.Update();
            hudManager.Update(gameTime);
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
            foreach (ICollideable mover in LevelLoader.Instance.getMovers())
            {
                mover.Update(gameTime);
            }
            //Update the keyboard controller
            controllerK.Update();
            
            base.Update(gameTime);
            // Calls link update, which updates his Sprite and Items
            // LinkCharacter.Update(gameTime);
            // Updates sprites in Item classes

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);


            // TODO: Add your drawing code here
            // Temp fps check.
            double frameRate = 1 / gameTime.ElapsedGameTime.TotalSeconds;
            string fpsText = $"FPS: {frameRate:0.00}";


            //var matrix = Matrix.CreateScale(Constants.ScaleX, Constants.ScaleY, 1.0f);


            var matrix = Matrix.CreateTranslation(0, Constants.HUDHeight, 0) * Matrix.CreateScale(Constants.ScaleX, Constants.ScaleY, 1.0f);

            // Draw the game content with the transform matrix applied
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, transformMatrix: matrix);
            
            //TJ wants this moved out of Game 1 becuase of constants
            walls.Draw(_spriteBatch, new Rectangle(0, 0, 800, 480), Color.White);


            background.Draw(_spriteBatch, new Rectangle(100, 88, 600, 305), Color.White);
            foreach (ICollideable block in blocks)
            {
                block.Draw(_spriteBatch);
            }
            walls.Draw(_spriteBatch, new Rectangle(0, 0, 800, 480), Color.White);
            foreach (ICollideable mover in LevelLoader.Instance.getMovers())
            {
                mover.Draw(_spriteBatch);
            }
            test.Draw(_spriteBatch);
            //testBlock.Draw(_spriteBatch);
            //draw the dropped items
            foreach (ClassItems statItem in RoomObjectManager.Instance.getGroundItems())
            {
                statItem.Draw(_spriteBatch);
            }
            hudManager.Draw(_spriteBatch);



            //_spriteBatch.DrawString(font, fpsText, new Vector2(680,0), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}