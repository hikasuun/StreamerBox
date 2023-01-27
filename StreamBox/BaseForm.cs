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
    public partial class BaseForm : Form
    {
        private string userName; // holds user's name
        private TimeZoneInfo userTimeZone; // holds user's time zone

        public BaseForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            SplashScreen splashScreen = new SplashScreen(this);
            splashScreen.ShowDialog();
            this.Show();
            TimeStatus.Text = DateTime.Now.ToString("hh:mm tt") + "   ";
            TimeZoneStatus.Text = userTimeZone.ToString() + "   ";
            UsernameStatus.Text = "Hello, " + userName + "  ";
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSettingsForm frm = new UserSettingsForm();
            frm.Show();
            frm.TopMost= true;
            // show user settings
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            // exit routine
        }

        private void addNewStreamerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamerSettingsForm frm = new StreamerSettingsForm();
            frm.Show();
            frm.TopMost= true;
            // show streamer settings
        }

        private void currentTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // getters and setters
        public string getUserName()
        {
            return this.userName;
        }
        public TimeZoneInfo getTimeZone()
        {
            return this.userTimeZone;
        }
        public void setUserName(string name)
        {
            this.userName = name;
        }
        public void setTimeZone(TimeZoneInfo timeZone)
        {
            this.userTimeZone = timeZone;
        }

        private void TimeZoneStatus_Click(object sender, EventArgs e)
        {

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
