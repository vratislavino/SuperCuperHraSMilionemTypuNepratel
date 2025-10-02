using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCuperHraSMilionemTypuNepratel
{
    public class SmartSquare : Enemy
    {
        Pen outline = new Pen(Color.Black, 3f);

        bool[,] regions = new bool[2, 2];
        int cellSize;

        public SmartSquare(int x, int y) : base(x, y)
        {
            width = 80;
            height = 80;
            lives = 4;
            cellSize = (int)(width / regions.GetLength(0));
        }

        public override void DoYourThing(int mx, int my)
        {
            int localX = mx - x;
            int localY = my - y;

            int indexX = localX / cellSize;
            int indexY = localY / cellSize;

            if(!regions[indexX, indexY])
            {
                regions[indexX, indexY] = true;
                TakeLife();
            }
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(outline, x, y, width, height);
            g.DrawLine(outline, x + width / 2, y, x + width / 2, y + height);
            g.DrawLine(outline, x, y + height / 2, x+width, y+height/2);

            for (int i = 0; i < regions.GetLength(0); i++)
                for(int j = 0; j < regions.GetLength(1); j++)
                    if (regions[i, j])
                        g.FillRectangle(Brushes.Red, 
                            x + i * cellSize, 
                            y + j * cellSize, 
                            cellSize, 
                            cellSize);
        }
    }
}
