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
        private BaseForm form;
        public string userName;
        public TimeZoneInfo time;
        public SplashScreen(BaseForm frm)
        {
            InitializeComponent();
            form = frm;
            // check for first time user
            if (true)
            {
                FirstTimeUserForm Splashform = new FirstTimeUserForm(this);
                Splashform.Show();
                
                form.setUserName(userName);
                form.setTimeZone(time);
                this.Close();
            }

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 10;
            // add worker routines here
            if (panel2.Width >= 800)
            {
                timer1.Stop();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
