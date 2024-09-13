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
        private List<Keys> alrPressed = new List<Keys>();
        private List<Keys> unPressList = new List<Keys>();
        // constructor
        public KeyboardCont(Game1 game)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            myGame = game;

            // set up teh table
            ICommand c = new CommQuit(game);
            ICommand a = new CommLinkLeft(game);
            ICommand d = new CommLinkRight(game);

            RegisterCommand(Keys.A, a);
            RegisterCommand(Keys.D, d);
            RegisterCommand(Keys.Q, c);


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
           
           int len = alrPressed.Count;
            
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
