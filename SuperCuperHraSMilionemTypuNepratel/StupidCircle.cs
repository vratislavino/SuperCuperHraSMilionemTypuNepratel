using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCuperHraSMilionemTypuNepratel
{
    public class StupidCircle : Enemy
    {
        private static Pen outlinePen = new Pen(Color.DarkRed, 3f);
        private static Brush fillBrush = Brushes.OrangeRed;
        public StupidCircle(int x, int y) : base(x, y)
        {
            width = 50;
            height = 50;
            lives = 1;
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(fillBrush, x, y, width, height);
            g.DrawEllipse(outlinePen, x, y, width, height);
        }
        public override void DoYourThing(int mx, int my)
        {
            TakeLife();
        }

    }
}
