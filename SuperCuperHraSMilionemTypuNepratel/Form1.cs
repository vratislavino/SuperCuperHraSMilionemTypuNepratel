namespace SuperCuperHraSMilionemTypuNepratel
{
    public partial class Form1 : Form
    {
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            bar1.OnBarEmpty += () => 
            {
                timer1.Stop();
                MessageBox.Show("You lost!");
            };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int enemies = canvas1.EnemiesCount;
            bar1.DecreaseValue(enemies);

            var enemy = CreateNewEnemy();
            canvas1.AddEnemy(enemy);
        }

        private Enemy CreateNewEnemy()
        {
            return new SmartSquare(
                rand.Next(0, canvas1.Width),
                rand.Next(0, canvas1.Height)
                );
        }
    }
}
