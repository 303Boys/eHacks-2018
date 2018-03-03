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
		private float vmax = 80f;
		public int grounded; //0 on ground, 1 if else
		public bool shootPressed;
		public int facing; //1 facing right, -1 facing left
		public int direction;
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
			if (controls.left) 
			{
				if (haccel > -1.0f)
				{
					haccel -= 0.3f;
					if (haccel < -1.0f)
					{
						haccel = -1.0f;
					}
				}
				facing = -1;
				//haccel = haccel * facing;
			}
			else if (controls.right) 
			{ 
				if (haccel < 1.0f)
				{
					haccel += 0.3f;
					if (haccel > 1.0f)
					{
						haccel = 1.0f;
					}
				}
				facing = 1;
				//haccel = haccel * facing;
			}
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
			hspeed = haccel * hmax;
			vspeed = vaccel * vmax;
			handleMove(gameTime, level);
			handleMove(gameTime, level);
			vaccel = vaccel + 0.25f;
			//haccel -= 0.05f;
			if (vaccel > 4.0f) 
			{ 
				vaccel = 4.0f; 
			}
			if (haccel < -0.05f) //if traveling left
			{
				haccel += 0.05f;
			}
			if (haccel > 0.05f) //if traveling right
			{
				haccel -= 0.05f;
			}
			if (haccel >= -0.05f && haccel <= 0.05f) //if completely slowed down
			{
				haccel = 0.0f;
			}


		}

		public void handleMove(GameTime gameTime, Level level) 
		{ 
			position.X += (hspeed * (float)gameTime.ElapsedGameTime.TotalSeconds) / 2;
			position.Y += ((vspeed * grounded) * (float)gameTime.ElapsedGameTime.TotalSeconds) / 2;
			colbox.X = position.X;
			colbox.Y = position.Y;

			foreach (Thing t in level.thingList)
			{
				if (t.GetType().Equals(typeof(Wall)))
				{
					//grounded = 1;
					if (colCheck(t.colbox))
					{
						grounded = groundCheck(t.colbox);
						break;
					}
					//grounded = groundCheck(t.colbox);
				}
			}

			foreach (Thing t in level.thingList)
			{
				if (t.GetType().Equals(typeof(Projectile)))
				{
					if (bullCheck(t.colbox))
					{
						//var temp = t.GetType().GetCustomAttributes(false);
						//Projectile temp2 = (Projectile)temp[0];
						Projectile p = t as Projectile;
						if (p.speed < 0)
						{
							haccel -= 20f;
							direction = -1;
						}
						else 
						{ 
							haccel += 20f;
							direction = 1;
						}
						break;
					}
				}
			}
		}

		public int groundCheck(RectangleF rect)
		{
			//TODO
			RectangleF temp = colbox;
			temp.Height += 2;
			//temp = RectangleF.Intersect(colbox, rect);
			PointF tempPoint =  new PointF();
			PointF tempPoint2 = new PointF();
			tempPoint.X = temp.X;
			tempPoint.Y = temp.Y + temp.Height;
			tempPoint2.X = temp.X + temp.Width;
			tempPoint2.Y = temp.Y + temp.Height;
			if( (rect.Contains(tempPoint) && !temp.IsEmpty) ||
			    (rect.Contains(tempPoint2) && !temp.IsEmpty) )
			//if (temp.Width > temp.Height)
			{
				while (colbox.Y > rect.Y - 25)
				{
					colbox.Y--;
				}
				//colbox.Y = rect.Y - 25;
				position.X = colbox.X;
				position.Y = colbox.Y;
				return 0;
			}
			else
			{
				position.X = colbox.X;
				position.Y = colbox.Y;
				return 1;
			}
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
				vaccel = 0;
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
			else if (temp.Width == temp.Height && !temp.IsEmpty) 
			{
				colbox.Y -= 1;
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

		public bool altCheck(RectangleF rect)
		{
			grounded = 1;
			bool coll = false;
			RectangleF temp = RectangleF.Intersect(this.colbox, rect);
			//grounded = 1;

			if (temp.Height > temp.Width && !temp.IsEmpty)
			{
				// left/right collision
				RectangleF temp2 = colbox;
				temp2.X += 1;
				temp2 = RectangleF.Intersect(temp2, rect);
				if (temp2.Width > temp.Width)
				{
					//left collision
					colbox.X -= 1;
					coll = true;
				}
				else
				{
					//right collision
					colbox.X += 1;
					coll = true;
				}
			}
			else if (temp.Width > temp.Height)
			{
				// up/down collision
				vaccel = 0;
				RectangleF temp2 = colbox;
				temp2.Y += 1;
				temp2 = RectangleF.Intersect(temp2, rect);
				if (temp2.Height > temp.Height)
				{
					//top collision
					colbox.Y -= 1;
					coll = true;
					grounded = 0;
				}
				else
				{
					//bottom collision
					colbox.Y += 1;
					coll = true;
				}
			}
			else if (temp.Width == temp.Height && !temp.IsEmpty)
			{
				colbox.Y -= 1;
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

		public bool bullCheck(RectangleF rect)
		{

			RectangleF temp = RectangleF.Intersect(this.colbox, rect);
			if (temp.Width == 0 && temp.Height == 0)
			{
				return false;
			}
			else return true;
		}

		public void jump()
		{
			vaccel = -6.0f;
			grounded = 1;
		}


		public void shoot()
		{
			//TODO
			//curWep.use(facing, );
		}
	}
}
