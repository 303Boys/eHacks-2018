using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace eHacks_2018
{
    class LevelEdit
    {
        private bool enable;
        private bool newlyEnabled;
        private bool toggleMouseDisable;
        private bool F12PressedDown;
        private bool F11PressedDown;
        private bool F10PressedDown;
        private bool paintMode;
        private bool clickPressedDown;

        public LevelEdit(bool enable)
        {
            this.enable = enable;
        }

        public void checkState(Game1 master, Level level, List<Texture2D> sprites)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.F12) && !F12PressedDown)
            {
                if (enable)
                {
                    enable = false;
                    newlyEnabled = false;
                    master.IsMouseVisible = false;
                    System.Diagnostics.Debug.WriteLine("Disabling Edit mode");
                }
                else
                {
                    enable = true;
                    newlyEnabled = true;
                    System.Diagnostics.Debug.WriteLine("Enabling Edit mode");
                }

                F12PressedDown = true;
            }
            else if (!Keyboard.GetState().IsKeyDown(Keys.F12))
            {
                F12PressedDown = false;
            }

            if (newlyEnabled)
            {
                master.IsMouseVisible = true;
                newlyEnabled = false;
            }

            if (toggleMouseDisable)
            {
                master.IsMouseVisible = false;
                toggleMouseDisable = false;
            }

            checkMouse(level, sprites);

            if (Keyboard.GetState().IsKeyDown(Keys.F11) && !F11PressedDown)
            {
                dumpLevel(level);
                F11PressedDown = true;
            }
            else if (!Keyboard.GetState().IsKeyDown(Keys.F11))
            {
                F11PressedDown = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F10) && !F10PressedDown)
            {
                if (paintMode)
                {
                    paintMode = false;
                    System.Diagnostics.Debug.WriteLine("Disabling Paint mode");
                }
                else
                {
                    paintMode = true;
                    System.Diagnostics.Debug.WriteLine("Enabling Paint mode");
                }

                F10PressedDown = true;
            }
            else if (!Keyboard.GetState().IsKeyDown(Keys.F10))
            {
                F10PressedDown = false;
            }
        }

        public void setEnable(bool state)
        {
            this.enable = state;
            this.newlyEnabled = state;

            if (!state)
            {
                toggleMouseDisable = true;
            }
        }

        private void checkMouse(Level level, List<Texture2D> sprites)
        {
            if (enable)
            {
                if (!paintMode)
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed && !clickPressedDown)
                    {
                        level.thingList.Add(new Thing(new Vector2(Mouse.GetState().X, Mouse.GetState().Y), new System.Drawing.RectangleF(Mouse.GetState().X, Mouse.GetState().Y, 25, 25), sprites[0]));

                        clickPressedDown = true;
                    }
                    else if (!(Mouse.GetState().LeftButton == ButtonState.Pressed))
                    {
                        clickPressedDown = false;
                    }
                }
                else
                {
                    if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    {
                        level.thingList.Add(new Thing(new Vector2(Mouse.GetState().X, Mouse.GetState().Y), new System.Drawing.RectangleF(Mouse.GetState().X, Mouse.GetState().Y, 25, 25), sprites[0]));

                        clickPressedDown = true;
                    }
                }
            }
        }

        private void dumpLevel(Level level)
        {
            if (enable) {
                String filename = "\\..\\EditLevel.level";
                System.Diagnostics.Debug.WriteLine("Saving file to " + System.Reflection.Assembly.GetExecutingAssembly().Location + filename);
                String file;

                file = level.getName() + ',' + level.getSize().X + ',' + level.getSize().Y + ',' + level.getGravity() + '\n';

                for(int i = 0; i < level.getPlayerSpawns().Count; i++)
                {
                    file += level.getPlayerSpawns()[i].X + "," + level.getPlayerSpawns()[i].Y + ",";
                }
                file += '\n';

                for(int i = 0; i < level.thingList.Count; i++)
                {
                    file += level.thingList[i].spriteName + ',' + level.thingList[i].getPosition().X + ',' + level.thingList[i].getPosition().Y + ',';
                }

                System.IO.File.WriteAllText(@System.Reflection.Assembly.GetExecutingAssembly().Location + filename, file);

                System.Diagnostics.Debug.WriteLine(file);
            }
        }
    }
}
