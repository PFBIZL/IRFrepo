using _6hetgyak.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6hetgyak.Entities
{
    public class PresentFactory : IToyFactory
    {
        public Color FirstColor { get; set; }
        public Color SecondColor { get; set; }

        public Toy CreateNew()
        {
            return new Present(FirstColor, SecondColor);
        }
    }
}
