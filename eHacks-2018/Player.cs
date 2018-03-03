using System;
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

		public Player()
		{
			position = new Vector2(10, 10);

		}//end Player() construction

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
		}


		public void shoot()
		{
			//TODO
		}
	}
}
