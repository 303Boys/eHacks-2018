﻿using System;
using System.Drawing;
using XNAF = Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace eHacks_2018
{
    public class RawLevelData
    {
        public string name;
        public XNAF.Vector2 size;
        public float gravity;
        public List<string> thingNames = new List<string>();
        public List<XNAF.Vector2> thingPos = new List<XNAF.Vector2>();
        public List<XNAF.Vector2> playerSpawns = new List<XNAF.Vector2>();

        public RawLevelData(string name, XNAF.Vector2 size, float gravity)
        {
            this.name = name;
            this.size = size;
            this.gravity = gravity;
        }

        public RawLevelData(string name, XNAF.Vector2 size, float gravity, List<string> thingNames, List<XNAF.Vector2> thingPos)
        {
            this.name = name;
            this.size = size;
            this.gravity = gravity;
            this.thingNames = thingNames;
            this.thingPos = thingPos;
        }
    }

	public class Level
	{
        private string name;
        private XNAF.Vector2 size;
        public List<Thing> thingList;
        private List<XNAF.Vector2> playerSpawns;
        private float gravity;
        public List<Player> players = new List<Player>();

		public Level(string name, XNAF.Vector2 size, float gravity, List<XNAF.Vector2> playerSpawns)
		{
            this.name = name;
            this.size = size;
            this.playerSpawns = playerSpawns;
            this.players.Add(new Player(playerSpawns[0], new RectangleF(playerSpawns[0].X, playerSpawns[0].Y, 25, 25), "Player1", 1));
			this.players.Add(new Player(playerSpawns[1], new RectangleF(playerSpawns[1].X, playerSpawns[1].Y, 25, 25), "Player2", 2));
		}

        public SpriteBatch draw(SpriteBatch spriteBatch, List<Texture2D> textures)
        {
            //spriteBatch.Begin();
            for(int i = 0; i < thingList.Count; i++)
            {
                spriteBatch.Draw(thingList[i].sprite, thingList[i].getPosition(), XNAF.Color.White);
            }
            for(int i = 0; i < players.Count; i++)
            {
                spriteBatch.Draw(players[i].sprite, players[i].getPosition(), XNAF.Color.White);
            }
            //spriteBatch.End();

            return spriteBatch;
        }

        public void loadThings(List<Texture2D> textures, List<string> thingNames, List<XNAF.Vector2> thingPos)
        {
            thingList = new List<Thing>();
            players[0].sprite = textures[3];
			players[0].curWep.sprite = textures[1];
			players[1].sprite = textures[4];
			players[1].curWep.sprite = textures[1];
			this.thingList.Add(players[0].curWep);
			this.thingList.Add(players[1].curWep);
            for(int i = 0; i < thingNames.Count; i++)
            {
				thingList.Add(new Wall(thingPos[i], new RectangleF(thingPos[i].X, thingPos[i].Y, 25, 25), textures[0]));
            }
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
    }
}
