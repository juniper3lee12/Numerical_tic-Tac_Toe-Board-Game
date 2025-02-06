using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Numerical_tic_Tac_Toe
{
    public class Tile
    {
        public string Symbol { get; set; }

        public bool IsEmpty()
        {
            return String.IsNullOrEmpty(Symbol);
        }


        public string GetImage()
        {
            if (IsEmpty())
            {
                return "   |";
            }
            else
            {
                return " " + Symbol + " |";
            }
        }

    }
}
