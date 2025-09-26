using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCuperHraSMilionemTypuNepratel
{
    public class StupidCircle : Enemy
    {
        public StupidCircle(int x, int y) : base(x, y)
        {
            width = 50;
            height = 50;
            lives = 1;
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Red, x, y, width, height);
        }
        public override void DoYourThing(int mx, int my)
        {
            TakeLife();
        }

    }
}
