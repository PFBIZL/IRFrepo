using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Abstravt;

namespace WindowsFormsApp1.Entities
{
    public class Drink : Product
    {
        public override void Display()
        {
            BackColor = Color.LightBlue;
        }
    }
}
