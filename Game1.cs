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
using System.ComponentModel.Design;

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

        //private IController controllerK;
        private HUDManager hudManager;
        private PausedHUD pausedHUD;
        private KeyboardCont controllerK;


        //For collisions
        private detectionManager collisionDetector;
        private CollisionHandler collHandler;

        private SoundMachine soundMachine = SoundMachine.Instance;
        public bool paused;
        private SpriteFont font;
        private Texture2D blackRectangle;

        //Reset Testing
        ResetWatchdog resetWatchdog;

        public Menu menu;

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
          
            //init the collision stuff
            collHandler = new CollisionHandler();
            collisionDetector = new detectionManager(collHandler);
            //reset
            resetWatchdog = new ResetWatchdog();
            //reset fix?
            Globals.inMenus = true;


            base.Initialize();
        }

        
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // Temp load font for fps check.
            font = Content.Load<SpriteFont>("font");
          

            HUDSpriteFactory.Instance.LoadAllTextures(Content);
            MenuSpriteFactory.Instance.LoadAllTextures(Content);
            EndScreenSpriteFactory.Instance.LoadAllTextures(Content);
            menu = new Menu(this);

    
           

            //this loads textures too
            LevelLoader.Instance.LoadAllContent(Content);

            LevelLoader.Instance.RegisterAllCommands(controllerK, this);
            if (Globals.mode == 0)
            {
                List<String> listOfRooms = new List<string>()
            {
                "Room2.xml", "Room3.xml", "Room4.xml", "Room5.xml", "Room6.xml",
                "Room7.xml", "Room8.xml", "Room9.xml", "Room10.xml", "Room11.xml",
                "Room12.xml", "Room13.xml", "Room14.xml", "Room15.xml", "Room16.xml", "Room17.xml", "Room18.xml"
            };
                foreach (string room in listOfRooms)
                {
                    LevelLoader.Instance.Load(room);
                }
                LevelLoader.Instance.Load("Room1.xml");
            }
            else
            {
                LevelLoader.Instance.LoadFloor(Constants.floorSize);
                RoomObjectManager.Instance.Update();
            }

            hudManager = new HUDManager(this);
            pausedHUD = PausedHUD.Instance;
              
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
                    if(ResetWatchdog.Instance.resetCheck == true)
                    {
                        break;
                    }
                }
                RoomObjectManager.Instance.addProjectileToMovers(); //if we can remove this somehow, that'd be great.
                Camera2D.Instance.Update();
                base.Update(gameTime);
                // Calls link update, which updates his Sprite and Items
                // LinkCharacter.Update(gameTime);
                // Updates sprites in Item classes
                if(ResetWatchdog.Instance.resetCheck == true)
                {
                    ResetWatchdog.Instance.resetCheck = false;
                    Globals.menuType = 1;
                    Globals.inMenus = true;
                    this.Reset();
                }
            }
            //if we're in menus we should be paused so update it.
            else
            {
                pausedHUD.Update(gameTime);
            }
            menu.Update(gameTime);
            hudManager.Update(gameTime);
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

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, transformMatrix: Camera2D.Instance.getMatrix());
            
            if (!paused)
            {
                foreach (KeyValuePair<Vector2, Room> entry in LevelLoader.Instance.getRooms())
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
            }

            _spriteBatch.End();

            Matrix matrix = Matrix.CreateTranslation(0, Constants.HUDHeight, 0) * Matrix.CreateScale(Constants.ScaleX, Constants.ScaleY, 1.0f);

            // Draw the game content with the transform matrix applied

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp, transformMatrix: matrix);

            hudManager.Draw(_spriteBatch);
            if (paused)
            {
                //THIS IS THE MOST JANK PAUSE EVER BUT IT DO WORK

                pausedHUD.Draw(_spriteBatch);
                if (!Globals.inMenus) //if the menu isn't up and it's paused.
                {
                    //draw the pause screen
                    pausedHUD.Draw(_spriteBatch);
                } else {
                
                    //otherwise we are paused becaus we're in menus
                    menu.Draw(_spriteBatch);
                }

            }
            menu.Draw(_spriteBatch);
            _spriteBatch.End();



            base.Draw(gameTime);
        }
        public void Reset()
        {
            HUDMap.Instance.Reset();
            SoundMachine.Instance.StopSound("theme");
            RoomObjectManager.Instance.Clear();
            LevelLoader.Instance.Reset();
            LevelLoader.Instance.Load("Room1.xml");
            blocks = LevelLoader.Instance.getBlocks();
            movers = LevelLoader.Instance.getMovers();
            hudManager = new HUDManager(this);
            Link.Instance.Reset();
            Link.Instance.inventory.addItem(Link.Instance.boomerang);
            Link.Instance.inventory.addItem(Link.Instance.arrow);
            Link.Instance.inventory.addItem(Link.Instance.fire);
            Link.Instance.inventory.addItem(Link.Instance.bomb);
            Camera2D.Instance.Reset();
            collHandler = new CollisionHandler();
            collisionDetector = new detectionManager(collHandler);
            Globals.hasMap = false;
            Initialize();
        }


        public void setPause(bool pauseState)
        {
            paused = pauseState;
        }
        public void reloadTextures()
        {
            clearLoads();
            this.LoadContent();
        }

        private void clearLoads()
        {
            
            // uh idk what else to clear so i need to ask.
            controllerK.clearCommands();
            LevelLoader.Instance.clearRooms();
            SoundMachine.Instance.clearSounds();

        }
    }
}