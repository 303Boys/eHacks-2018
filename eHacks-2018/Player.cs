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



		public void movementCheck(GameTime gameTime)
		{
			controls.movementUpdate();

			if (controls.left) { hspeed = -50f; }
			else if (controls.right) { hspeed = 50f; }
			else { hspeed = 0f; }
			if (controls.jump) { jump(); }
			handleMove(gameTime);
		}

		public void handleMove(GameTime gameTime) 
		{ 
			position.X += hspeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
			position.Y += vspeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
		}

		public void groundCheck()
		{
			//TODO
			grounded = true;
		}

		public void colCheck()
		{
			//TODO
		}

		public void jump()
		{
			//TODO
			vspeed = 20f;
		}


		public void shoot()
		{
			//TODO
		}
	}
}
