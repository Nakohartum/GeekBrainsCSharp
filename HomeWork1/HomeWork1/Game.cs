using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace HomeWork1
{
    static class Game
    {
        public static BaseObject[] objs;
        private static BufferedGraphicsContext Context;
        public static BufferedGraphics Buffer;
        //properties
        //Game area's width and height
        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
               
        }
        public static void Init(Form form)
        {
            //Graphic output
            Graphics g;
            //Gives an access to main graphic context buffer for current app
            Context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            //Creating objects and linking it with a form
            //Memorise form's size
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            
            //Linking buffer in a memory with graphical object for drawing in buffer
            Buffer = Context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += timerTick;

        }
        private static void timerTick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Draw()
        {
            //Checking graphic output
            
            

            Buffer.Graphics.Clear(Color.Black);
            foreach(BaseObject obj in objs)
            {
                obj.Draw(Buffer);
            }
            Buffer.Render();
        }
        public static void Update()
        {
            foreach(BaseObject obj in objs)
            {
                obj.Update();
            }
        }
        public static void Load()
        {
            objs = new BaseObject[30];
            for(int i = 0; i < objs.Length / 3; i++)
            {
                objs[i] = new BaseObject(new Point(600, i * 20), new Point(-i, -i), new Size(15, 15));
            }
            for(int i = objs.Length / 3; i < objs.Length; i++)
            {
                objs[i] = new Star(new Point(600, i * 20), new Point(-i, i), new Size(10, 10));
            }
            for (int i = 20; i < objs.Length; i++)
            {
                objs[i] = new Meteorit(new Point(600, i * 20), new Point(i, 0), new Size(5, 5));
            }
        }
    }
}
