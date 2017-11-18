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
using Messenger.Client.WinForms.Enums;


namespace Messenger.Client.WinForms.Controls
{
    public partial class MessageControl : UserControl
    {
        private Model.Message _message;
        private Image img;
        private AttachType _attachType;

        public override string Text
        {
            get { return _message.Text; }
        }
        public MessageControl(Model.Message message)
        {
            _message = message;
            InitializeComponent();
            lblUsername.Text = _message.User.Name;
            lblDateTime.Text = _message.dtime.ToString();
            txtBoxContents.Text = _message.Text;
            if (_message.Body != null)
            {
                try
                {
                    pictureBox1.Image = (Bitmap)new ImageConverter().ConvertFrom(_message.Body);
                    img = pictureBox1.Image;
                    _attachType = AttachType.Image;
                }
                catch (ArgumentException ane)
                {
                    pictureBox1.Image = Properties.Resources.attach as Bitmap;
                    img = null;
                    _attachType = AttachType.Binary;
                }
            }
            else { _attachType = AttachType.None; }
        }

        public void SetDeleteButtonVisibility(bool isVisible)
        {
            btnDelete.Visible = isVisible;   
        }

        private void сохранитьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_attachType != AttachType.None)
            {
                if (saveattachDialog1.ShowDialog() == DialogResult.OK)
                {
                    var path = saveattachDialog1.FileName;
                    if (_attachType == AttachType.Image) { img.Save(path); }
                    else { System.IO.File.WriteAllBytes(path, _message.Body); }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (_attachType != AttachType.None)
            {
                if (_attachType == AttachType.Image) saveattachDialog1.DefaultExt = "png";
                else saveattachDialog1.DefaultExt = "";
                if (saveattachDialog1.ShowDialog() == DialogResult.OK)
                {
                    var path = saveattachDialog1.FileName;
                    if (_attachType == AttachType.Image) {img.Save(path); }
                    else { System.IO.File.WriteAllBytes(path, _message.Body); }
                }
            }
        }
    }
}
