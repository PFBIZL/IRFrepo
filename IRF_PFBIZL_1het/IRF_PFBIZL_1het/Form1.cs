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

namespace IRF_PFBIZL_1het
{

    public partial class Form1 : Form

    {

        public class Sodoku
        {
            public string Quiz { get; set; }
            public string Solution { get; set; }

        }


        public class SodokuField : Button
        {
            private int _value;
            public int Value
            {
                get { return _value; }
                set
                {
                    _value = value;
                    if (_value < 0)
                        _value = 9;
                    else if (_value > 9)
                        _value = 0;

                    if (_value == 0)
                        Text = "";
                    else
                        Text = _value.ToString();
                }
            }

            public SodokuField()
            {
                Height = 30;
                Width = Height;
                BackColor = Color.White;
                Value = 0;
                MouseDown += SodokuField_MouseDown;
            }

            private bool _active;
            public bool Active
            {
                get { return _active; }
                set
                {
                    _active = value;
                    if (_active)
                        Font = new Font(FontFamily.GenericSansSerif, 12);
                    else
                        Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
                }
            }

            private void SodokuField_MouseDown(object sender, MouseEventArgs e)
            {
                if (!Active) return;

                if (e.Button == MouseButtons.Left)
                    Value++;
                if (e.Button == MouseButtons.Right)
                    Value--;

            }
            int lineWidth = 5;


        }


        private Random _rng = new Random();
        private Sodoku _currentQuiz = null;
        private List<Sodoku> _sudokus = new List<Sodoku>();

        public Form1()
        {
            InitializeComponent();
            CreatePlayField();
            LoadSudokus();
            NewGame();
            
        }


         private void CreatePlayField()
         {
            int lineWidth = 5;
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        SodokuField sf = new SodokuField();
                        sf.Left = col * sf.Width + (int)(Math.Floor((double)(col / 3))) * lineWidth;
                        sf.Top = row * sf.Height + (int)(Math.Floor((double)(row / 3))) * lineWidth;
                        panel1.Controls.Add(sf);
                    }
                }


         }


       
        private void LoadSudokus()
            {
                _sudokus.Clear();
                using (StreamReader sr = new StreamReader("sudoku.csv", Encoding.Default))
                {
                    sr.ReadLine(); // Remove headers
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');

                        Sodoku s = new Sodoku();
                        s.Quiz = line[0];
                        s.Solution = line[1];
                        _sudokus.Add(s);
                    }
                }
            }

            private Sodoku GetRandomQuiz()
            {
                int randomNumber = _rng.Next(_sudokus.Count);
                return _sudokus[randomNumber];
            }

            private void NewGame()
            {
                _currentQuiz = GetRandomQuiz();
                int counter = 0;
                foreach (var sf in panel1.Controls.OfType<SodokuField>())
                {
                    sf.Value = int.Parse(_currentQuiz.Quiz[counter].ToString());
                    sf.Active = sf.Value == 0;
                    counter++;
                }

            }

        

    }

}
