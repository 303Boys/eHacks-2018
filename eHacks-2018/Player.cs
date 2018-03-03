﻿using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace eHacks_2018
{
	public class Player : Thing
	{
		private float hmax = 80f;
		private float vmax = -360f;
		public bool grounded; //1 on ground, 0 if else
		public int facing; //1 facing right, -1 facing left
		public float hspeed; //horizontal speed
		public float vspeed; //vertical speed
		public float accel; //acceleration
		public float haccel; //acceleration
		public float vaccel; //acceleration
		public Weapon curWep;
		public Controls controls;
		public int health;

		public Player(Vector2 pos, RectangleF rect, string name) : base(pos, rect, name)
		{
			hspeed = 0f;
			vspeed = 0f;
			accel = 0f;
			controls = new Controls(1);
		}//end Player() construction



		public void movementCheck(GameTime gameTime, Level level)
		{
			controls.movementUpdate();

			if (controls.left) { haccel = 1.0f; facing = -1; }
			else if (controls.right) { haccel = 1.0f; facing = 1; }
			//else { hspeed = 0f; }
			if (controls.jump && grounded) { jump(); }
			hspeed = haccel * hmax * facing;
			vspeed = vaccel * vmax;
			handleMove(gameTime, level);
			vaccel -= 0.05f;
			haccel -= 0.05f;
			if (vaccel < 0.0f) { vaccel = 0.0f; }
			if (haccel < 0.0f) { haccel = 0.0f; }

		}

		public void handleMove(GameTime gameTime, Level level) 
		{ 
			position.X += hspeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
			position.Y += (vspeed + 160f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
			colbox.X = position.X;
			colbox.Y = position.Y;

			for (int i = 0; i < level.thingList.Count; i++) 
			{
				if (colCheck(level.thingList[i].colbox))
				{
					break;
				}
			}
		}

		public void groundCheck()
		{
			//TODO
			//grounded = true;
		}

		public bool colCheck(RectangleF rect)
		{
			bool coll = false;
			RectangleF temp = RectangleF.Intersect(this.colbox, rect);
			grounded = false;

			if (temp.Height > temp.Width && !temp.IsEmpty)
			{
				// left/right collision
				RectangleF temp2 = colbox;
				temp2.X += 1;
				temp2 = RectangleF.Intersect(temp2, rect);
				if (temp2.Width > temp.Width)
				{
					//left collision
					colbox.X = rect.X - colbox.Width;
					coll = true;
				}
				else
				{
					//right collision
					colbox.X = rect.X + rect.Width;
					coll = true;
				}
			}
			else if (temp.Width > temp.Height && !temp.IsEmpty)
			{
				// up/down collision
				RectangleF temp2 = colbox;
				temp2.Y += 1;
				temp2 = RectangleF.Intersect(temp2, rect);
				if (temp2.Height > temp.Height)
				{
					//top collision
					colbox.Y = rect.Y - colbox.Height;
					coll = true;
					grounded = true;
				}
				else
				{
					//bottom collision
					colbox.Y = rect.Y + rect.Height;
					coll = true;
				}
			}

			position.X = colbox.X;
			position.Y = colbox.Y;

			return coll;
		}

		public void jump()
		{
			//TODO
			vaccel = 1.0f;
		}


		public void shoot()
		{
			//TODO
		}
	}
}
