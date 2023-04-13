using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace StreamBox
{
    public partial class SplashScreen : Form
    {
        private BaseForm form;
        public string userName;
        public TimeZoneInfo time;
        private Boolean tickDone = false;
        private Boolean loadDone = false;
        private SaveStateHelper sth = null;
        public SplashScreen(BaseForm frm)
        {
            InitializeComponent();
            form = frm;
            this.TopMost = true;

            // check for first time user
            if (System.IO.File.Exists(@"..\..\saveState.xml"))
            {
                sth = new SaveStateHelper();
                sth.readUserState(@"..\..\saveState.xml");
                form.setUserName(sth.currentSaveState.UserName);
                foreach(Streamer streamers in sth.deserializedStreamerList)
                {
                    form.addStreamerList(streamers);
                }

            }
            else
            {
                FirstTimeUserForm Splashform = new FirstTimeUserForm(this);
                Splashform.ShowDialog();

                form.setUserName(userName);
                form.setTimeZone(time);
                string[] lines = System.IO.File.ReadAllLines(@"..\..\InfoStreamer.txt", Encoding.UTF8);
                for (int i = 4; i < lines.Length; i += 5) // read a set ( 5 lines ) at a time for each streamer
                {
                    // line 0 = Name
                    // line 1 = Alias
                    // line 2 = Twitter URL
                    // line 3 = YouTube URL
                    // line 4 = Hololive Branch
                    // added at end is true default for visibility
                    form.addStreamerList(new Streamer(lines[i - 4], lines[i - 3], new Uri(lines[i - 2]), new Uri(lines[i - 1]), lines[i], true));
                }
            }

            // set timezone based on user's system
            form.setTimeZone(TimeZoneInfo.Local);
            // launch screen scraper
            runExecutable();
            
            // creating Streams List 
            string[] streamLines = System.IO.File.ReadAllLines(@"..\..\Python\data.txt", Encoding.UTF8);
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
                    if (form.streamerList[j].getStreamerAlias() == streamLines[i - 1])
                    {
                        streamerID = j;
                    }

                }

                // Use URL to extraxt URL Title
                Uri streamURL = new Uri(streamLines[i]);
                string name = streamLines[i];

                // create event and add to BaseForm's streamEvents list

                form.addEventList(new StreamEvents(form.streamerList[streamerID], utcTime, streamURL));
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

        private void runExecutable()
        {
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
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
