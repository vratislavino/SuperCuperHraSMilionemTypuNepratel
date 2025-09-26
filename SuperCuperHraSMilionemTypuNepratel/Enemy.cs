using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperCuperHraSMilionemTypuNepratel
{
    public abstract class Enemy
    {
        public event Action<Enemy> OnDeath;

        protected int x;
        protected int y;
        protected float width;
        protected float height;
        protected int lives;

        public Enemy(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public abstract void Draw(Graphics g);

        public virtual bool IsMouseOver(int mx, int my)
        {
            return mx >= x 
                && mx <= x+width
                && my >= y
                && my <= y+height;
        }

        public abstract void DoYourThing(int mx, int my);

        protected void TakeLife()
        {
            lives--;
            if(lives <= 0)
            {
                OnDeath?.Invoke(this);
            }
        }

    }
}
