using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;

namespace LegendOfZelda.Sounds
{
    public class SoundMachine
    {
        private static readonly SoundMachine instance = new SoundMachine();

        private Dictionary<String, SoundEffect> soundDictionary = new Dictionary<String, SoundEffect>();
        public SoundMachine()
        {
            //initialize here
        }
        public static SoundMachine Instance
        {
            get { return instance; }
        }

        public void addSound(String name, SoundEffect effect)
        {
            soundDictionary[name] = effect;
        }

        public SoundEffect GetSound(String name)
        {
            return soundDictionary[name];
        }
    }
}
