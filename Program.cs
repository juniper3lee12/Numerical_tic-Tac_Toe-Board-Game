using System;
using static System.Console;
using System.Collections.Generic;



namespace Assignment2_Numerical_tic_Tac_Toe
{
    class Program
    {
        public static void Main()
        {
            DisplayIntroduction();
            Board board = new Board(3, 3);

            GameState _gameState = new GameState(board);
            GameLogicController _controller = new GameLogicController();
            _controller.State = _gameState;
            _controller.Setup();
            _controller.Play();
        }

        public static void DisplayIntroduction()
        {
            WriteLine("**********************************");
            WriteLine("Welcome to Numerical Tic-Tac-Toe");
            WriteLine("**********************************\n");

            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("First player plays with odds. Second Player plays with evens.");
            WriteLine("Odds always go first.");
            WriteLine("On your turn, place one of your numbers on the tic-tac-toe board.");
            WriteLine("Each number can only be used once.");
            WriteLine("The winner is the first player to complete a line(horizontal,vertical, or diagonal) with a sum of 15.");
            WriteLine("The line may contain both even and odd numbers.");
            ResetColor();
            WriteLine();
            Write("Odds(1,3,5,7,9) VS Evens(2,4,6,8)\n");
            WriteLine();
            ResetColor();
            
        }
    }
}

