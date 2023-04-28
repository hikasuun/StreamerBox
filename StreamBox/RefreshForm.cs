using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamBox
{
    public partial class RefreshForm : Form
    {
        private BaseForm form;
        public RefreshForm(BaseForm frm)
        {
            InitializeComponent();
            form = frm;
        }
        private void RefreshForm_Load(object sender, EventArgs e)
        {
            runExecutable(); // launch screen scraper
            createStreamsList(); // build lists
        }

        private void createStreamsList()
        {
            form.streamsList.Clear(); // clear streams list before building new one

            // creating Streams List 
            string[] streamLines = System.IO.File.ReadAllLines(@"..\..\Python\data.txt", Encoding.UTF8);
            int testing = streamLines.Length;
            for (int i = 3; i < streamLines.Length; i += 4)
            {
                // convert from Tokyo Standard Time to UTC
                DateTime sourceTST = DateTime.ParseExact(streamLines[i - 3] + " " + streamLines[i - 2], "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
                DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(sourceTST, tz);
                DateTime localTime = utcTime.ToLocalTime();

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
                form.addEventList(new StreamEvents(form.streamerList[streamerID], localTime, streamURL));
            }
            form.streamsList = form.streamsList.OrderBy(o => o.getStreamDate()).ToList();
            this.Close();
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

       
    }
}
