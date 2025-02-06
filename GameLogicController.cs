using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;
using System.Resources;

namespace Assignment2_Numerical_tic_Tac_Toe
{
    public class GameLogicController
    {
        private List<Player> _players;
        public GameState State { get; set; }


        public GameLogicController()
        {
            _players = new List<Player>();
        }

        public void Setup()
        {
            Console.WriteLine("Enter Help to see a list of available command and their function.");
            Console.WriteLine("\nPlease select \n1. human vs. human \n2. human vs. computer\n");

            var mode = int.Parse(Console.ReadLine());
            if (mode == 1)
            {
                _players.Add(new HumanPlayerOne());
                _players.Add(new HumanPlayerTwo());
            }
            else if (mode == 2)
            {
                _players.Add(new ComputerPlayer());
                _players.Add(new HumanPlayerTwo());
            }
            else
            {
                Console.WriteLine("You have entered an invalid mode");
            }
        }

    
        public void Play()
        {
            var gameEnd = false;
            while (!gameEnd)
            {
                
                var currentPlayer = _players.First();
                _players.RemoveAt(0);

                var endTurn = false;
                State.StartTurn();
                while (!endTurn)
                {
                    var action = currentPlayer.GetAction();
                    if (action.ActionCode == ActionCodes.Play)
                    {
                        
                        State.RegisterTurn(currentPlayer, action);
                        State.AddAction(action);
                        if (currentPlayer.PlayerLabel == "AI")
                        {
                            endTurn = true;
                        }
                        State.DrawBoard();
                    }
                    if (action.ActionCode == ActionCodes.Save)
                    {
                        State.Save();
                        State.DrawBoard();
                    }
                    if (action.ActionCode == ActionCodes.Load)
                    {
                        State.LoadBoard();
                        State.DrawBoard();
                    }
                    if (action.ActionCode == ActionCodes.Exit)
                    {
                        endTurn = true;
                        gameEnd = true;
                    }
                    if (action.ActionCode == ActionCodes.Undo)
                    {
                        State.UndoTurn(currentPlayer);
                        State.DrawBoard();
                    }
                    if(action.ActionCode == ActionCodes.Redo)
                    {
                        State.RedoTurn(currentPlayer);
                        State.DrawBoard();
                    }
                    if (action.ActionCode == ActionCodes.End)
                    {
                        endTurn = true;
                    }
                    if (action.ActionCode == ActionCodes.Help)
                    {
                        var play = new PlayHandler();
                        var save = new SaveHandler();
                        var load = new LoadHandler();
                        var end = new  EndHandler();
                        var exit = new ExitHandler();
                        var undo = new UndoHandler();
                        var redo = new RedoHandler();

                        play.SetNext(save).SetNext(load).SetNext(end).SetNext(exit).SetNext(undo).SetNext(redo);


                        Console.WriteLine("About: Play > Save > Load > End > Exit > Undo > Redo\n");                                             
                        Command.QuestionCode(play);
                        Console.WriteLine();

                    }
                    _players.Add(currentPlayer);
                }


                
            }
        }
    }
}

