using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Assignment2_Numerical_tic_Tac_Toe
{
    public class GameState
    {
        private Board _board;
        private Stack<Action> _actions;
        private Stack<Turn> _turns;
        private List<Turn> _undoBuffer;

        public GameState(Board board)
        {
            _board = board;
            _actions = new Stack<Action>();
            _turns = new Stack<Turn>();
            _undoBuffer = new List<Turn>();
        }

        public void AddAction(Action action)
        {
            while(!_board.IsEmpty(action.X, action.Y))
            {
                Console.WriteLine("The tile is not empty. You cannot input value here. Try again.");
                action = new Action(Console.ReadLine());
                
            }
            _actions.Push(action);
            _board.SetTile(action.X, action.Y, new Tile() { Symbol = action.Value + "" });
            return;
        }

        public void Save()
        {
            _board.SaveToFile();
        }

        public void LoadBoard()
        {
            _board.LoadFromFile();
        }

        public void DrawBoard()
        {
            _board.Draw();

        }

        public Turn GetLastTurn(Player player)
        {
            return _turns.Peek();
        }


        public void RegisterTurn(Player player, Action action)
        {
            while (!_board.IsEmpty(action.X, action.Y))
            {
                Console.WriteLine("The tile is not empty. You cannot input value here. Try again");
                action = player.GetAction();       
            }
            _turns.Push(new Turn(player, action));
        }

        public void UndoTurn(Player player)
        {
            Turn lastTurn;
            if (!_turns.TryPeek(out lastTurn))
            {
                Console.WriteLine("You have not played yet to undo.");
                return;
            }

            if (lastTurn.Player.PlayerLabel != player.PlayerLabel)
            {
                Console.WriteLine("Unabel to undo turn as the player does not own the turn");
            }
            else
            {
                _turns.Pop();
                _undoBuffer.Add(lastTurn);
                _board.SetTile(lastTurn.Action.X, lastTurn.Action.Y, new Tile() { Symbol = "" });
            }
        }

        public void RedoTurn(Player player)
        {
            Turn lastTurn;
            if (_undoBuffer.Count < 1)
            {
                return;
            }
            lastTurn = _undoBuffer.First();
            _turns.Push(lastTurn);
            _board.SetTile(lastTurn.Action.X, lastTurn.Action.Y, new Tile() { Symbol = lastTurn.Action.Value + "" });
        }

        public void StartTurn()
        {
            _undoBuffer = new List<Turn>();
        }

        public Score GetScore()
        {
            return _board.CalculateScore();
        }


    }
}
