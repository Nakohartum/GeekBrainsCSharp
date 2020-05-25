using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace HomeWork1
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected SizeF Size;
        public BaseObject(Point Pos, Point Dir, Size Size)
        {
            this.Pos = Pos;
            this.Dir = Dir;
            this.Size = Size;
        }
       
        public virtual void Draw(BufferedGraphics buffer )
        {
            Image image = Image.FromFile("C:/Users/artem/OneDrive/Рабочий стол/GeekBrainsC#/HomeWork1/planet.png");
            
            
            buffer.Graphics.DrawImage(image, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public virtual void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
            if (Pos.X < 0)
            {
                Dir.X = -Dir.X;
            }
            if (Pos.X > Game.Width)
            {
                Dir.X = -Dir.X;
            }
            if (Pos.Y < 0)
            {
                Dir.Y = -Dir.Y;
            }
            if (Pos.Y > Game.Height)
            {
                Dir.Y = -Dir.Y;
            }
        }
    }
}
