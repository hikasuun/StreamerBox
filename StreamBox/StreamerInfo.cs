// StreamerInfo.cs
// Window to show information about individual talent
using StreamBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamerBox
{
    public partial class StreamerInfo : Form
    {
        private BaseForm form;
        private Streamer talent;
        // talent has a picture, name, youtube channel, twitter account, and branch
        public StreamerInfo(BaseForm frm, Streamer selectedTalent)
        {
            InitializeComponent();
            this.form = frm;
            this.talent= selectedTalent;
            this.Text = talent.getStreamerName(); // changes name of window to talent
            TalentNameLabel.Text = talent.getStreamerName();
            TalentBranchLabel.Text = talent.getBranch();
            string path = @"..\..\VTuberProfilePictures\" + talent.getStreamerName() + ".png"; // gets talent image from application image folder
            TalentImage.Image = Image.FromFile(path);
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void TalentYouTubeChannelLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // prevents re-entry bug causing 2 streams being opened
            this.BeginInvoke(new Action(() =>
            {
                System.Diagnostics.Process.Start(talent.getYoutubeURL().ToString());
            }));
        }

        private void TalentTwitterAccountLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // prevents re-entry bug causing 2 streams being opened
            this.BeginInvoke(new Action(() =>
            {
                System.Diagnostics.Process.Start(talent.getTwitterURL().ToString());
            }));
        }

        private void StreamerInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
