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
        // constructor
        public KeyboardCont(Game1 game)
        {
            controllerMappings = new Dictionary<Keys, ICommand>();
            myGame = game;

            // set up teh table
            ICommand c = new CommQuit(game);

            
            RegisterCommand(Keys.D0, c);

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
            

            for (int i = 0; i < len; i++)
            {
                if (!pressedKeys.Contains(alrPressed[i]))
                {
                    alrPressed.Remove(alrPressed[i]);
                }
            }
        }
    }
}
