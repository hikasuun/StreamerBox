using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Serialization;
using static ScrapySharp.Core.Token;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StreamBox
{
    public partial class BaseForm : Form
    {
        private string userName; // holds user's name
        private TimeZoneInfo userTimeZone; // holds user's time zone
        public List<Streamer> streamerList = new List<Streamer>(); // holds default list of streamers from Hololive
        public List<StreamEvents> streamsList = new List<StreamEvents>(); // holds list of streams from Hololive
        private SaveStateHelper sth = null;

        // helpers for clicking links
        Point curMouse = Point.Empty;
        ListViewItem.ListViewSubItem mSelected;

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

            monthCalendar.MinDate = DateTime.Now;
            monthCalendar.MaxDate = DateTime.Now.AddDays(2);
            monthCalendar.MaxSelectionCount = 1;

            TimeStatus.Text = DateTime.Now.ToString("hh:mm tt") + "   ";
            TimeZoneStatus.Text = userTimeZone.DisplayName.ToString() + "   ";
            UsernameStatus.Text = "Hello, " + userName + "  ";

            streamsList = streamsList.OrderBy(x => x.getStreamDate().Date).ThenBy(x => x.getStreamDate().ToLocalTime()).ToList();
           

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
            StreamerSettingsForm frm = new StreamerSettingsForm(this);
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
            RefreshForm temp = new RefreshForm();
            temp.Show();
            // launch screen scraper
            var executable = new ProcessStartInfo();
            executable.UseShellExecute = false;
            executable.WindowStyle = ProcessWindowStyle.Hidden;
            executable.CreateNoWindow = true;
            executable.WorkingDirectory = Path.GetDirectoryName(@"..\..\Python\ScheduleScrapper.exe");
            executable.FileName = @"..\..\Python\ScheduleScrapper.exe";

            try
            {
                using (Process proc = Process.Start(executable))
                {
                    proc.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            this.Refresh();
            temp.Close();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            streamsListView.Items.Clear();
            string selectedDate = monthCalendar.SelectionRange.Start.ToShortDateString();

            for (int i = 0; i < streamsList.Count; i++)
            {
                if (selectedDate == streamsList[i].getStreamDate().ToShortDateString() &&
                    streamsList[i].getStreamer().getVisible() == true)
                {
                    var lvi = new ListViewItem(new string[] {streamsList[i].getStreamDate().ToLocalTime().ToString("MM/dd/yyyy HH:mm"),
                        streamsList[i].getStreamer().getStreamerName(), streamsList[i].getStreamURL().ToString() });
                    lvi.UseItemStyleForSubItems = false; // allows for hypertext formatting

                    streamsListView.Items.Add(lvi);
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void streamsListView_MouseMove(object sender, MouseEventArgs e)
        {
            var info = streamsListView.HitTest(e.Location);
            if (info.SubItem == mSelected) return;
            if (mSelected != null) mSelected.Font = streamsListView.Font;
            mSelected = null;
            streamsListView.Cursor = Cursors.Default;
            if (info.SubItem != null && info.Item.SubItems[2] == info.SubItem)
            {
                info.SubItem.Font = new Font(info.SubItem.Font, FontStyle.Underline);
                streamsListView.Cursor = Cursors.Hand;
                mSelected = info.SubItem;
            }
        }

        private void streamsListView_MouseUp(object sender, MouseEventArgs e)
        {
            var hit = streamsListView.HitTest(e.Location);
            if (hit.SubItem != null && hit.SubItem == hit.Item.SubItems[2])
            {
                var url = new Uri(hit.SubItem.Text);
                // prevents re-entry bug causing 2 streams being opened
                this.BeginInvoke(new Action(() => {
                    System.Diagnostics.Process.Start(url.ToString());
                }));
                
            }
        }

        private void streamsListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void streamsListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void streamsListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex != 1) e.DrawDefault = true;
            else
            {
                var HI = streamsListView.HitTest(curMouse);
                if (HI.Item == null) { e.DrawDefault = true; return; }
                bool showLink = e.SubItem.Text.Substring(0, 4) == "streamsLink"
                             && e.Item.Index == HI.Item.Index;

                e.DrawBackground();
                using (Font font = new Font(streamsListView.Font, showLink ?
                                            FontStyle.Underline : FontStyle.Regular))
                {
                    e.Graphics.DrawString(e.SubItem.Text, font, showLink ?
                      SystemBrushes.HotTrack : SystemBrushes.ControlText, e.Bounds);
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void streamsListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = streamsListView.Columns[e.ColumnIndex].Width;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sth = new SaveStateHelper(this);
            sth.writeUserState(@"..\..\saveState.xml"); // save user settings
            // clean up data.txt made from Python script
            if (File.Exists(@"..\..\Python\data.txt")) 
            {
                File.Delete(@"..\..\Python\data.txt");
            }
        }
    }
}
