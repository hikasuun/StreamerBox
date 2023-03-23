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
        public List<Streamer> streamerList = new List<Streamer>(); // holds default list of streamers from Hololive
        public List<StreamEvents> streamsList = new List<StreamEvents>(); // holds list of streams from Hololive

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

            //monthCalendar.MinDate = DateTime.Now;
            //monthCalendar.MaxDate = DateTime.Now.AddDays(2);
            monthCalendar.MaxSelectionCount = 1;

            TimeStatus.Text = DateTime.Now.ToString("hh:mm tt") + "   ";
            TimeZoneStatus.Text = userTimeZone.ToString() + "   ";
            UsernameStatus.Text = "Hello, " + userName + "  ";

            this.Show();
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
        public void addStreamerList(Streamer sObj)
        {
            this.streamerList.Add(sObj);
        }
        public void addEventList(StreamEvents sObj)
        {
            this.streamsList.Add(sObj);
        }

        private void TimeZoneStatus_Click(object sender, EventArgs e)
        {

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            string selectedDate = monthCalendar.SelectionRange.Start.ToShortDateString();

            for (int i = 0; i < streamsList.Count; i++)
            {
                if (selectedDate == streamsList[i].getStreamDate().ToShortDateString())
                {
                    /*string[] row = {streamsList[i].getStreamDate().ToLocalTime().ToString("HH mm"),
                        streamsList[i].getStreamer().getStreamerName(), streamsList[i].getStreamTitle(),
                        streamsList[i].getStreamURL().ToString() }; */

                    streamsListView.Items.Add(new ListViewItem(new string[] {streamsList[i].getStreamDate().ToLocalTime().ToString("HH mm"),
                        streamsList[i].getStreamer().getStreamerName(), streamsList[i].getStreamTitle(),
                        streamsList[i].getStreamURL().ToString() }));
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
