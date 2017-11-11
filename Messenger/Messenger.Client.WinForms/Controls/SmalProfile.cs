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
    public partial class SmalProfile : UserControl
    {
        private Image _userPic;
        private string _userName;
        public SmalProfile(User user)
        {
            InitializeComponent();
            Update(user);
        }

        public SmalProfile()
        {
            InitializeComponent();
            
        }
        public void Update(User user)
        {
            picBoxUserPic.SizeMode = PictureBoxSizeMode.StretchImage;
            if (!(user.Userpic.Length==0))
            {
                try
                {
                    _userPic = (Bitmap)new ImageConverter().ConvertFrom(user.Userpic);
                    this.picBoxUserPic.Image = _userPic;
                }
                catch (ArgumentException ex) { }
            }
            _userName = user.Name;
            this.lblUsername.Text = _userName;
            this.lblUserId.Text = user.Id.ToString();
            this.Refresh();
            
        }
        
        public void Clear()
        {
            _userPic = null;
            _userName = null;
            picBoxUserPic.Image.Dispose();
            lblUsername.Text = "";
            lblUserId.Text = "";
        }
       
    }
}
