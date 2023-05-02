// StreamerSettingsForm.cs
// allows user to customize visibility (whether to be notified) of talents
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
    public partial class StreamerSettingsForm : Form
    {
        private BaseForm form;
        private int jptoggle, entoggle, idtoggle, tgl = 0; // toggles for mass visibility toggling
        public StreamerSettingsForm(BaseForm frm)
        {
            InitializeComponent();
            form = frm;
            this.TopMost = true;

            // add streamers to list with visibility toggled off or on (DEFAULT IS ON FOR NEW USER)
            for (int i = 0; i <= form.streamerList.Count()-1; i++)
            {
                StreamerCheckBoxes.Items.Add(form.streamerList[i].getStreamerName(), form.streamerList[i].getVisible());
            }
            for (int i = 0; i <= form.streamerList.Count()-1; i++)
            {
                if (form.streamerList[i].getVisible() == true)
                {
                    StreamerCheckBoxes.SetItemCheckState(i, CheckState.Checked);
                }
                else
                {
                    StreamerCheckBoxes.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }

        // save changes
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= form.streamerList.Count() - 1; i++)
            {
                if (StreamerCheckBoxes.GetItemChecked(i) == false)
                {
                    form.streamerList[i].setVisible(false);
                }
                else
                {
                    form.streamerList[i].setVisible(true);
                }
            }
            // go through current streams and modify visibility
            for (int i = 0; i <= form.streamsList.Count-1; i++)
            {
                for (int j = 0; j <= form.streamerList.Count-1; j++)
                {
                    if (String.Equals(form.streamsList[i].getStreamer().getStreamerName(), form.streamerList[j].getStreamerName()))
                    {
                        form.streamsList[i].getStreamer().setVisible(form.streamerList[j].getVisible());
                    }
                }
            }

            MessageBox.Show("Changes saved.");
            this.Close();
        }

        // dont save changes
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // toggles visibility for JP (HOLOLIVE) Branch
        private void JPBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= form.streamerList.Count() - 1; i++)
            {
                if (String.Equals(form.streamerList[i].getBranch(), "Hololive"))
                {
                    if (jptoggle == 0)
                    {
                        StreamerCheckBoxes.SetItemCheckState(i, CheckState.Checked);
                    }
                    else
                    {
                        StreamerCheckBoxes.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
                
            }
            if (jptoggle == 0)
                jptoggle = 1;
            else jptoggle = 0;
        }

        // toggles visibility for ALL streamers / talents
        private void alltoggle_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= form.streamerList.Count() - 1; i++)
            {
                if (tgl == 0)
                {
                    StreamerCheckBoxes.SetItemCheckState(i, CheckState.Checked);
                }
                else
                {
                    StreamerCheckBoxes.SetItemCheckState(i, CheckState.Unchecked);
                }

            }
            if (tgl == 0)
                tgl = 1;
            else tgl= 0;
        }

        // toggles visibility for EN (HOLOEN) Branch
        private void ENBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= form.streamerList.Count() - 1; i++)
            {
                if (String.Equals(form.streamerList[i].getBranch(), "HoloEN"))
                {
                    if (entoggle == 0)
                    {
                        StreamerCheckBoxes.SetItemCheckState(i, CheckState.Checked);
                    }
                    else
                    {
                        StreamerCheckBoxes.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }

            }
            if (entoggle == 0)
                entoggle = 1;
            else entoggle = 0;
        }

        // toggles visibility for ID (HOLOID) Branch
        private void IDBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= form.streamerList.Count() - 1; i++)
            {
                if (String.Equals(form.streamerList[i].getBranch(), "HoloID"))
                {
                    if (idtoggle == 0)
                    {
                        StreamerCheckBoxes.SetItemCheckState(i, CheckState.Checked);
                    }
                    else
                    {
                        StreamerCheckBoxes.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }

            }
            if (idtoggle == 0)
                idtoggle = 1;
            else idtoggle = 0;
        }
    }
}
