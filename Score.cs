using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_Numerical_tic_Tac_Toe
{

    public class Score
    {
        private int _evenScore;
        private int _oddScore;
        public int EvenScore
        {
            get { return _evenScore; }
        }
        public int OddScore { get { return _oddScore; } }

        public Score(int eventScore, int oddScore)
        {
            _evenScore = eventScore;
            _oddScore = oddScore;
        }
    }
}
