namespace SuperCuperHraSMilionemTypuNepratel
{
    public partial class Form1 : Form
    {
        Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var enemy = CreateNewEnemy();
            canvas1.AddEnemy(enemy);
        }

        private Enemy CreateNewEnemy()
        {
            return new StupidCircle(
                rand.Next(0, canvas1.Width),
                rand.Next(0, canvas1.Height)
                );
        }
    }
}
