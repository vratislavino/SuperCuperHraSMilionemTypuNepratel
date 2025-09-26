using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperCuperHraSMilionemTypuNepratel
{
    public partial class Canvas : UserControl
    {
        public int EnemiesCount => enemies.Count;

        List<Enemy> enemies = new List<Enemy>();

        public Canvas()
        {
            InitializeComponent();
        }

        public void AddEnemy(Enemy newEnemy)
        {
            enemies.Add(newEnemy);
            newEnemy.OnDeath += OnEnemyDied;
            Invalidate();
        }

        private void OnEnemyDied(Enemy deadEnemy)
        {
            enemies.Remove(deadEnemy);
            Invalidate();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            for (int i = 0; i < enemies.Count; i++)
                enemies[i].Draw(e.Graphics);
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if(enemies.Count == 0)
                return;

            var enemy = enemies.FirstOrDefault(en => en.IsMouseOver(e.X, e.Y));
            if(enemy != null)
            {
                enemy.DoYourThing(e.X, e.Y);
                Invalidate();
            }
        }
    }
}
