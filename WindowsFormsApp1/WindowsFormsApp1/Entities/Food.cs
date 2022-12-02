using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Abstravt;

namespace WindowsFormsApp1.Entities
{
    public class Food : Product
    {
        public string Description { get; set; }

        private void Food_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("{0}\n{1}", Title, Description));
        }

        public override void Display()
        {
            if (Calories < 750)
            {
                BackColor = Color.LightGreen;
            }
            else if (Calories < 1000)
            {
                BackColor= Color.DarkGreen;

            }
            else
            {
                BackColor = Color.Salmon;
            }
            
        }
    }
}
