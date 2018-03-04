using System;
using System.Drawing;
using XNAF = Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media;

namespace eHacks_2018
{
    public class RawLevelData
    {
        public string name;
        public XNAF.Vector2 size;
        public float gravity;
        public List<string> spriteNames = new List<string>();

        public List<XNAF.Vector2> thingPos = new List<XNAF.Vector2>();
        public List<int> thingTypes = new List<int>();
        public List<XNAF.Vector2> playerSpawns = new List<XNAF.Vector2>();

        public RawLevelData(string name, XNAF.Vector2 size, float gravity)
        {
            this.name = name;
            this.size = size;
            this.gravity = gravity;
        }

        public RawLevelData(string name, XNAF.Vector2 size, float gravity, List<string> spriteNames, List<XNAF.Vector2> thingPos, List<int> thingTypes)
        {
            this.name = name;
            this.size = size;
            this.gravity = gravity;
            this.spriteNames = spriteNames;
            this.thingPos = thingPos;
            this.thingTypes = thingTypes;
        }
    }

	public class Level
	{
        private string name;
        private XNAF.Vector2 size;
        public List<Thing> thingList;
        private List<XNAF.Vector2> playerSpawns;
        public float gravity;
        public List<Player> players = new List<Player>();

		public Level(string name, XNAF.Vector2 size, float gravity, List<XNAF.Vector2> playerSpawns)
		{
            this.name = name;
            this.size = size;
            this.playerSpawns = playerSpawns;
            this.players.Add(new Player(playerSpawns[0], new RectangleF(playerSpawns[0].X, playerSpawns[0].Y, 25, 25), "Player1", 1));
			this.players.Add(new Player(playerSpawns[1], new RectangleF(playerSpawns[1].X, playerSpawns[1].Y, 25, 25), "Player2", 2));
            this.players.Add(new Player(playerSpawns[2], new RectangleF(playerSpawns[2].X, playerSpawns[2].Y, 25, 25), "Player3", 3));
            this.players.Add(new Player(playerSpawns[3], new RectangleF(playerSpawns[3].X, playerSpawns[3].Y, 25, 25), "Player4", 4));
            this.gravity = gravity;
		}

        public SpriteBatch draw(SpriteBatch spriteBatch, List<Texture2D> textures)
        {
           // spriteBatch.Begin();
            for(int i = 0; i < thingList.Count; i++)
            {
                spriteBatch.Draw(thingList[i].sprite, thingList[i].getPosition(), XNAF.Color.White);
            }
            for(int i = 0; i < players.Count; i++)
            {
                spriteBatch.Draw(players[i].sprite, players[i].getPosition(), XNAF.Color.White);
                spriteBatch.DrawString(Fonts.healthFont, players[i].health.ToString(), new XNAF.Vector2(players[i].getPosition().X + 3, players[i].getPosition().Y - 15), XNAF.Color.Black);
            }
            //spriteBatch.End();

            return spriteBatch;
        }

        public void loadThings(List<Texture2D> textures, List<string> spriteNames, List<XNAF.Vector2> thingPos, List<int> thingTypes)
        {
            thingList = new List<Thing>();
            players[0].sprite = textures[3];
			players[0].curWep.sprite = textures[1];
			players[1].sprite = textures[4];
			players[1].curWep.sprite = textures[1];
            players[2].sprite = textures[5];
            players[2].curWep.sprite = textures[1];
            players[3].sprite = textures[6];
            players[3].curWep.sprite = textures[1];
            this.thingList.Add(players[0].curWep);
			this.thingList.Add(players[1].curWep);
            this.thingList.Add(players[2].curWep);
            this.thingList.Add(players[3].curWep);
            for (int i = 0; i < thingTypes.Count; i++)
            {
                switch (thingTypes[i])
                {
                    case 0: thingList.Add(new Thing(thingPos[i], new RectangleF(thingPos[i].X, thingPos[i].Y, 25, 25), findTexture(textures, spriteNames[i]))); break;
                    case 1: thingList.Add(new Wall(thingPos[i], new RectangleF(thingPos[i].X, thingPos[i].Y, 25, 25), findTexture(textures, spriteNames[i]))); break;
                    case 2: thingList.Add(new Door(thingPos[i], new RectangleF(thingPos[i].X, thingPos[i].Y, 25, 25), findTexture(textures, spriteNames[i]), findTexture(textures, spriteNames[spriteNames.Count - 1]))); break;
                }
            }

            MediaPlayer.Play(Sounds.returnSong("reg3"));
            MediaPlayer.IsRepeating = true;
        }

        public string getName()
        {
            return this.name;
        }

        public XNAF.Vector2 getSize()
        {
            return this.size;
        }

        public float getGravity()
        {
            return this.gravity;
        }

        public List<XNAF.Vector2> getPlayerSpawns()
        {
            return this.playerSpawns;
        }

        private Texture2D findTexture(List<Texture2D> textures, string name)
        {
            for(int i = 0; i < textures.Count; i++)
            {
                if(textures[i].Name == name)
                {
                    return textures[i];
                }
            }

            //Sprite not found, returning simpleBlock
            return textures[0];
        }
    }
}
