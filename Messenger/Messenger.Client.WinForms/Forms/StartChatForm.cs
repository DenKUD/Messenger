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
    public partial class StartChatForm : Form
    {
        public StartChatForm()
        {
            InitializeComponent();
        }

        public string ChatName
        {
            get { return textBoxChatName.Text; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ChatName == "" || ChatName == null)
            {
                MessageBox.Show("Необходимо ввести название");
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
