using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2mintazh.Abstract
{
    public abstract class Product: Button
    {
        
        public char Title
        {
            get { }
            set { Title = Text; }
        }

        public int Colories
        {
            get { }
            set { Display(); }
        }
        protected abstract void Display()
        {

        }
    }
}
