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
        private int jptoggle, entoggle, idtoggle, tgl = 0;
        public StreamerSettingsForm(BaseForm frm)
        {
            InitializeComponent();
            form = frm;
            this.TopMost = true;

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

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
