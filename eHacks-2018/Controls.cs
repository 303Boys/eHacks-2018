using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace eHacks_2018
{
    public class Controls
    {
        private GamePadState playerCurrentState;
        private GamePadState playerInitialState;
        private PlayerIndex currentPlayer;
        public bool left;
        public bool right;
        public bool jump;
        public bool shoot;
		public bool switchWep;

        public Controls(int playerNum)
        {
            switch (playerNum)
            {
                case 1: currentPlayer = PlayerIndex.One; break;
                case 2: currentPlayer = PlayerIndex.Two; break;
                case 3: currentPlayer = PlayerIndex.Three; break;
                case 4: currentPlayer = PlayerIndex.Four; break;
            }
            playerCurrentState = GamePad.GetState(currentPlayer);

        }

        public void movementUpdate()
        {
            playerInitialState = GamePad.GetState(currentPlayer);
            if (playerCurrentState.IsButtonDown(Buttons.DPadLeft))
            {
                left = true;
                System.Diagnostics.Debug.WriteLine("Player moves left.");
                System.Diagnostics.Debug.Write("    Player Number: ");
                System.Diagnostics.Debug.WriteLine(currentPlayer);
            }
            else { left = false; }

            if (playerCurrentState.IsButtonDown(Buttons.DPadRight))
            {
                right = true;
                System.Diagnostics.Debug.WriteLine("Player moves right.");
                System.Diagnostics.Debug.Write("    Player Number: ");
                System.Diagnostics.Debug.WriteLine(currentPlayer);
            }
            else { right = false; }

            if (playerCurrentState.IsButtonDown(Buttons.A))
            {
                jump = true;
                System.Diagnostics.Debug.WriteLine("Player presses A.");
                System.Diagnostics.Debug.Write("    Player Number: ");
                System.Diagnostics.Debug.WriteLine(currentPlayer);
            }
            else { jump = false; }

            if (playerCurrentState.IsButtonDown(Buttons.X))
            {
                shoot = true;
                System.Diagnostics.Debug.WriteLine("Player presses X.");
                System.Diagnostics.Debug.Write("    Player Number: ");
                System.Diagnostics.Debug.WriteLine(currentPlayer);
            }
            else { shoot = false; }

            if (playerCurrentState.IsButtonDown(Buttons.B))
            {
                System.Diagnostics.Debug.WriteLine("Player presses B.");
                System.Diagnostics.Debug.Write("    Player Number: ");
                System.Diagnostics.Debug.WriteLine(currentPlayer);
            }

			if (playerCurrentState.IsButtonDown(Buttons.Y))
			{
				switchWep = true;
				System.Diagnostics.Debug.WriteLine("Player presses Y.");
				System.Diagnostics.Debug.Write("    Player Number: ");
				System.Diagnostics.Debug.WriteLine(currentPlayer);
			}
			else { switchWep = false; }

            playerCurrentState = playerInitialState;
        }

        public void vibrate()
        {
            for(int i = 0; i < 10; i++)
            {
                GamePad.SetVibration(currentPlayer, 10f, 10f);
            }
        }
    }
}

