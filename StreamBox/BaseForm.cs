using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        public  List<Streamer> streamerList = new List<Streamer>(); // holds default list of streamers from Hololive
        public  List<StreamEvents> streamsList = new List<StreamEvents>(); // holds list of streams from Hololive
        private SaveStateHelper sth = null; // helps to save/load relevant data during closing/opening of app
        private System.Timers.Timer fifteenMinTimer; // helps to keep track of what is closest stream
        private StreamEvents closestEvent; // ALERT: ONLY USED FOR DEBUGGING AND TESTING FUNCTIONALITY, REMOVE WHEN FINISHED

        // helpers for clicking links
        Point curMouse = Point.Empty;
        ListViewItem.ListViewSubItem mSelected;

        public BaseForm()
        {
            InitializeComponent();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            this.Hide();

            SplashScreen splashScreen = new SplashScreen(this);
            splashScreen.ShowDialog();

            monthCalendar.MinDate = streamsList[0].getStreamDate();
            monthCalendar.MaxDate = streamsList[streamsList.Count-1].getStreamDate();
            monthCalendar.MaxSelectionCount = 1;

            TimeStatus.Text = DateTime.Now.ToString("hh:mm tt") + "   ";
            TimeZoneStatus.Text = userTimeZone.DisplayName.ToString() + "   ";
            UsernameStatus.Text = "Hello, " + userName + "  ";

            fifteenMinTimer = new System.Timers.Timer(1000 * 60 * 15); // every 15 min check
            fifteenMinTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            fifteenMinTimer.Start();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            // check current time
            var currentTime = DateTime.Now;
            for (int i = 0; i < streamsList.Count; i++)
            {
                // find which stream falls within the 0 <= x <= 30 min zone
                TimeSpan duration = streamsList[i].getStreamDate().Subtract(currentTime);
                if ((duration.TotalMinutes <= 30 && duration.TotalMinutes >= 0) && streamsList[i].getStreamer().getVisible())
                {
                    // send toast notification
                    LaunchToastNotification(streamsList[i].getStreamer().getStreamerName(),
                        streamsList[i].getStreamURL());
                }
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserSettingsForm frm = new UserSettingsForm();
            frm.Show();
            frm.TopMost = true;
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
            frm.TopMost = true;
            // show streamer settings
            monthCalendar.MinDate = streamsList[0].getStreamDate();
            monthCalendar.MaxDate = streamsList[streamsList.Count - 1].getStreamDate();
            monthCalendar.MaxSelectionCount = 1;
            this.Refresh();
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
            DateTime selectedDateStart = monthCalendar.SelectionStart.Date;
            DateTime selectedDateEnd = selectedDateStart.AddHours(23).AddMinutes(59).AddSeconds(59);

            for (int i = 0; i < streamsList.Count-1; i++)
            {
                if ((streamsList[i].getStreamDate() >= selectedDateStart && streamsList[i].getStreamDate() <= selectedDateEnd) &&
                    streamsList[i].getStreamer().getVisible() == true)
                {
                    var lvi = new ListViewItem(new string[] {streamsList[i].getStreamDate().ToString("MM/dd/yyyy HH:mm"),
                        streamsList[i].getStreamer().getStreamerName(), streamsList[i].getStreamURL().ToString() });
                    lvi.UseItemStyleForSubItems = false; // allows for hypertext formatting

                    streamsListView.Items.Add(lvi);
                }
            }
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

        private void streamsListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = streamsListView.Columns[e.ColumnIndex].Width;
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
            // clean up toast notifications
            ToastNotificationManagerCompat.History.Clear();

        }

        private void LaunchToastNotification(string name, Uri url)
        {
            ToastNotificationManagerCompat.OnActivated += toastArgs =>
            {
                //obtain args from notification
                ToastArguments args = ToastArguments.Parse(toastArgs.Argument);
                this.BeginInvoke(new Action(() =>
                {
                    System.Diagnostics.Process.Start(url.ToString());
                }));
            };

            new ToastContentBuilder()
                .AddArgument("conversationId", 9813)
                .AddText("Upcoming Stream")
                .AddText($"There is a stream coming up for {name}")
                .AddButton(new ToastButton()
                    .SetContent("Stream Link")
                    .AddArgument("action", "openLink")
                .SetBackgroundActivation())
                .Show(toast =>
                {
                    toast.ExpirationTime = DateTime.Now.AddHours(1); // expires after 1 hours from notification
                });
        }

        private void sendToastNotificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentTime = DateTime.Now;
            int found = 0;
            for (int i = 0; i < streamsList.Count; i++)
            {
                // find which stream falls within the 0 <= x <= 30 min zone
                TimeSpan duration = streamsList[i].getStreamDate().Subtract(currentTime);
                if ((duration.TotalMinutes >= 0) && (streamsList[i].getStreamer().getVisible() == true) && found == 0)
                {
                    closestEvent = streamsList[i];
                    found = 1;
                }
            }
            this.Show();
            LaunchToastNotification(closestEvent.getStreamer().getStreamerName(), closestEvent.getStreamURL());
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
    }
}
