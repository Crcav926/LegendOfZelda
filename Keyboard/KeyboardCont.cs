 using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
            controllerMappings = new Dictionary<Keys, ICommand>();
            heldDownMappings = new Dictionary<Keys, ICommand>();
            releaseMappings = new Dictionary<Keys, ICommand>();

            myGame = game;
            alrPressed = new List<Keys>();
            
            // set up teh table
            ICommand c = new CommQuit(game);
            ICommand a = new CommLinkLeft(game);
            ICommand d = new CommLinkRight(game);
            ICommand w = new CommLinkUp(game);
            ICommand s = new CommLinkDown(game);
            ICommand quit = new CommQuit(game);
            ICommand arrow = new ArrowComm(game);
            ICommand boomerang =new BoomerangComm(game);
            ICommand nextItem = new NextItemComm(game);
            ICommand lastItem = new LastItemComm(game);
            ICommand nextBlock = new NextBlockComm(game);
            ICommand lastBlock = new LastBlockComm(game);

            RegisterCommand(Keys.D0, quit);
            RegisterCommand(Keys.W, w);
            RegisterCommand(Keys.S, s);
            RegisterCommand(Keys.A, a);
            RegisterCommand(Keys.D, d);
            RegisterCommand(Keys.Q, c);
            RegisterCommand(Keys.D1, arrow);
            RegisterCommand(Keys.D2 , boomerang);
            RegisterCommand(Keys.I, nextItem);
            RegisterCommand(Keys.U, lastItem);
            RegisterCommand(Keys.T, lastBlock);
            RegisterCommand(Keys.Y, nextBlock);


            // set up held down table

            ICommand left = new CommLinkLeftM(game);
            ICommand right = new CommLinkRightM(game);
            ICommand up = new CommLinkUpM(game);
            ICommand down = new CommLinkDownM(game);

            heldDownMappings.Add(Keys.A, left);
            heldDownMappings.Add(Keys.D, right);
            heldDownMappings.Add(Keys.W, up);
            heldDownMappings.Add(Keys.S, down);



        }
        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }

        public void Update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {

                if (controllerMappings.ContainsKey(key))
                {
                    if (!alrPressed.Contains(key))
                    {
                        controllerMappings[key].Execute();
                        alrPressed.Add(key);
                    }

                }
                if (heldDownMappings.ContainsKey(key))
                {
                    heldDownMappings[key].Execute();
                }
            }
            // remove unpressed keys

            unPressList = new List<Keys>();
            foreach (Keys key in alrPressed)
            {
                if (!pressedKeys.Contains(key))
                {
                    unPressList.Add(key);
                }
            }
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
