using System;
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
		public int grounded; //0 on ground, 1 if else
		public bool shootPressed;
		public int facing; //1 facing right, -1 facing left
		public int prevface;
		public float hspeed; //horizontal speed
		public float vspeed; //vertical speed
		public float accel; //acceleration
		public float haccel; //acceleration
		public float vaccel; //acceleration
		public Weapon curWep;
		public Controls controls;
		public int health;

		public Player(Vector2 pos, RectangleF rect, string name, int slot) : base(pos, rect, name)
		{
			hspeed = 0f;
			vspeed = 0f;
			accel = 0f;
			prevface = 1;
			facing = 1;
			controls = new Controls(slot);
			shootPressed = false;
			curWep = new ProjectileWeapon(position, new RectangleF(position.X, position.Y, 30f, 10f), "basic");
		}//end Player() construction



		public void movementCheck(GameTime gameTime, Level level)
		{
			controls.movementUpdate();
			prevface = facing;
			if (controls.left) { haccel = 1.0f; facing = -1; }
			else if (controls.right) { haccel = 1.0f; facing = 1; }
			//else { hspeed = 0f; }
			if (controls.jump && grounded == 0) { jump(); }
			if (controls.shoot && !shootPressed)
			{
				curWep.use(facing, level);
				shootPressed = true;
			}
			else if (shootPressed && !controls.shoot) 
			{
				shootPressed = false;
			}
			hspeed = haccel * hmax * facing;
			vspeed = vaccel * vmax;
			handleMove(gameTime, level);
			vaccel = vaccel - 0.05f;
			haccel -= 0.05f;
			if (vaccel < 0.0f) { vaccel = 0.0f; }
			if (haccel < 0.0f) { haccel = 0.0f; }

		}

		public void handleMove(GameTime gameTime, Level level) 
		{ 
			position.X += hspeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
			position.Y += (vspeed + (160f * grounded)) * (float)gameTime.ElapsedGameTime.TotalSeconds;
			colbox.X = position.X;
			colbox.Y = position.Y;

			foreach (Thing t in level.thingList)
			{
				if (t.GetType().Equals(typeof(Wall)))
				{
					if (colCheck(t.colbox))
					{
						break;
					}
				}
				if (t.GetType().Equals(typeof(Projectile)))
				{
					if (bulletCheck(t.colbox))
					{
						break;
					}
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
			grounded = 1;

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
			else if (temp.Width > temp.Height)
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
					grounded = 0;
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

			if (facing == 1) 
			{ 
				curWep.position.X = position.X + colbox.Width;
				curWep.position.Y = position.Y;
			}
			if (facing == -1) 
			{ 
				curWep.position.X = position.X - curWep.colbox.Width;
				curWep.position.Y = position.Y;
			}



			return coll;
		}

		public bool bulletCheck(RectangleF rect)
		{
			bool coll = false;
			RectangleF temp = RectangleF.Intersect(this.colbox, rect);
			//grounded = false;

			if (temp.Height > temp.Width)
			{
				// left/right collision
				RectangleF temp2 = colbox;
				temp2.X += 1;
				temp2 = RectangleF.Intersect(temp2, rect);
				if (temp2.Width > temp.Width)
				{
					//left collision
					haccel += .20f;
					//colbox.X = rect.X - colbox.Width;
					coll = true;
				}
				else
				{
					//right collision
					//colbox.X = rect.X + rect.Width;
					haccel += .20f;
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
					//colbox.Y = rect.Y - colbox.Height;
					vaccel -= .20f;

					coll = true;
					//grounded = true;
				}
				else
				{
					//bottom collision
					//colbox.Y = rect.Y + rect.Height;
					vaccel += .20f;
					coll = true;
				}
			}

			position.X = colbox.X;
			position.Y = colbox.Y;

			if (facing == 1)
			{
				curWep.position.X = position.X + colbox.Width;
				curWep.position.Y = position.Y;
			}
			if (facing == -1)
			{
				curWep.position.X = position.X - curWep.colbox.Width;
				curWep.position.Y = position.Y;
			}



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
			//curWep.use(facing, );
		}
	}
}
