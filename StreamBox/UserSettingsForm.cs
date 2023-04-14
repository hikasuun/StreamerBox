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
    public partial class UserSettingsForm : Form
    {
        private BaseForm form;
        public UserSettingsForm(BaseForm frm)
        {
            InitializeComponent();
            form = frm;
        }

        private void DiscardBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please do not leave field blanks.");
            }
            else
            {
                form.setUserName(textBox1.Text);

                this.Close();
            }
        }
    }
}
