using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace eHacks_2018
{
    public class Camera
    {
        float zoomValue = 1;
        Vector2 position;
        float direction;
        Viewport view;
        public Matrix transformMatrix;

        public Camera(Viewport currentView) {
            position = new Vector2(0, 0);
            view = currentView;

        }

        public void Translate(Vector2 moveVector) {
            position += moveVector;
        }

        public void camUpdate(GameTime gameTime) {

            transformMatrix = Matrix.CreateScale(new Vector3(1, 1, 0)) * 
                Matrix.CreateTranslation(new Vector3(-position.X,-position.Y, 0));
            if (Keyboard.GetState().IsKeyDown(Keys.A)){
                position.X -= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D)){
                position.X += 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S)){
                position.Y += 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W)){
                position.Y -= 5;
            }
        }

    }
}
