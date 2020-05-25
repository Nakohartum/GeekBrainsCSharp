using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork1
{
    class Meteorit: BaseObject
    {
        public Meteorit(Point pos, Point dir, Size size):base(pos, dir, size)
        {

        }
        public override void Draw(BufferedGraphics buffer)
        {
            Image image = Image.FromFile("C:/Users/artem/OneDrive/Рабочий стол/GeekBrainsC#/HomeWork1/star.png");


            buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;

            if (Pos.X > 800) Pos.X = 0;
        }

    }
}
