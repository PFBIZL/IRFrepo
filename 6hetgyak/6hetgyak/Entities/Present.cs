using _6hetgyak.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6hetgyak.Entities
{
    public class Present: Toy
    {
        public SolidBrush FirstColor { get; set; }
        public SolidBrush SecondColor { get; set; }

        public Present(Color firstColor, Color secondColor)
        {
            AutoSize = false;
            Width = 50;
            Height = Width;
            FirstColor = new SolidBrush(firstColor);
            SecondColor = new SolidBrush(secondColor);
        }

        private void Present_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        protected override void DrawImage(Graphics g)
        {
            g.FillRectangle(FirstColor, new Rectangle(0, 0, Width, Height));
            g.FillRectangle(SecondColor, new Rectangle(Width / 3, 0, Width / 3, Height));
            g.FillRectangle(SecondColor, new Rectangle(0, Height / 3, Width, Height / 3));
        }

        public void MoveBall()
        {
            Left += 1;
        }
    }
}
