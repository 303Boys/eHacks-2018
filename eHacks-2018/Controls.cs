using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace eHacks_2018
{
	public class Controls
	{
        private GamePadState firstPlayer;
        private GamePadState firstPlayerInitial;
        private PlayerIndex currentPlayer;
        public Controls()
		{
        firstPlayer = GamePad.GetState(PlayerIndex.One);
		}

        public void movementUpdate(){
            firstPlayerInitial = GamePad.GetState(PlayerIndex.One);

            if (firstPlayer.IsButtonDown(Buttons.DPadLeft)){
                System.Diagnostics.Debug.WriteLine("Player 1 moves left.");
            }
            
            if (firstPlayer.IsButtonDown(Buttons.DPadRight)){
                System.Diagnostics.Debug.WriteLine("Player 1 moves right.");
            }            

            if (firstPlayer.IsButtonDown(Buttons.A)){
                System.Diagnostics.Debug.WriteLine("Player 1 presses A.");
            }
            
            if (firstPlayer.IsButtonDown(Buttons.X) && firstPlayerInitial.Buttons.X == ButtonState.Released){
                System.Diagnostics.Debug.WriteLine("Player 1 presses X.");
                System.Diagnostics.Debug.Write("    Left Thumbstick X Position is:  ");
                System.Diagnostics.Debug.WriteLine(firstPlayer.ThumbSticks.Left.X);
                System.Diagnostics.Debug.Write("    Left Thumbstick Y Position is:  ");
                System.Diagnostics.Debug.WriteLine(firstPlayer.ThumbSticks.Left.Y);
            }

            if (firstPlayer.IsButtonDown(Buttons.B)){
                System.Diagnostics.Debug.WriteLine("Player 1 presses B.");
            }
            
            if (firstPlayer.IsButtonDown(Buttons.Y)){
                System.Diagnostics.Debug.WriteLine("Player 1 presses Y.");
            }
            
            firstPlayer = firstPlayerInitial;
            }
	}
}
