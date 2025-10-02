using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCuperHraSMilionemTypuNepratel
{
    public class PizzaPie : Enemy
    {
        static Brush fillBrush = Brushes.Chocolate;

        List<int> angles = new List<int>() { 0, 90, 180, 270 };
        int currentIndex;
        public PizzaPie(int x, int y) : base(x, y)
        {
            width = 100;
            height = 100;
            lives = 4;
            currentIndex = new Random().Next(0, angles.Count);
        }

        public override void DoYourThing(int mx, int my)
        {
            int currAngle = angles[currentIndex];
            int dx = mx - (int)(x+width/2);
            int dy = my - (int)(y+height/2);

            if(dx <= 0)
            {
                if(dy <= 0)
                {
                    if (currAngle == 180)
                        TakeLifeSpecial();
                } else
                {
                    if(currAngle == 90)
                        TakeLifeSpecial();
                }
            } else
            {
                if (dy <= 0)
                {
                    if (currAngle == 270)
                        TakeLifeSpecial();
                }
                else
                {
                    if (currAngle == 0)
                        TakeLifeSpecial();
                }
            }
        }

        private void TakeLifeSpecial()
        {
            TakeLife();
            angles.RemoveAt(currentIndex);
            if(angles.Count > 0)
                currentIndex = new Random().Next(0, angles.Count);
        }

        public override bool IsMouseOver(int mx, int my)
        {
            return Distance(mx, my, (int)(x+width/2), (int)(y+height/2)) <= width / 2;
        }

        private double Distance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        public override void Draw(Graphics g)
        {
            g.FillPie(fillBrush, 
                x, 
                y, 
                width, 
                height, 
                angles[currentIndex], 90);
        }
    }
}
