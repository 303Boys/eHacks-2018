using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace eHacks_2018
{
	public class Player : Thing
	{
		public bool grounded; //1 on ground, 0 if else
		public bool facing; //0 facing right, 1 facing left
		public float hspeed; //horizontal speed
		public float vspeed; //vertical speed
		public float accel; //acceleration
		public Weapon curWep;
		public Controls controls;
		public int health;

		public Player(Vector2 pos, RectangleF rect, string name) : base(pos, rect, name)
		{
			hspeed = 0f;
			vspeed = 0f;
			accel = 0f;
			controls = new Controls();
		}//end Player() construction



		public void movementCheck(GameTime gameTime, Level level)
		{
			controls.movementUpdate();

			if (controls.left) { hspeed = -50f; }
			else if (controls.right) { hspeed = 50f; }
			else { hspeed = 0f; }
			if (controls.jump && grounded) { jump(); }
			handleMove(gameTime, level);

		}

		public void handleMove(GameTime gameTime, Level level) 
		{ 
			position.X += hspeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
			position.Y += (vspeed + 80f) * (float)gameTime.ElapsedGameTime.TotalSeconds;
			colbox.X = position.X;
			colbox.Y = position.Y;

			for (int i = 0; i < level.thingList.Count; i++) 
			{
				colCheck(level.thingList[i].colbox);
			}
		}

		public void groundCheck()
		{
			//TODO
			//grounded = true;
		}

		public void colCheck(RectangleF rect)
		{
			//TODO
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
				}
				else
				{
					//right collision
					colbox.X = rect.X + rect.Width;
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
					grounded = true;
				}
				else
				{
					//bottom collision
					colbox.Y = rect.Y + rect.Height;
				}
			}

			position.X = colbox.X;
			position.Y = colbox.Y;

		}

		public void jump()
		{
			//TODO
			vspeed = -300f;
		}


		public void shoot()
		{
			//TODO
		}
	}
}
