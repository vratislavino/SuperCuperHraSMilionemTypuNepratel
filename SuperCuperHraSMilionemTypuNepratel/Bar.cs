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
    public partial class Bar : UserControl
    {
        public event Action OnBarEmpty;
        public int MaxValue { get; set; } = 100;

        private int currentValue;

        public Bar()
        {
            InitializeComponent();
        }
        private void Bar_Load(object sender, EventArgs e)
        {
            currentValue = MaxValue;
            UpdatePanelSize();
        }

        public void DecreaseValue(int amount)
        {
            currentValue -= amount;
            if (currentValue <= 0)
            {
                currentValue = 0;
                OnBarEmpty?.Invoke();
            }
            UpdatePanelSize();
        }
        private void Bar_SizeChanged(object sender, EventArgs e)
        {
            panel1.Height = this.Height;
            UpdatePanelSize();
        }

        private void UpdatePanelSize()
        {
            float fillPerc = (float)currentValue / MaxValue;
            panel1.Width = (int)(this.Width * fillPerc);
        }

    }
}
