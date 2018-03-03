using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace eHacks_2018
{
    public class Camera
    {
        float zoomValue;
        Vector2 position;
        float direction;
        Viewport view;
        public Matrix transformMatrix;
        public RectangleF cameraRectangle;

        public Camera(Viewport currentView) {
            position = Vector2.Zero;
            view = currentView;
            zoomValue = 1;
            cameraRectangle = new RectangleF(position.X, position.Y, 24, 24);
        }

        public void Translate(Vector2 moveVector) {
            position += moveVector;
        }

        private float leftMostX(Level sentLevel) {
            float lowestAmount = 9999f;
            for (int i = 0; i < sentLevel.players.Count; i++) {
                if (sentLevel.players[i].position.X < lowestAmount) {
                    lowestAmount = sentLevel.players[i].position.X;
                }
            }
            return lowestAmount;
        }
        private float rightMostX(Level sentLevel)
        {
            float highestAmount = -9999f;
            for (int i = 0; i < sentLevel.players.Count; i++)
            {
                if (sentLevel.players[i].position.X > highestAmount)
                {
                    highestAmount = sentLevel.players[i].position.X;
                }
            }
            return highestAmount;
        }

        private float leftMostY(Level sentLevel)
        {
            float lowestAmount = 9999f;
            for (int i = 0; i < sentLevel.players.Count; i++)
            {
                if (sentLevel.players[i].position.Y < lowestAmount)
                {
                    lowestAmount = sentLevel.players[i].position.Y;
                }
            }
            return lowestAmount;
        }
        private float rightMostY(Level sentLevel)
        {
            float highestAmount = -9999f;
            for (int i = 0; i < sentLevel.players.Count; i++)
            {
                if ((sentLevel.players[i].position.Y + sentLevel.players[i].sprite.Height) > highestAmount)
                {
                    highestAmount = (sentLevel.players[i].position.Y + sentLevel.players[i].sprite.Height);
                }
            }
            return highestAmount;
        }
        /*
        private float zoomUpdate(Level level) {

            for (int i = 0; i < level.players.Count; i++) {

            }
        }
        */

        public void camUpdate(GameTime gameTime, Level level) {

            //position = new Vector2(level.players[0].position.X + (level.players[0].sprite.Width / 2) - level.getSize().X / 2,
            //    level.players[0].position.Y + (level.players[0].sprite.Height / 2) - level.getSize().Y / 2);
            transformMatrix = Matrix.CreateScale(new Vector3(zoomValue, zoomValue, 0)) *
            //    Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0));
              Matrix.CreateTranslation(new Vector3(-cameraRectangle.X / 2, -cameraRectangle.Y / 2, 0));

            //position.X = (rightMostX(level) - (rightMostX(level)) / 2) * zoomValue;
            position.X = (rightMostX(level) + leftMostX(level)) / 2;
            //position.X = ((level.getSize().X) / 2) * zoomValue;
             System.Diagnostics.Debug.Write("Camera X Position: ");
             System.Diagnostics.Debug.WriteLine(position.X);
            System.Diagnostics.Debug.WriteLine("Center between Rightmost + Leftmost = ");

            position.Y = (rightMostY(level) + leftMostY(level)) / 2;

            //position.Y = (rightMostY(level)) * zoomValue;

           

            //position.Y = ((level.getSize().Y) / 2) * zoomValue;
             System.Diagnostics.Debug.Write("Camera Y Position: ");
             System.Diagnostics.Debug.WriteLine(position.Y);

            System.Diagnostics.Debug.Write("Leftmost Player Position: ");
            System.Diagnostics.Debug.WriteLine(leftMostX(level)+ " , " + leftMostY(level));

            System.Diagnostics.Debug.Write("Rightmost Player Position: ");
            System.Diagnostics.Debug.WriteLine(rightMostX(level) + " , " + rightMostY(level));



            cameraRectangle.X = (rightMostX(level) * zoomValue) / 2;
            cameraRectangle.Y = (rightMostY(level) * zoomValue);
            //cameraRectangle.Width = (rightMostX(level) - leftMostX(level)) * zoomValue;
            //cameraRectangle.Height = (rightMostY(level) - leftMostY(level)) * zoomValue;

            if (rightMostY(level) * zoomValue > level.getSize().Y) {
                zoomValue -= 0.005f;
            }

            if (rightMostY(level) * zoomValue < level.getSize().Y && zoomValue < 1) {
                zoomValue += 0.005f;
            }



            /*if (Keyboard.GetState().IsKeyDown(Keys.A)){
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
            */
            if (Keyboard.GetState().IsKeyDown(Keys.R))
            {
                zoomValue += 0.1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                zoomValue -= 0.1f;
            }
            
        }

    }
}
