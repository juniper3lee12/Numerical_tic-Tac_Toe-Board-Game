using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Numerical_tic_Tac_Toe
{
    public class HumanPlayerTwo : Player
    {
        public HumanPlayerTwo()
        {
            PlayerLabel = "Player 2";
        }
        public override bool IsValidInput(Action action)
        {
            return action.Value % 2 == 0;
        }

    }
}
