using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamBox
{
    public partial class FirstTimeUserForm : Form
    {
        private ReadOnlyCollection<TimeZoneInfo> tzCollection;
        private SplashScreen form;

        public FirstTimeUserForm(SplashScreen frm)
        {
            InitializeComponent();
            form = frm; 

            tzCollection = TimeZoneInfo.GetSystemTimeZones();
            timeZoneCombo.DataSource= tzCollection;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(userNameTxtBox.Text) ||
                timeZoneCombo.SelectedItem == null)
            {
                MessageBox.Show("Please do not leave field blanks.");
            }
            else
            {
                form.userName = userNameTxtBox.Text;
                form.time = (TimeZoneInfo)timeZoneCombo.SelectedItem;

                this.Close();
            }
        }
    }
}
