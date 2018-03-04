using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace eHacks_2018
{
	public class Thing
	{
        public Vector2 position; //Thing's position
		public RectangleF colbox; //collision box for Thing
		public Texture2D sprite;
        public Texture2D sprite2;
		public string spriteName; //name of Thing's sprite
        public string sprite2Name;
		public bool isActive = true;

		public Thing(Vector2 pos, RectangleF rect, string name)
		{
			position = pos;
			colbox = rect;
			spriteName = name;
			isActive = true;
		}//end Thing constructor

        public Thing(Vector2 pos, RectangleF rect, Texture2D sprite)
        {
            position = pos;
            colbox = rect;
            this.sprite = sprite;
            spriteName = sprite.Name;
        }

        public Thing(Vector2 pos, RectangleF rect, Texture2D sprite, Texture2D sprite2)
        {
            position = pos;
            colbox = rect;
            this.sprite = sprite;
            this.sprite2 = sprite2;
            spriteName = sprite.Name;
            sprite2Name = sprite2.Name;
        }

        public Vector2 getPosition()
        {
            return this.position;
        }
	}

	public class Wall : Thing
	{
		public Wall(Vector2 pos, RectangleF rect, Texture2D sprite) : base(pos, rect, sprite)
		{
			position = pos;
			colbox = rect;
			this.sprite = sprite;
			spriteName = sprite.Name;
		}
	}

    public class Door : Thing
    {
        public Door(Vector2 pos, RectangleF rect, Texture2D doorClosed, Texture2D doorOpen) : base(pos, rect, doorClosed, doorOpen)
        {
            position = pos;
            colbox = rect;
            this.sprite = doorClosed;
            this.sprite2 = doorOpen;
            spriteName = doorClosed.Name;
            sprite2Name = doorOpen.Name;
        }
    }
}
