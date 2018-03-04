using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace eHacks_2018
{
    public static class Sounds
    {
        static List<Microsoft.Xna.Framework.Audio.SoundEffect> sounds = new List<Microsoft.Xna.Framework.Audio.SoundEffect>();

        public static void readSoundFiles(Game1 master)
        {
            sounds.Add(master.Content.Load<Microsoft.Xna.Framework.Audio.SoundEffect>("Sounds/Explosion"));
            sounds.Add(master.Content.Load<Microsoft.Xna.Framework.Audio.SoundEffect>("Sounds/Jump"));
            sounds.Add(master.Content.Load<Microsoft.Xna.Framework.Audio.SoundEffect>("Sounds/Jump2"));
            sounds.Add(master.Content.Load<Microsoft.Xna.Framework.Audio.SoundEffect>("Sounds/Jump3"));
            sounds.Add(master.Content.Load<Microsoft.Xna.Framework.Audio.SoundEffect>("Sounds/Jump4"));
            sounds.Add(master.Content.Load<Microsoft.Xna.Framework.Audio.SoundEffect>("Sounds/Shoot"));
        }

        public static Microsoft.Xna.Framework.Audio.SoundEffect returnSound(string name)
        {
            for(int i = 0; i < sounds.Count; i++)
            {
                if(sounds[i].Name == "Sounds/" + name)
                {
                    return sounds[i];
                }
            }

            return sounds[0];
        }
    }
}
