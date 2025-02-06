using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Numerical_tic_Tac_Toe
{
    public enum ActionCodes
    {
        Play,
        Save,
        Load,
        End,
        Undo,
        Redo,
        Show,
        Help,
        Exit
    }
    public class Action
    {
        private int _x;
        private int _y;
        private int _value;

        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public int Value { get { return _value; } }

        public ActionCodes ActionCode { get; set; }

        public Action(string input)
        {
            var commands = input.Split(' ');

            var command = commands[0];
            var firstLetter = command[0].ToString().ToUpper();
            command = firstLetter + command.Substring(1, command.Length-1);
            ActionCode = Enum.Parse<ActionCodes>(command);

            if (command == "Play")
            {
                _x = int.Parse(commands[1]);
                _y = int.Parse(commands[2]);
                _value = int.Parse(commands[3]);
            }
        }
    }
}

