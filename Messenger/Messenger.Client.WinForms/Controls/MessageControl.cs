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
    public partial class MessageControl : UserControl
    {
        private Messenger.Model.Message _message;
        public MessageControl(Messenger.Model.Message message)
        {
            _message = message;
            InitializeComponent();
            lblUsername.Text = _message.User.Name;
            lblDateTime.Text = _message.dtime.ToString();
            txtBoxContents.Text = _message.Text;
            if(_message.Body!=null)
            {
                try
                {
                    pictureBox1.Image = (Bitmap)new ImageConverter().ConvertFrom(_message.Body);
                }
                catch (Exception ane)
                {
                    MessageBox.Show(ane.ToString(), "Ошибка отображения вложения");
                }
                  
                
            }
        }
    }
}
