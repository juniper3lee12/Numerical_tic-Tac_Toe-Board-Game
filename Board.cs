using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment2_Numerical_tic_Tac_Toe
{
    public class Board
    {
        private Dictionary<int, Dictionary<int, Tile>> _rows;
        private int _rowCount;
        private int _columnCount;
        public Board(int rows, int cols)
        {
            _rowCount = rows;
            _columnCount = cols;
            _rows = new Dictionary<int, Dictionary<int, Tile>>();
            Load();
        }
        public void Load()
        {
            for (int row = 0; row < _rowCount; row++)
            {
                _rows[row] = new Dictionary<int, Tile>();
                for (int col = 0; col < _columnCount; col++)
                {
                    _rows[row][col] = new Tile();
                }
            }
        }

        public Dictionary<int, Tile> GetRows(int row)
        {
            return _rows[row];
        }

        public void Draw()
        {
            var output = "";
            for (int rowIndex = 0; rowIndex < _rows.Values.Count; rowIndex++)
            {
                output += Divider() + "\n|";
                for (int colIndex = 0; colIndex < _rows[rowIndex].Values.Count; colIndex++)
                {
                    var tile = _rows[rowIndex][colIndex];
                    output += tile.GetImage();
                }
                output += "\n";
            }
            output += Divider() + "\n";
            System.Console.Write(output);
        }

        private string Divider()
        {
            return new string('-', _columnCount * 4);
        }

        public void SetTile(int row, int col, Tile tile)
        {
            _rows[row][col] = tile;
        }

        public bool IsEmpty(int row, int col)
        {
            return _rows[row][col].IsEmpty();
        }

     

        public void SaveToFile()
        {
            using(StreamWriter sw= new StreamWriter("saved.csv"))
            {
                foreach (var row in _rows.Values)
                {
                    var rowString = "";
                    foreach (var col in row.Values)
                    {
                        rowString += col.Symbol + " ";
                    }
                    sw.WriteLine(rowString);
                }
            }

        }


        public void LoadFromFile()
        {
            using(StreamReader reader = new StreamReader("saved.csv"))
            {
                string line;

                while( (line = reader.ReadLine()) != null)
                {
                    var x = 0;
                    var items = line.Split(" ");
                    for (int index = 0; index < items.Length; index++)
                    {
                        _rows[x][index] = new Tile()
                        {
                            Symbol = items[index]
                        };
                    }
                }

            }
        }

        public Score CalculateScore()
        {
            int eventScore = 0;
            int oddScore = 0;
            foreach (var row in _rows)
            {
                foreach (var col in row.Value.Values)
                {
                    int input;
                    if (!col.IsEmpty() && int.TryParse(col.Symbol, out input))
                    {
                        if (input % 2 == 0)
                        {
                            eventScore += input;
                        }
                        else
                        {
                            oddScore += input;
                        }
                    }
                }
            }
            var score = new Score(eventScore, oddScore);
            return score;
        }
    }

}
