using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;



namespace Assignment2_Numerical_tic_Tac_Toe
{
    public abstract class Player
    {
        public string PlayerLabel { get; set; }

        public virtual bool IsValidInput(Action action)
        {
            return true;            
        }

        public virtual Action GetAction()
        {
            Console.WriteLine();
            Console.WriteLine(PlayerLabel + " Please enter your move in the following consequences:\n");
            Console.WriteLine("Action code + space + Vertical Position + Space + Horizontal Position + Space + Value ");
            Console.WriteLine("Action codes can be Play Save Load End Undo Redo Exit or Help");
            Console.WriteLine("Positions in this board are defined accordingly: [0][0] [0][1] [0][2]");
            Console.WriteLine("                                                 [1][0] [1][1] [1][2]");
            Console.WriteLine("                                                 [2][0] [2][1] [2][2]\n");
            Console.WriteLine("For example: Play 0 0 1,Play 2 2 4,Play 2 0 9 : ");
            Console.WriteLine("Type End when you want to switch your turn back to your opponent");
            var action = new Action(Console.ReadLine());
            while (action.ActionCode == ActionCodes.Play && !IsValidInput(action) && action.Value >0 && action.Value < 10)

            {
                Console.WriteLine(PlayerLabel + " Your input is invalid.");
                Console.WriteLine("Please input action code and reconsider whether it is odd or even in this turn.>>>");
                action = new Action(Console.ReadLine());
            }
            Console.Clear();
            return action;        
        }

    }
}
