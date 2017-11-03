using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Messenger.Client.WinForms.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtBoxId.Mask = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSingUp_Click(object sender, EventArgs e)
        {
            using (var form = new ProfileInfo())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    
                }
            }
        }
    }
}
