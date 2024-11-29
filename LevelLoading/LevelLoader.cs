using LegendOfZelda.Command;
using LegendOfZelda.LinkMovement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Enumeration;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Xml;
using Microsoft.Xna.Framework.Audio;
using LegendOfZelda.Sounds;
using LegendOfZelda.HUD;

namespace LegendOfZelda
{
    internal class LevelLoader
    {
        private List<ICollideable> statics = new List<ICollideable>();
        private List<ICollideable> movers = new List<ICollideable>();
        public String room;
        private Link link;
        SoundMachine soundMachine = SoundMachine.Instance;
        private Room currRoom;
        private Dictionary<String, Room> roomMapping = new Dictionary<string, Room>();

        public LevelLoader() 
        {
        }

        private static LevelLoader instance = new LevelLoader();

        public static LevelLoader Instance
        {
            get
            {
                return instance;
            }
        }
        public void LoadAllContent(ContentManager Content)
        {
            // Load the texture for the sprite sheet
            ItemSpriteFactory.Instance.LoadAllTextures(Content);
            EnemySpriteFactory.Instance.LoadAllTextures(Content);
            BlockSpriteFactory.Instance.LoadAllTextures(Content);
            LinkSpriteFactory.Instance.LoadAllTextures(Content);

            this.link = Link.Instance;
            
            //the instances must be made to allow us to modify the sounds. (make miku quieter)
            //sounds
            SoundEffectInstance attackMod = Content.Load<SoundEffect>("mikuAttack").CreateInstance();
            attackMod.Volume = .5f;
            SoundEffectInstance hurtMod = Content.Load<SoundEffect>("mikuHurt").CreateInstance();
            SoundEffectInstance haMod = Content.Load<SoundEffect>("mikuHa").CreateInstance();
            SoundEffectInstance enemyHurtMod = Content.Load<SoundEffect>("enemyHurt").CreateInstance();
            SoundEffectInstance getRupeeMod = Content.Load<SoundEffect>("getRupeeSound").CreateInstance();
            SoundEffectInstance aquaRoarMod = Content.Load<SoundEffect>("aquaRoar").CreateInstance();
            SoundEffectInstance getTriMod = Content.Load<SoundEffect>("getTri").CreateInstance();
            SoundEffectInstance throughDoor = Content.Load<SoundEffect>("thruDoor").CreateInstance();
            SoundEffectInstance unlock = Content.Load<SoundEffect>("unlock").CreateInstance();
            SoundEffectInstance moveBlock = Content.Load<SoundEffect>("moveBlock").CreateInstance();
            SoundEffectInstance deathMod = Content.Load<SoundEffect>("death").CreateInstance();

            soundMachine.addSound("throughDoor", throughDoor);
            soundMachine.addSound("moveBlock", moveBlock);
            soundMachine.addSound("unlock", unlock);
            soundMachine.addSound("getTri", getTriMod);
            soundMachine.addSound("aquaRoar", aquaRoarMod);
            soundMachine.addSound("getRupee", getRupeeMod);
            soundMachine.addSound("enemyHurt", enemyHurtMod);
            soundMachine.addSound("attack", attackMod);
            soundMachine.addSound("hurt", hurtMod);
            soundMachine.addSound("ha", haMod);
            soundMachine.addSound("death", deathMod);

            //I'll keep the theme song loaded here so it doesn't reset on room changes
            SoundEffectInstance mikuSong = Content.Load<SoundEffect>("mikuSong").CreateInstance();
            mikuSong.IsLooped = true;
            mikuSong.Volume = .3f;

            soundMachine.addSound("theme", mikuSong);

        }
        public void Load(String room)
        {
            this.room = room;
            Parsing2 parseIt = new Parsing2(room);
            statics = parseIt.getBlocks();
            movers = parseIt.getMovers();
            movers.Add(link);
            RoomObjectManager.Instance.addLink(link);
            currRoom = new Room(statics, movers, room);
            // Sorts through each item in the list and parses through.
            if (!roomMapping.ContainsKey(room))
            {
                roomMapping.Add(room, currRoom);
            }
        }
        private void loadSounds()
        {

        }
        public void RegisterAllCommands(KeyboardCont cont, Game1 game)
        {

            cont.RegisterCommand(Keys.D0, new CommQuit(game));
            cont.RegisterCommand(Keys.W, new CommLinkMove(link, new Vector2(0, -1)));
            cont.RegisterCommand(Keys.S, new CommLinkMove(link, new Vector2(0, 1)));
            cont.RegisterCommand(Keys.A, new CommLinkMove(link, new Vector2(-1, 0)));
            cont.RegisterCommand(Keys.D, new CommLinkMove(link, new Vector2(1, 0)));
            cont.RegisterCommand(Keys.E, new CommLinkDamaged(link));
            cont.RegisterCommand(Keys.D1, new LinkAttack1());
            cont.RegisterCommand(Keys.D2, new LinkAttack2());
            cont.RegisterCommand(Keys.Q, new CommQuit(game));
            cont.RegisterCommand(Keys.R, new CommReset(game, link));
           
            cont.RegisterCommand(Keys.D3, new RotateItems());
          

            //For menu and pause
            cont.RegisterCommand(Keys.P, new CommPause(game));
            cont.RegisterCommand(Keys.Enter, new CommStart(game));
            cont.RegisterCommand(Keys.N, new CommMode(game));
            cont.RegisterCommand(Keys.M, new CommTex(game));


            cont.registerHeldDown(Keys.A, new CommMoveHeldDown(link, new Vector2(-1, 0)));
            cont.registerHeldDown(Keys.D, new CommMoveHeldDown(link, new Vector2(1, 0)));
            cont.registerHeldDown(Keys.W, new CommMoveHeldDown(link, new Vector2(0, -1)));
            cont.registerHeldDown(Keys.S, new CommMoveHeldDown(link, new Vector2(0, 1)));

            cont.registerRelease(Keys.A, new CommStopMoving(link, new Vector2(-1, 0)));
            cont.registerRelease(Keys.D, new CommStopMoving(link, new Vector2(1, 0)));
            cont.registerRelease(Keys.W, new CommStopMoving(link, new Vector2(0, -1)));
            cont.registerRelease(Keys.S, new CommStopMoving(link, new Vector2(0, 1)));
        }
        public List<ICollideable> getBlocks()
        {
            return statics;
        }
        public List<ICollideable> getMovers()
        {
            return movers;
        }
        public string getRoom()
        {
            return room;
        }
        public Dictionary<String, Room> getRooms()
        {
            return roomMapping;
        }
        public void changeCurrentRoom(String s)
        {
            currRoom =  roomMapping[s];
        }
        public Room getCurrentRoom()
        {
            return currRoom;
        }

        //for reset
        public void Reset()
        {
            statics.Clear();
            movers.Clear();
            roomMapping.Clear();
            currRoom = null;
            room = null;
        }
    }
}
