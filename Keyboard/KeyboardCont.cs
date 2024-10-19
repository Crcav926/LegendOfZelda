 using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LegendOfZelda.LinkMovement;
using LegendOfZelda.LinkItems;
using LegendOfZelda.Command;


namespace LegendOfZelda
{
    internal class KeyboardCont : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private Dictionary<Keys, ICommand> heldDownMappings;
        private Dictionary<Keys, ICommand> releaseMappings;
        Game1 myGame;
        private List<Keys> alrPressed;
        private List<Keys> unPressList;
        // constructor
        public KeyboardCont(Game1 game)
        {
            // Controller mappings holds the on press transition commands
            controllerMappings = new Dictionary<Keys, ICommand>();
            // these two are more self explanatory maps for while keys are held down and when a key is released
            heldDownMappings = new Dictionary<Keys, ICommand>();
            releaseMappings = new Dictionary<Keys, ICommand>();

            myGame = game;
            //keeps track of keys that were already pressed down to detect transition.
            alrPressed = new List<Keys>();


            // set up the table which can be later moved to a content loader

            ICommand c = new CommQuit(game);
            ICommand a = new CommLinkMove(game, new Vector2(-1, 0));
            ICommand d = new CommLinkMove(game, new Vector2(1, 0));
            ICommand w = new CommLinkMove(game, new Vector2(0, -1));
            ICommand s = new CommLinkMove(game, new Vector2(0, 1));
            ICommand throwBoomerang = new CommThrowBoomerang(game);
            //ICommand throwBomb = new CommThrowBomb(game);
            //ICommand throwFireball = new CommThrowFireball(game);
            ICommand e = new CommLinkDamaged(game);
            ICommand quit = new CommQuit(game);
            ICommand reset = new CommReset(game);

            RegisterCommand(Keys.D0, quit);
            RegisterCommand(Keys.W, w);
            RegisterCommand(Keys.S, s);
            RegisterCommand(Keys.A, a);
            RegisterCommand(Keys.D, d);
            RegisterCommand(Keys.E, e);
            RegisterCommand(Keys.D1, throwBoomerang);
            RegisterCommand(Keys.D2, new CommShootArrow(game));
            RegisterCommand(Keys.D3, new CommShootFire(game));
            RegisterCommand(Keys.D4, new CommUseSword(game));
            RegisterCommand(Keys.D5, new CommPlaceBomb(game));
            RegisterCommand(Keys.Q, c);
            RegisterCommand(Keys.U, new LastItemComm(game));
            RegisterCommand(Keys.I, new NextItemComm(game));
            RegisterCommand(Keys.R, reset);
            RegisterCommand(Keys.Enter, new CommChangeRoom());

            ICommand pSC = new PreviousSpriteCommand(game);
            ICommand nSC = new NextSpriteCommand(game);
            RegisterCommand(Keys.O, pSC);
            RegisterCommand(Keys.P, nSC);


            // set up held down table

            ICommand left = new CommMoveHeldDown(game, new Vector2(-1, 0));
            ICommand right = new CommMoveHeldDown(game, new Vector2(1, 0));
            ICommand up = new CommMoveHeldDown(game, new Vector2(0, -1));
            ICommand down = new CommMoveHeldDown(game, new Vector2(0, 1));

            heldDownMappings.Add(Keys.A, left);
            heldDownMappings.Add(Keys.D, right);
            heldDownMappings.Add(Keys.W, up);
            heldDownMappings.Add(Keys.S, down);

            ICommand leftStop = new CommStopMoving(game, new Vector2(-1, 0));
            ICommand rightStop = new CommStopMoving(game, new Vector2(1, 0));
            ICommand upStop = new CommStopMoving(game, new Vector2(0, -1));
            ICommand downStop = new CommStopMoving(game, new Vector2(0, 1));

            releaseMappings.Add(Keys.A, leftStop);
            releaseMappings.Add(Keys.D, rightStop);
            releaseMappings.Add(Keys.W, upStop);
            releaseMappings.Add(Keys.S, downStop);
            releaseMappings.Add(Keys.D1, new CommStopUsingWeapon(game));
            releaseMappings.Add(Keys.D2, new CommStopUsingWeapon(game));
            releaseMappings.Add(Keys.D3, new CommStopUsingWeapon(game));
            releaseMappings.Add(Keys.D4, new CommStopUsingWeapon(game));
            releaseMappings.Add(Keys.D5, new CommStopUsingWeapon(game));





        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            // get the keys that are currently pressed
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                // if the key has an on transition command mapped to it
                if (controllerMappings.ContainsKey(key))
                {
                    //and its transitioning and not being held
                    if (!alrPressed.Contains(key))
                    {
                        //execute the on transition command and add it to alr Pressed so that the transition command wont re-trigger
                        controllerMappings[key].Execute();
                        alrPressed.Add(key);
                    }

                }
                //also any key that is being pressed should execute its held down command if it has one
                if (heldDownMappings.ContainsKey(key))
                {
                    heldDownMappings[key].Execute();
                }
            }
            // remove unpressed keys

            //get a list of keys that were released
            unPressList = new List<Keys>();
            foreach (Keys key in alrPressed)
            {
                if (!pressedKeys.Contains(key))
                {
                    unPressList.Add(key);
                }
            }
            // execute their commands if they had them and remove them from the list of keys that were pressed
            foreach (Keys key in unPressList)
            {
                // This executes the command on key release
                if (releaseMappings.ContainsKey(key))
                {
                    releaseMappings[key].Execute();
                }
                alrPressed.Remove(key);
            }
        }
    }
}
