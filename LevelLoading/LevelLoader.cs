using LegendOfZelda.Command;
using LegendOfZelda.LinkItems;
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

namespace LegendOfZelda
{
    internal class LevelLoader
    {
        private List<ICollideable> statics;
        private List<ICollideable> movers;
        private String room;
        private Link link;

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
            this.link = new Link();
        }
        public void Load(String room)
        {
            this.room = room;
            Parsing parseIt = new Parsing(room);
            statics = parseIt.getBlocks();
            movers = parseIt.getMovers();
            movers.Add(link);
            RoomObjectManager.Instance.addLink(link);
            // Sorts through each item in the list and parses through.
            // Mainly testing by parsing through all rooms, but eventually have only cetain rooms have their information loaded.
        }
        public void RegisterAllCommands(KeyboardCont cont, Game1 game)
        {

            cont.RegisterCommand(Keys.D0, new CommQuit(game));
            cont.RegisterCommand(Keys.W, new CommLinkMove(link, new Vector2(0, -1)));
            cont.RegisterCommand(Keys.S, new CommLinkMove(link, new Vector2(0, 1)));
            cont.RegisterCommand(Keys.A, new CommLinkMove(link, new Vector2(-1, 0)));
            cont.RegisterCommand(Keys.D, new CommLinkMove(link, new Vector2(1, 0)));
            cont.RegisterCommand(Keys.E, new CommLinkDamaged(link));
            cont.RegisterCommand(Keys.D1, new CommThrowBoomerang(link));
            cont.RegisterCommand(Keys.D2, new CommShootArrow(link));
            cont.RegisterCommand(Keys.D3, new CommShootFire(link));
            cont.RegisterCommand(Keys.D4, new CommUseSword(link));
            cont.RegisterCommand(Keys.D5, new CommPlaceBomb(link));
            cont.RegisterCommand(Keys.Q, new CommQuit(game));
            cont.RegisterCommand(Keys.R, new CommReset(game));
            cont.RegisterCommand(Keys.Enter, new CommChangeRoom());


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
    }
}
