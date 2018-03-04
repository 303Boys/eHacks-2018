using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace eHacks_2018
{
    public static class Sounds
    {
        static List<SoundEffect> sounds = new List<SoundEffect>();
        static List<Song> music = new List<Song>();

        public static void readSoundFiles(Game1 master)
        {
            sounds.Add(master.Content.Load<SoundEffect>("Sounds/Explosion"));
            sounds.Add(master.Content.Load<SoundEffect>("Sounds/Jump"));
            sounds.Add(master.Content.Load<SoundEffect>("Sounds/Jump2"));
            sounds.Add(master.Content.Load<SoundEffect>("Sounds/Jump3"));
            sounds.Add(master.Content.Load<SoundEffect>("Sounds/Jump4"));
            sounds.Add(master.Content.Load<SoundEffect>("Sounds/Shoot"));
            sounds.Add(master.Content.Load<SoundEffect>("Sounds/Hit"));

            music.Add(master.Content.Load<Song>("Music/reg3"));
        }

        public static SoundEffect returnSound(string name)
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

        public static Song returnSong(string name)
        {
            for (int i = 0; i < music.Count; i++)
            {
                if (music[i].Name == "Music/" + name)
                {
                    return music[i];
                }
            }

            return music[0];
        }
    }
}
