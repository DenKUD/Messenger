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
    public partial class AddContactForm : Form
    {
        public Guid userToFindId;
        public String userToFindName;
        public AddContactForm()
        {
            InitializeComponent();
        }

        
        private void btnFind_Click(object sender, EventArgs e)
        {
            userToFindId = Guid.Parse(txtBoxId.Text.ToString());
            userToFindName = txtBoxUserName.Text;
        }
    }
}
