using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace StreamBox
{
    public partial class SplashScreen : Form
    {
        private BaseForm form;
        public string userName;
        public TimeZoneInfo time;
        private Boolean tickDone = false;
        private Boolean loadDone = false;
        public SplashScreen(BaseForm frm)
        {
            InitializeComponent();
            form = frm;
            // check for first time user

            if (true)
            {
                FirstTimeUserForm Splashform = new FirstTimeUserForm(this);
                Splashform.ShowDialog();
                
                form.setUserName(userName);
                form.setTimeZone(time);
                string[] lines = File.ReadAllLines(@"..\..\InfoStreamer.txt", Encoding.Unicode);
                for (int i = 3;i < lines.Length; i += 4) // read a set ( 4 lines ) at a time for each streamer
                {
                    // line 0 = Name
                    // line 1 = Alias
                    // line 2 = Twitter URL
                    // line 3 = YouTube URL
                    form.addStreamerList(new Streamer(lines[i - 3], lines[i - 2], new Uri(lines[i - 1]), new Uri(lines[i]) ));
                }
            }

            // creating Streams List 

            string[] streamLines = File.ReadAllLines(@"..\..\Python\data.txt", Encoding.Unicode);
            int testing = streamLines.Length;
            for (int i = 3; i < streamLines.Length; i += 4)
            {
                // convert from Tokyo Standard Time to UTC
                DateTime sourceTST = DateTime.ParseExact(streamLines[i - 3] + " " + streamLines[i - 2], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
                DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(sourceTST, tz);

                // search for alias that matches scrapped name and mark with ID
                int streamerID = 0;
                for (int j = 0; j < form.streamerList.Count; j++)
                {
                    streamerID = j;
                }

                // Use URL to extraxt URL Title
                Uri streamURL = new Uri(streamLines[i]);
                string name = GetTitle(streamURL.ToString());

                // create event and add to BaseForm's streamEvents list
                form.addEventList(new StreamEvents(form.streamerList[streamerID], utcTime, streamURL, name));
            }
                loadDone = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 10;
            // add worker routines here
            if (panel2.Width >= 800)
            {
                tickDone = true;
            }
            if (tickDone == true && loadDone == true)
            {
                this.Close();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public static string GetTitle(string url)
        {
            var api = $"http://youtube.com/get_video_info?video_id={GetArgs(url, "v", '?')}";
            return GetArgs(new WebClient().DownloadString(api), "title", '&');
        }

        private static string GetArgs(string args, string key, char query)
        {
            var iqs = args.IndexOf(query);
            return iqs == -1
                ? string.Empty
                : HttpUtility.ParseQueryString(iqs < args.Length - 1
                    ? args.Substring(iqs + 1) : string.Empty)[key];
        }
    }
}
