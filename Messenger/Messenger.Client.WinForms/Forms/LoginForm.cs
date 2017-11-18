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
    public partial class LoginForm : Form
    {
        private ServiceClient _serviceClient;
        public Messenger.Model.User user;
        public LoginForm(ServiceClient serviceClient)
        {
            InitializeComponent();
            _serviceClient = serviceClient;
            txtBoxId.Mask = "aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa";
            user = new Model.User { };
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSingUp_Click(object sender, EventArgs e)
        {
            using (var form = new ProfileInfo(_serviceClient))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.user = form.user;
                    form.Close();
                }
            }
            txtBoxId.Text = user.Id.ToString();
            txtBoxPassword.Text = user.Password;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                user.Id = Guid.Parse(txtBoxId.Text.ToString());
                user.Password = txtBoxPassword.Text;
            }
            catch(FormatException ex)
            {
                MessageBox.Show("Неправильно введен логин");
            }
            finally
            {
                txtBoxId.Text = "";
                txtBoxPassword.Text = "";
            }
        }


    }
}
