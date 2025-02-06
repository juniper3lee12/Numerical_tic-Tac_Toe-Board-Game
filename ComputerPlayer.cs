using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Numerical_tic_Tac_Toe
{
    public class ComputerPlayer : Player
    {

        private Random r;
        private string[] _randomActions = { "Play 0 0 1", "Play 0 1 3", "Play 1 2 5", "Play 1 0 1", "Play 1 1 7", "Play 1 1 9", "Play 1 2 5", "Play 2 0 2", "Play 2 1 9", "Play 2 2 3" };
        private List<string> _playedActions;
        public ComputerPlayer()
        {
            PlayerLabel = "AI";

            r = new Random();
        }

        public override bool IsValidInput(Action action)
        {
            return action.Value % 2 != 0;
        }

        public override Action GetAction()
        {
            var randomIndex = r.NextInt64(0, _randomActions.Length);
            return new Action(_randomActions[randomIndex]);
        }
    }
}



