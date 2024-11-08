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

        private Dictionary<String, SoundEffectInstance> soundDictionary = new Dictionary<String, SoundEffectInstance>();
        public SoundMachine()
        {
            //initialize here
        }
        public static SoundMachine Instance
        {
            get { return instance; }
        }

        public void addSound(String name, SoundEffectInstance effect)
        {
            soundDictionary[name] = effect;
        }

        public SoundEffectInstance GetSound(String name)
        {
            return soundDictionary[name];
        }
    }
}
