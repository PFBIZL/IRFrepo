﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gyak1
{


    internal class SudokuField : Button
    {

        public SudokuField()
        {
            Height = 30;
            Width = Height;
            BackColor = Color.White;
        }

        private int _value;
        public int Value
        {
            get { return _value; }
            set
            {
                _value = Value;
                if (_value > 9)
                {
                    _value = 0;
                }
                else if (_value < 0)
                {
                    _value = 9;
                }
                if (_value == 0)
                {
                    Text = "";
                }
                else
                {
                    Text = value.ToString();
                }
            }


             private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                Value++;
            }
            else if (e.Button == MouseButtons.Right)
            {
                Value--;
            }

        }







    }


        
    }
        

         
    

    




}
