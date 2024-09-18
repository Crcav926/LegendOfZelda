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
        Game1 myGame;
        private List<Keys> alrPressed;
        private List<Keys> unPressList;
        // constructor
        public KeyboardCont(Game1 game)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            myGame = game;
            alrPressed = new List<Keys>();
            
            // set up teh table
            ICommand c = new CommQuit(game);
            ICommand a = new CommLinkLeft(game);
            ICommand d = new CommLinkRight(game);
            ICommand quit = new CommQuit(game);
            ICommand arrow = new ArrowComm(game);
            ICommand boomerang =new BoomerangComm(game);
            ICommand nextItem = new NextItemComm(game);
            ICommand lastItem = new LastItemComm(game);

            RegisterCommand(Keys.D0, quit);
            RegisterCommand(Keys.A, a);
            RegisterCommand(Keys.D, d);
            RegisterCommand(Keys.Q, c);
            RegisterCommand(Keys.D1, arrow);
            RegisterCommand(Keys.D2 , boomerang);
            RegisterCommand(Keys.I, nextItem);
            RegisterCommand(Keys.U, lastItem);


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
                alrPressed.Remove(key);
            }
        }
    }
}
