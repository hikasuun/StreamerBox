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
        private SplashScreen form;

        public FirstTimeUserForm(SplashScreen frm)
        {
            InitializeComponent();
            form = frm;
            this.TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(userNameTxtBox.Text))
            {
                MessageBox.Show("Please do not leave field blanks.");
            }
            else
            {
                form.userName = userNameTxtBox.Text;

                this.Close();
            }
        }
    }
}
