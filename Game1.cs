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
        SoundEffectInstance mikuSong;
        public bool paused;
        SpriteFont font;
        Texture2D blackRectangle;


        IEnemy ganon;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = Constants.ScreenWidth;
            _graphics.PreferredBackBufferHeight = Constants.ScreenHeight;
            paused = false; 
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
            font = Content.Load<SpriteFont>("font");

            // Load the texture for the sprite 


            itemTexture = Content.Load<Texture2D>("itemSpriteFinal");
            texture = Content.Load<Texture2D>("enemySpriteSheet");
            Bossture = Content.Load<Texture2D>("bossSpriteSheet");
            BackgroundTure = Content.Load<Texture2D>("ZeldaTileSheet");
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            HUDSpriteFactory.Instance.LoadAllTextures(Content);
            

            // TODO: Absorb into level loader
            BackgroundTure = Content.Load<Texture2D>("ZeldaTileSheet");



            LevelLoader.Instance.LoadAllContent(Content);
            LevelLoader.Instance.RegisterAllCommands(controllerK, this);
            List<String> listOfRooms = new List<string>()
            {
                "Room1.xml", "Room2.xml", "Room3.xml", "Room4.xml", "Room5.xml", "Room6.xml",
                "Room7.xml", "Room8.xml", "Room9.xml", "Room10.xml", "Room11.xml",
                "Room12.xml", "Room13.xml", "Room14.xml", "Room15.xml", "Room16.xml", "Room17.xml", "Room18.xml", "Room20.xml"
            };
            foreach (string room in listOfRooms)
            {
                LevelLoader.Instance.Load(room);
            }
            LevelLoader.Instance.Load("Room1.xml");
            RoomObjectManager.Instance.Update();

            blocks = LevelLoader.Instance.getBlocks();
            movers = LevelLoader.Instance.getMovers();

            //I'll keep the theme song loaded here so it doesn't reset on room changes
            mikuSong = Content.Load<SoundEffect>("mikuSong").CreateInstance();
            mikuSong.IsLooped = true;
            mikuSong.Volume = .3f;
            mikuSong.Play();
            hudManager = new HUDManager();

            ganon = new Ganon(new Vector2(200,200));    
        }

        protected override void Update(GameTime gameTime)
        {
            if (!paused)
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
                foreach (ICollideable mover in RoomObjectManager.Instance.getMovers())
                {
                    mover.Update(gameTime);
                }
                RoomObjectManager.Instance.addProjectileToMovers(); //if we can remove this somehow, that'd be great.
                Camera2D.Instance.Update();
                base.Update(gameTime);
                // Calls link update, which updates his Sprite and Items
                // LinkCharacter.Update(gameTime);
                // Updates sprites in Item classes
                //ganon.Update(gameTime);
            }
            //Update the keyboard controller outside because we need it
            controllerK.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            // TODO: Add your drawing code here
            // Temp fps check.
            double frameRate = 1 / gameTime.ElapsedGameTime.TotalSeconds;
            string fpsText = $"FPS: {frameRate:0.00}";


            Matrix matrix = Matrix.CreateTranslation(0, Constants.HUDHeight, 0) * Matrix.CreateScale(Constants.ScaleX, Constants.ScaleY, 1.0f);

            // Draw the game content with the transform matrix applied

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, transformMatrix: Camera2D.Instance.getMatrix());
            if (!paused)
            {
                foreach (KeyValuePair<String, Room> entry in LevelLoader.Instance.getRooms())
                {
                    entry.Value.Draw(_spriteBatch);
                }
                foreach (ICollideable block in RoomObjectManager.Instance.getStandStills())
                {
                    block.Draw(_spriteBatch);
                }
                foreach (ICollideable mover in RoomObjectManager.Instance.getMovers())
                {
                    mover.Draw(_spriteBatch);
                }
                //draw the dropped items
                foreach (ClassItems statItem in RoomObjectManager.Instance.getGroundItems())
                {
                    statItem.Draw(_spriteBatch);
                }
                //ganon.Draw(_spriteBatch);
            }


            _spriteBatch.End();
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, transformMatrix: matrix);
            hudManager.Draw(_spriteBatch);

            if (paused)
            {
                //THIS IS THE MOST JANK PAUSE EVER BUT IT DO WORK
                Rectangle destinationRectangle = new Rectangle(-(int)Camera2D.Instance.getPosition().X, (int)Camera2D.Instance.getPosition().Y, 1000, 1000);
                blackRectangle = new Texture2D(GraphicsDevice, 1, 1);
                blackRectangle.SetData(new[] { Color.Black });
                //hudManager.Draw(_spriteBatch, new Rectangle(100, Constants.HUDHeight ,Constants.OriginalWidth, Constants.OriginalHeight / 4));
                _spriteBatch.Draw(blackRectangle, destinationRectangle, Color.White);
                _spriteBatch.DrawString(font, "PAUSED", new Vector2(360, 200), Color.White);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
        public void Reset()
        {
            mikuSong.Stop();
            RoomObjectManager.Instance.Clear();
            LevelLoader.Instance.Load("Room1.xml");
            blocks = LevelLoader.Instance.getBlocks();
            movers = LevelLoader.Instance.getMovers();
            hudManager = new HUDManager();
            Link.Instance.Reset();
            Camera2D.Instance.Reset();
            collHandler = new CollisionHandler();
            collisionDetector = new detectionManager(collHandler);
            Initialize();
        }


        public void setPause(bool pauseState)
        {
            paused = pauseState;
            if (pauseState == false)
            {
                blackRectangle.Dispose();
            }
        }
    }
}