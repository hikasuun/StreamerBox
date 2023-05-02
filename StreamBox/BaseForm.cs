// BaseForm.cs
// Base Form for StreamerBox Application
using Microsoft.Toolkit.Uwp.Notifications;
using StreamerBox;
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
using System.Threading;
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
        private System.Timers.Timer dayCheckTimer; // checks every day for new streams
        private StreamEvents closestEvent; // used to push a notification on button press

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

            //sets date range in calendar
            monthCalendar.MinDate = streamsList[0].getStreamDate();
            monthCalendar.MaxDate = streamsList[streamsList.Count-1].getStreamDate();
            monthCalendar.MaxSelectionCount = 1;

            TimeStatus.Text = DateTime.Now.ToString("HH:mm") + "   "; // sets time
            TimeZoneStatus.Text = userTimeZone.DisplayName.ToString() + "   "; // sets timezone
            UsernameStatus.Text = "Hello, " + userName + "  "; // sets username

            fifteenMinTimer = new System.Timers.Timer(1000 * 60 * 15); // every 15 min check
            fifteenMinTimer.AutoReset = true;
            fifteenMinTimer.Elapsed += new ElapsedEventHandler(fifteenMinCheck);
            fifteenMinTimer.Start();

            dayCheckTimer = new System.Timers.Timer(1000 * 60 * 60 * 24); // every 24 hours
            dayCheckTimer.AutoReset = true;
            dayCheckTimer.Elapsed += new ElapsedEventHandler(dayRefresh);
            dayCheckTimer.Start();
        }

        private void fifteenMinCheck(object source, ElapsedEventArgs e)
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

        private void streamCheck()
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

        private void dayRefresh(object sender, System.Timers.ElapsedEventArgs e)
        {
            RefreshForm refresher = new RefreshForm(this);
            refresher.TopMost = true;
            timerStop(); // stop timers to avoid issues with accessing disposedObjects
            refresher.ShowDialog();
            streamCheck(); // check if stream is close and send notification
            timerStart(); // restart timers
        }

        private void refreshStreamsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RefreshForm refresher = new RefreshForm(this);
            refresher.TopMost = true;
            timerStop(); // stop timers to avoid issues with accessing disposedObjects
            refresher.ShowDialog();
            streamCheck(); // check if stream is close and send notification
            timerStart(); // restart timers
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // show user name change form
            UserNameChangeForm frm = new UserNameChangeForm(this);
            frm.Show();
            frm.TopMost = true;
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addNewStreamerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamerSettingsForm frm = new StreamerSettingsForm(this);
            frm.Show();
            frm.TopMost = true;
            // show streamer visibility settings
            monthCalendar.MinDate = streamsList[0].getStreamDate();
            monthCalendar.MaxDate = streamsList[streamsList.Count - 1].getStreamDate();
            monthCalendar.MaxSelectionCount = 1;
            this.Refresh();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            streamsListView.Items.Clear();
            DateTime selectedDateStart = monthCalendar.SelectionStart.Date;
            DateTime selectedDateEnd = selectedDateStart.AddHours(23).AddMinutes(59).AddSeconds(59);

            // adds streams to list to view
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

        // allows for cursor to change to hand for user readability
        private void streamsListView_MouseMove(object sender, MouseEventArgs e)
        {
            var info = streamsListView.HitTest(e.Location);
            if (info.SubItem == mSelected) return;
            if (mSelected != null) mSelected.Font = streamsListView.Font;
            mSelected = null;
            streamsListView.Cursor = Cursors.Default;
            // if cursor is hovering over link OR VTuber name, change to hand cursor
            if ((info.SubItem != null && info.Item.SubItems[2] == info.SubItem) || (info.SubItem != null && info.Item.SubItems[1] == info.SubItem))
            {
                info.SubItem.Font = new Font(info.SubItem.Font, FontStyle.Underline);
                streamsListView.Cursor = Cursors.Hand;
                mSelected = info.SubItem;
            }
        }

        // allows clicking of "links"
        private void streamsListView_MouseUp(object sender, MouseEventArgs e)
        {
            var hit = streamsListView.HitTest(e.Location);
            if (hit.SubItem != null && hit.SubItem == hit.Item.SubItems[2])
            {
                var url = new Uri(hit.SubItem.Text);
                // prevents re-entry bug causing 2 streams being opened
                this.BeginInvoke(new Action(() =>
                {
                    System.Diagnostics.Process.Start(url.ToString());
                }));

            }
            if (hit.SubItem != null && hit.SubItem == hit.Item.SubItems[1])
            {
                Streamer streamerSelected = null;
                foreach(Streamer talent in streamerList)
                {
                    if (hit.SubItem.Text == talent.getStreamerName())
                    {
                        streamerSelected = talent;
                    }
                }
                StreamerInfo sif = new StreamerInfo(this, streamerSelected);
                sif.ShowDialog();
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

        // creates toast notification and sends
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

        // manually calls toast notification launch
        private void sendToastNotificationToolStripMenuItem_Click(object sender, EventArgs e) // checking time for streams
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
            if (closestEvent == null)
                MessageBox.Show("No streams selected"); // prevents issue of not having streams selected
            else
            {
                this.Show();
                LaunchToastNotification(closestEvent.getStreamer().getStreamerName(), closestEvent.getStreamURL()); // launch toast notification
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm frm = new AboutForm();
            frm.ShowDialog();
        }

        private void sendToTray(object sender, EventArgs e) // send to tray
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                StreamerBoxTray.Visible = true;
            }
        }

        private void StreamerBoxTray_MouseDoubleClick(object sender, MouseEventArgs e) // recover from tray
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            StreamerBoxTray.Visible = false;
        }


        // helper functions
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
            UsernameStatus.Text = "Hello, " + userName + "  ";
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
        private void timerStart()
        {
            fifteenMinTimer.Start();
            dayCheckTimer.Start();
        }

        private void timerStop()
        {
            fifteenMinTimer.Stop();
            dayCheckTimer.Stop();
        }
        
    }
}
