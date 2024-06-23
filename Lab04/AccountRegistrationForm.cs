using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab04
{
    public partial class AccountRegistrationForm : Form
    {
        string startupPath;
        string AvatarPath;
        LoginForm ParentForm;

        public AccountRegistrationForm()
        {
            InitializeComponent();
            startupPath = LoginForm.OriginalForm.startupPath;
            ParentForm = LoginForm.OriginalForm;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDlg.Title = "Find Avatar Image";
            openFileDlg.Filter = "JPG files|*.jpg";
            openFileDlg.InitialDirectory = startupPath;

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                AvatarPath = openFileDlg.FileName;
                picAvatar.Image = Image.FromFile(AvatarPath);

                startupPath = Path.GetDirectoryName(AvatarPath);
                picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(AccountRegistrationForm));
            picAvatar.Image = ((System.Drawing.Image)(resources.GetObject("picAvatar.Image")));
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            User obj = new User();
            Customer objCustomer = new Customer();

            if (txtUserID.Text.Trim().Length == 0 || txtPassword.Text.Trim().Length == 0 ||
                txtCustomerID.Text.Trim().Length == 0 || txtPasswordConfirm.Text.Trim().Length == 0 ||
                txtCustomerName.Text.Trim().Length == 0 || txtPassport.Text.Trim().Length == 0 ||
                txtNationality.Text.Trim().Length == 0)
            {
                MessageBox.Show("Not enough information, please fill in all the blanks", "Input Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                MessageBox.Show("Password and Confirm Password are not matched", "Input Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            User SpecificOne = ParentForm.UserList.Find(x => (x.UserID == txtUserID.Text));
            if (SpecificOne != null)
            {
                MessageBox.Show("UserID is existed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            obj.UserID = txtUserID.Text;
            obj.Password = txtPassword.Text;
            obj.CustomerID = txtCustomerID.Text;

            objCustomer.CustomerID = txtCustomerID.Text;
            objCustomer.CustomerName = txtCustomerName.Text;
            objCustomer.PassPortNbr = txtPassport.Text;
            objCustomer.Nationality = txtNationality.Text;
            objCustomer.Birthday = dtBirthday.Value;
            objCustomer.Avatar = picAvatar.Image;

            ParentForm.UserList.Add(obj);
            ParentForm.CustomerList.Add(objCustomer);

            MessageBox.Show("New UserID has been created", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCustomerID.Text = "";
            txtCustomerName.Text = "";
            dtBirthday.Value = DateTime.Now;
            txtPassport.Text = "";
            txtNationality.Text = "";
            txtUserID.Text = "";
            txtPassword.Text = "";
            txtPasswordConfirm.Text = "";

            ComponentResourceManager resources = new ComponentResourceManager(typeof(AccountRegistrationForm));
            picAvatar.Image = ((System.Drawing.Image)(resources.GetObject("picAvatar.Image")));
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            ParentForm.Show();
        }
    }
}
