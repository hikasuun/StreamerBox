// UserNameChangeForm.cs
// used to change the user's username
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
    public partial class UserNameChangeForm : Form
    {
        private BaseForm form;
        public UserNameChangeForm(BaseForm frm)
        {
            InitializeComponent();
            form = frm;
        }

        private void DiscardBtn_Click(object sender, EventArgs e) // discard change
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text)) // check for empty field
            {
                MessageBox.Show("Please do not leave field blanks.");
            }
            else // save
            {
                form.setUserName(textBox1.Text);

                this.Close();
            }
        }
    }
}
