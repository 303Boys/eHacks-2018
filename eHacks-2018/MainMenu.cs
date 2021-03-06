﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading.Tasks;

namespace eHacks_2018
{
    struct Size
    {
        public int height { get; private set; }

        public int width { get; private set; }

        public Size(int width, int height) : this()
        {
            this.height = height;
            this.width = width;

        }
    }
    class MainMenu
    {
        public enum GameState { mainMenu, enterName, inGame,LevelSelect }
        public GameState gameState;
        private string name = string.Empty;
        private bool caps;
        private List<List<GUIElement>> menus;
        private Keys[] lastPressedKeys = new Keys[1];
        SpriteFont sf;
        ReadLevel levelLoader;
        Game1 master;
        List<Texture2D> sprites;

        public MainMenu(ReadLevel levelLoader, Game1 master)
        {
            this.levelLoader = levelLoader;
            this.master = master;
            //Adds lists of GUI elements to the menu list
            menus = new List<List<GUIElement>>
            {   //MainMenu
                (new List<GUIElement>
                {
                    new GUIElement("menu"),
                    new GUIElement("nameBtn"),
                    new GUIElement("play"),
                }),
                //Enter name menu
                (new List<GUIElement>
                {
                    new GUIElement("name"),
                    new GUIElement("done"),
                }),
                //Choose level menu
                (new List<GUIElement>
                {
                    new GUIElement("menu"),
                    new GUIElement("Levels"),
                    new GUIElement("Level1"),
                    new GUIElement("Level2"),
                    new GUIElement("Level3"),
                })

            };

            for (int i = 0; i < menus.Count; i++)
            {
                foreach (GUIElement button in menus[i])
                {
                    button.clickEvent += OnClick;
                }
            }
        }

        public void LoadContent(ContentManager content, Size windowSize)
        {
            //Loads the content of our spritefont
            sf = content.Load<SpriteFont>("MyFont");

            //Loads the content of all other GUI elements
            for (int i = 0; i < menus.Count; i++)
            {
                foreach (GUIElement button in menus[i])
                {
                    button.LoadContent(content);
                    button.CenterElement(windowSize);
                }
            }
            //Sets offsets of the buttons
            menus[0].Find(x => x.ElementName == "play").MoveElement(0, -100);
            //menus[0].Find(x => x.ElementName == "Levels").MoveElement(0, -40);
            menus[0].Find(x => x.ElementName == "nameBtn").MoveElement(0, -40);
            menus[1].Find(x => x.ElementName == "done").MoveElement(0, 60);
            menus[2].Find(x => x.ElementName == "Levels").MoveElement(0, -100);
            menus[2].Find(x => x.ElementName == "Level1").MoveElement(0, -40);
            menus[2].Find(x => x.ElementName == "Level2").MoveElement(0,  20);
            menus[2].Find(x => x.ElementName == "Level3").MoveElement(0, 80);

        }

        public void Update()
        {
            //Update each element according to the current gameState
            switch (gameState)
            {
                case GameState.mainMenu:
                    foreach (GUIElement button in menus[0]) //MainMenu
                    {
                        button.Update();
                    }
                    break;
                case GameState.enterName:
                    foreach (GUIElement button in menus[1])//EnterName menu
                    {
                        GetKeys();
                        button.Update();
                    }
                    break;
                case GameState.LevelSelect:
                    foreach (GUIElement button in menus[2])//Level Select menu
                    {
                        button.Update();
                    }
                    break;
                case GameState.inGame: //Ingame GUI
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draws each element according to the current gameState
            switch (gameState)
            {
                case GameState.mainMenu:
                    foreach (GUIElement button in menus[0]) //MainMenu
                    {
                        button.Draw(spriteBatch);
                    }
                    break;
                case GameState.enterName:
                    foreach (GUIElement button in menus[1])//EnterName menu
                    {
                        spriteBatch.DrawString(sf, name, new Vector2(305, 300), Color.Black);
                        button.Draw(spriteBatch);
                    }
                    break;
                    case GameState.LevelSelect:
                    foreach (GUIElement button in menus[2])//Level Select menu
                    {
                        button.Draw(spriteBatch);
                    }
                    break;
                case GameState.inGame://Ingame GUI
                    break;
            }

        }

        public void OnClick(string element)
        {
            if (element == "play")//PlayButton
            {
                gameState = GameState.LevelSelect;
            }
            if (element == "nameBtn")//EnterName button
            {
                gameState = GameState.enterName;
            }
            if (element == "done")//Done button
            {
                gameState = GameState.mainMenu;
            }
            if (element == "Level1")//Level1 button
            {
                levelLoader.CreateLevel(System.Reflection.Assembly.GetExecutingAssembly().Location + "../../Content/Levels/level1.level", sprites);
                master.recieveLevel(levelLoader.returnLevel());
                gameState = GameState.inGame;
                master.IsMouseVisible = false;
            }
            if (element == "Level2")//Level2 button
            {
                levelLoader.CreateLevel(System.Reflection.Assembly.GetExecutingAssembly().Location + "../../Content/Levels/level2.level", sprites);
                master.recieveLevel(levelLoader.returnLevel());
                gameState = GameState.inGame;
                master.IsMouseVisible = false;
            }
            if (element == "Level2")//Level2 button
            {
                levelLoader.CreateLevel(System.Reflection.Assembly.GetExecutingAssembly().Location + "../../Content/Levels/level3.level", sprites);
                master.recieveLevel(levelLoader.returnLevel());
                gameState = GameState.inGame;
                master.IsMouseVisible = false;
            }
        }

        private void GetKeys()
        {
            KeyboardState kbState = Keyboard.GetState();
            Keys[] pressedKeys = kbState.GetPressedKeys();

            //check if any of the previous update's keys are no longer pressed
            foreach (Keys key in lastPressedKeys)
            {
                if (!pressedKeys.Contains(key))
                    OnKeyUp(key);
            }

            //check if the currently pressed keys were already pressed
            foreach (Keys key in pressedKeys)
            {
                if (!lastPressedKeys.Contains(key))
                    OnKeyDown(key);
            }
            //save the currently pressed keys so we can compare on the next update
            lastPressedKeys = pressedKeys;
        }

        private void OnKeyDown(Keys key)
        {
            //do stuff
            if (key == Keys.Back && name.Length > 0) //Removes a letter from the name if there is a letter to remove
            {
                name = name.Remove(name.Length - 1);
            }
            else if (key == Keys.LeftShift || key == Keys.RightShift)//Sets caps to true if a shift key is pressed
            {
                caps = true;
            }
            else if (!caps && name.Length < 16) //If the name isn't too long, and !caps the letter will be added without caps
            {
                if (key == Keys.Space)
                {
                    name += " ";
                }
                else
                {
                    name += key.ToString().ToLower();
                }
            }
            else if (name.Length < 16) //Adds the letter to the name in CAPS
            {
                name += key.ToString();
            }
        }

        private void OnKeyUp(Keys key)
        {
            //Sets caps to false if one of the shift keys goes up
            if (key == Keys.LeftShift || key == Keys.RightShift)
            {
                caps = false;
            }
        }

        public void recieveSprites(List<Texture2D> sprites)
        {
            this.sprites = sprites;
        }
    }
}
