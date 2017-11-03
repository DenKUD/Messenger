using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Messenger.Client.WinForms.Forms;

namespace Messenger.Client.WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (var form = new LoginForm()) { 
                if (form.ShowDialog() == DialogResult.OK)
                {
                    
                }
            }
            ;
            
        }

       
    }
}
