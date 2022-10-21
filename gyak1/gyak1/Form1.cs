using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gyak1
{
    public partial class Form1 : Form
    {
        private List<Sudoku> _list = new List<Sudoku>();
        private Random rnd = new Random();
        private Sudoku currentQuiz = null;

        public Form1()
        {

            
            InitializeComponent();
            CreatePlayfield();
            LoadSudokus();
            currentQuiz = GetRandomQuiz();
            NewGame();

        }

        public void CreatePlayfield()
        {
            int lineWidth = 5;
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    SudokuField sf = new SudokuField();
                    sf.Left = col * sf.Width + (int)(Math.Floor((double)(col / 3))) * lineWidth;
                    sf.Top = row * sf.Height + (int)(Math.Floor((double)(row / 3))) * lineWidth;
                    panel1.Controls.Add(sf);

                }

            }

        }
        private void LoadSudokus()
        {
            _list.Clear();
            using (StreamReader sr = new StreamReader("sudoku.csv",Encoding.Default))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');
                    Sudoku s = new Sudoku();
                    s.Solution = line[0];
                    s.Quiz = line[1];
                    _list.Add(s);
                }
            }

        }

       private Sudoku GetRandomQuiz()
        {
            int rndom = rnd.Next(_list.Count);
            return _list[rndom];

        }
        private void NewGame()
        {
            currentQuiz = GetRandomQuiz();

        }

        
    }
}
