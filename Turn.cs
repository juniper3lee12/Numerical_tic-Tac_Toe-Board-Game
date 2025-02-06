using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Numerical_tic_Tac_Toe
{
    public class Turn
    {
        public Player Player { get; set; }
        public Action Action { get; set; }
        public Turn(Player player, Action action)
        {
            Player = player;
            Action = action;
        }
    }
}
