using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;

namespace Sprite2Enemy
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
        List<Rectangle> EnemyGel;
        List<Rectangle> EnemyZol;
        List<Rectangle> EnemyKeese;
        List<Rectangle> EnemyStalfol;
        List<Rectangle> StalfosSword;
        List<Rectangle> EnemyGoriyaup;
        List<Rectangle> EnemyGoriyadown;
        List<Rectangle> EnemyGoriyaleft;
        List<Rectangle> EnemyGoriyaright;
        List<Rectangle> EnemyProjectile;
        List<Rectangle> EnemyWallmaster;
        List<Rectangle> EnemyBladeTrap;
        public int currentSprite { get; set; }
        Vector2 EnemyPosition;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            EnemyGel = new List<Rectangle>();
            EnemyZol = new List<Rectangle>();
            EnemyKeese = new List<Rectangle>();
            EnemyStalfol = new List<Rectangle>();
            StalfosSword = new List<Rectangle>();
            EnemyGoriyaup = new List<Rectangle>();
            EnemyGoriyadown = new List<Rectangle>();
            EnemyGoriyaleft = new List<Rectangle>();
            EnemyGoriyaright = new List<Rectangle>();
            EnemyProjectile = new List<Rectangle>();
            EnemyWallmaster = new List<Rectangle>();
            EnemyBladeTrap = new List<Rectangle>();

            controllerList = new ArrayList();
            sprites = new ArrayList();
            // Need discuss where to initialize
            EnemyPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2 + 100,
                                  _graphics.PreferredBackBufferHeight / 2);
            keyboardController = new KeyboardController();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load the texture for the sprite sheet
            Texture2D texture = Content.Load<Texture2D>("enemySpriteSheetNew");

            SpriteFactory spriteFactory = new SpriteFactory(_spriteBatch, texture);

            // Use the factory to create the sprites
            Gel = spriteFactory.CreateGel();
            Zol = spriteFactory.CreateZol();
            Keese = spriteFactory.CreateKeese();
            Stalfol = spriteFactory.CreateStalfol();
            Goriya = spriteFactory.CreateGoriya();
            Wallmaster = spriteFactory.CreateWallmaster();
            BladeTrap = spriteFactory.CreateBladeTrap();

            sprites.Add(Gel);
            sprites.Add(Zol);
            sprites.Add(Keese);
            sprites.Add(Stalfol);
            sprites.Add(Goriya);
            sprites.Add(Wallmaster);
            sprites.Add(BladeTrap);
            // TODO: use this.Content to load your game content here

            keyboardController.RegisterCommand(Keys.O, new PreviousSpriteCommand(this));
            keyboardController.RegisterCommand(Keys.P, new NextSpriteCommand(this));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            IEnemy current = (IEnemy)sprites[currentSprite];
            current.Draw();
            base.Draw(gameTime);
        }
    }
}
