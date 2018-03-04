using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace eHacks_2018
{
    public static class Fonts
    {
        public static SpriteFont healthFont;

        public static void readFonts(Game1 master)
        {
            healthFont = master.Content.Load<SpriteFont>("player_health");
        }
    }
}
