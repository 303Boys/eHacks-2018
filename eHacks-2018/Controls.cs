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
        public Controls()
		{
        firstPlayer = GamePad.GetState(PlayerIndex.One);
        movementUpdate();

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
            
            if (firstPlayer.IsButtonDown(Buttons.X)){
                System.Diagnostics.Debug.WriteLine("Player 1 presses X.");
            }

            if (firstPlayer.IsButtonDown(Buttons.B)){
                System.Diagnostics.Debug.WriteLine("Player 1 presses A.");
            }
            
            if (firstPlayer.IsButtonDown(Buttons.Y)){
                System.Diagnostics.Debug.WriteLine("Player 1 presses X.");
            }
            
            firstPlayer = firstPlayerInitial;
            }
	}
}
