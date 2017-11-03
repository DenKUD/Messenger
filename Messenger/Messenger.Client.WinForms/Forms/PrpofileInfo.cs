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
    public partial class ProfileInfo : Form
    {
        public ProfileInfo()
        {
            InitializeComponent();
            this.AllowDrop=true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PrpofileInfo_DragDrop(object sender, DragEventArgs e)
        {
            int x = this.PointToClient(new Point(e.X, e.Y)).X;

            int y = this.PointToClient(new Point(e.X, e.Y)).Y;

            if (x >= picBoxUserPic.Location.X && x <= picBoxUserPic.Location.X + picBoxUserPic.Width && y >= picBoxUserPic.Location.Y && y <= picBoxUserPic.Location.Y + picBoxUserPic.Height)

            {

                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                picBoxUserPic.Image = Image.FromFile(files[0]);

            }
        }
    }
}
