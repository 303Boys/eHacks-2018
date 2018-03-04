using System;
using System.Drawing;
using Microsoft.Xna.Framework;
namespace eHacks_2018
{
	public class Projectile : Thing
	{
		public float speed;
		public float knockback;
		public int duration;
		public int damage;
		public int direction;

		public Projectile(Vector2 pos, RectangleF rect, string name, 
		                  int direction, float spd, int dur, int dmg, Level level) : base(pos, rect, name)
		{
			speed = spd * direction;
			duration = dur;
			damage = dmg;
			knockback = 1 / 2f;
			colbox = rect;
			isActive = true;
			level.thingList.Add(this);
		}

		public float Getspeed()
		{
			return speed;
		}
		public int Getduration()
		{
			return duration;
		}
		public int Getdamage()
		{
			return damage;
		}

		public void Setspeed(float X)
		{
			speed = X;
		}
		public void Setduration(int X)
		{
			duration = X;
		}
		public void Setdamage(int X)
		{
			damage = X;
		}
		public void move()
		{
			if (isActive)
			{
				position.X += speed;
				colbox.X = position.X;
				colbox.Y = position.Y;
				duration--;
			}
			if (duration <= 0)
			{
				isActive = false;
			}
		}
		public void setActive()
		{
			isActive = false;
		}

		public void Countdown(int duration)
		{
			if (duration >= 0) 
			{ 
				duration--; 
			}
			if (duration <= 0)
			{
				isActive = false;
			}
		}
	}
}
