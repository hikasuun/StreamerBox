using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamBox
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            // pass form here
            // BaseForm baseForm = new
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 10;
            if (panel2.Width >= 800)
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}
