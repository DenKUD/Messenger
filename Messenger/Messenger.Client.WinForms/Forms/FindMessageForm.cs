using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Messenger.Client.WinForms.Controls;

namespace Messenger.Client.WinForms.Forms
{
    public partial class FindMessageForm : Form
    {
        //private List<Model.Message> _messages;
        public FindMessageForm()
        {
            InitializeComponent();
        }
        public FindMessageForm(IEnumerable<Model.Message> messages)
        {
            InitializeComponent();
            
            foreach (Model.Message m in messages) 
            flowLayoutPanel1.Controls.Add(new MessageControl(m));
            
        }
    }
}
