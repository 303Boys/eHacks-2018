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
            position = new Vector2(0, 0);
            view = currentView;
            zoomValue = 1;
            cameraRectangle = new RectangleF(position.X, position.Y, view.Width, view.Height);
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

            transformMatrix = Matrix.CreateScale(new Vector3(zoomValue, zoomValue, 0)) * 
                Matrix.CreateTranslation(new Vector3((-position.X) + 200 ,(-position.Y) + 200, 0));

            //position.X = (rightMostX(level) + leftMostX(level)) / 2;

            position.X = cameraRectangle.X;
            // System.Diagnostics.Debug.Write("Camera X Position: ");
            // System.Diagnostics.Debug.WriteLine(position.X);

            //position.Y = (rightMostY(level) + leftMostY(level)) / 2;

            position.Y = cameraRectangle.Y;
            // System.Diagnostics.Debug.Write("Camera Y Position: ");
            // System.Diagnostics.Debug.WriteLine(position.Y);

            System.Diagnostics.Debug.Write("Leftmost Player Position: ");
            System.Diagnostics.Debug.WriteLine(leftMostX(level)+ " , " + leftMostY(level));

            System.Diagnostics.Debug.Write("Rightmost Player Position: ");
            System.Diagnostics.Debug.WriteLine(rightMostX(level) + " , " + rightMostY(level));

            System.Diagnostics.Debug.WriteLine("Level Y Size:   " + level.getSize().Y);
            System.Diagnostics.Debug.WriteLine("Rectangle Width:   " + cameraRectangle.Width);
            System.Diagnostics.Debug.WriteLine("Rectangle Height:   " + cameraRectangle.Height);

            if ((cameraRectangle.Width * (3 * zoomValue)) < (level.getSize().X / 2))
            {
                zoomValue += 0.01f;
            }

            if ((cameraRectangle.Width * (3 * zoomValue)) > (level.getSize().X / 2))
            {
                zoomValue -= 0.01f;
            }


            cameraRectangle.X = (rightMostX(level) * zoomValue) / 2;
            cameraRectangle.Y = (rightMostY(level) * zoomValue);
            cameraRectangle.Width = (rightMostX(level) - leftMostX(level));
            cameraRectangle.Height = (rightMostY(level) - leftMostY(level));

            



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
            
            if (level.players.Count >= 1) {

            }
        }

    }
}
