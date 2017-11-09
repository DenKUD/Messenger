using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Messenger.Model;

namespace Messenger.Client.WinForms.Forms
{
    public partial class ProfileInfo : Form
    {
        Image userPic;
        public User user;
        private ServiceClient _serviceClient;
        public ProfileInfo()
        {
            InitializeComponent();
            this.AllowDrop=true;
        }

        public ProfileInfo(ServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
            InitializeComponent();
            this.AllowDrop = true;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PrpofileInfo_DragDrop(object sender, DragEventArgs e)
        {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                userPic= Image.FromFile(files[0]);
                picBoxUserPic.Image = userPic;   
        }

        private void btnLoadUserpic_Click(object sender, EventArgs e)
        {
            openFileDialogUserPic.ShowDialog();
        }

        private void openFileDialogUserPic_FileOk(object sender, CancelEventArgs e)
        {
            userPic = new Bitmap(openFileDialogUserPic.FileName);
            picBoxUserPic.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxUserPic.Image = userPic;
            picBoxUserPic.Refresh();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] userPicByte = (byte[])_imageConverter.ConvertTo(userPic, typeof(byte[]));
            user = new User
            {
                Bio = txtBoxBio.Text,
                Name = txtBoxUsername.Text,
                Password = txtBoxPassword.Text,
                Userpic = userPicByte
            };
            user = _serviceClient.CreateUser(user);
            
        }
    }
}
