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
		public bool left;
		public bool right;
		public bool jump;
		public bool shoot;

        public Controls()
		{
        firstPlayer = GamePad.GetState(PlayerIndex.One);
        //movementUpdate();

		}

        public void movementUpdate()
		{
            firstPlayerInitial = GamePad.GetState(PlayerIndex.One);
			if (firstPlayer.IsButtonDown(Buttons.DPadLeft))
			{
				left = true;
				System.Diagnostics.Debug.WriteLine("Player 1 moves left.");
			}
			else { left = false; }

			if (firstPlayer.IsButtonDown(Buttons.DPadRight))
			{
				right = true;
				System.Diagnostics.Debug.WriteLine("Player 1 moves right.");
			}
			else { right = false;}

			if (firstPlayer.IsButtonDown(Buttons.A))
			{
				jump = true;
				System.Diagnostics.Debug.WriteLine("Player 1 presses A.");
			}
			else { jump = false; }

			if (firstPlayer.IsButtonDown(Buttons.X))
			{
				shoot = true;
				System.Diagnostics.Debug.WriteLine("Player 1 presses X.");
			}
			else { shoot = false; }

            if (firstPlayer.IsButtonDown(Buttons.B))
			{
                System.Diagnostics.Debug.WriteLine("Player 1 presses B.");
            }
            
            if (firstPlayer.IsButtonDown(Buttons.Y))
			{
                System.Diagnostics.Debug.WriteLine("Player 1 presses Y.");
            }
            
            firstPlayer = firstPlayerInitial;
            }
	}
}
