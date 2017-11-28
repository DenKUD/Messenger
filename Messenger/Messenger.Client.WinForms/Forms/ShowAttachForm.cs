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
    public partial class ShowAttachForm : Form
    {
        public ShowAttachForm()
        {
            InitializeComponent();
        }
        public ShowAttachForm(Image img)
        {
            InitializeComponent();
            picBoxAttach.SizeMode = PictureBoxSizeMode.StretchImage;
            picBoxAttach.Image = img;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveAttachDialog.ShowDialog() == DialogResult.OK)
            {
                var path = saveAttachDialog.FileName;
               picBoxAttach.Image.Save(path);
            }
        }
    }

}
