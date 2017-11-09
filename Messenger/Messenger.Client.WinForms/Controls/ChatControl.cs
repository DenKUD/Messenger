using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Messenger.Model;

namespace Messenger.Client.WinForms.Controls
{
    public partial class ChatControl : UserControl
    {
        Messenger.Model.Chat _chat { get; set; }
        public ChatControl()
        {

            InitializeComponent();
            _chat = new Chat { };
        }
        public ChatControl(Model.Chat cchat)
        {

            InitializeComponent();
            _chat = cchat;
            flowLayoutPanelChatMembers.SuspendLayout();
            foreach (User member in  _chat.Members)
            {
                flowLayoutPanelChatMembers.Controls.Add(new SmalProfile(member));
            }
            flowLayoutPanelChatMembers.ResumeLayout();
        }
        public void AddMessage(Messenger.Model.Message message)
        {
            flowLayoutPanelMessages.Controls.Add(new MessageControl(message));
        }

        private void flowLayoutPanelChatMembers_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
