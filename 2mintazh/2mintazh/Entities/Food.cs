using _2mintazh.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2mintazh.Entities
{
    internal class Food : Product
    {
        
        public char Description { get; set; }
        protected override void Display()
        {
            throw new NotImplementedException();
        }
    }
}
