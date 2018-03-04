using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHacks_2018
{
    class GUIElement
    {
        private Texture2D guiTexture;
        private Rectangle guiRectangle;
        private string elementName;

        public string ElementName
        {
            get { return elementName; }
        }

        public delegate void ElementClicked(string element);
        public event ElementClicked clickEvent;

        public GUIElement(string name)
        {
            elementName = name;

        }
        public virtual void LoadContent(ContentManager content)
        {
            guiTexture = content.Load<Texture2D>(elementName);
        }

        public virtual void Update()
        {
            if (guiRectangle.Contains(new Point(Mouse.GetState().X, Mouse.GetState().Y)) && Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                //This element was clicked
                clickEvent(elementName);

            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(guiTexture, guiRectangle, Color.White);
        }

        public void CenterElement( Size windowSize)
        {
            guiRectangle = new Rectangle
                (
                    (windowSize.width / 2) - (this.guiTexture.Width / 2),
                    (windowSize.height / 2) - (this.guiTexture.Height / 2),
                    guiTexture.Width,
                    guiTexture.Height
                );
        }

        public void MoveElement(int x, int y)
        {
            guiRectangle = new Rectangle
                (
                    guiRectangle.X + x,
                    guiRectangle.Y + y,
                    guiRectangle.Width,
                    guiRectangle.Height
                );
        }
    }
}
