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
using Microsoft.Xna.Framework;


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
        }
        /*
         * Repeated code for now to be able to call different maps we need to add to, I'm sure we could
         * Find a way to consolidate
         */
        public void RegisterCommand(Keys key, ICommand command)
        {
            controllerMappings.Add(key, command);
        }
        public void registerHeldDown(Keys key, ICommand command) 
        {
            heldDownMappings.Add(key, command);
        }
        public void registerRelease(Keys key, ICommand command)
        {
            releaseMappings.Add(key, command);
        }

        public void Update()
        {
            
            // get the keys that are currently pressed
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            if (myGame.paused == false)
            {
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
            else
            {
                foreach (Keys key in pressedKeys)
                {
                    if (key == Keys.P)
                    {
                        //and its transitioning and not being held
                        if (!alrPressed.Contains(key))
                        {
                            //execute the on transition command and add it to alr Pressed so that the transition command wont re-trigger
                            controllerMappings[key].Execute();
                            alrPressed.Add(key);
                        }
                    }
                }
                //get a list of keys that were released
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
}
