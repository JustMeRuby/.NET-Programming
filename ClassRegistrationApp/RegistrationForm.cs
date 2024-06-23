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

namespace ClassRegistrationApp
{
    public partial class RegistrationForm : Form
    {
        string startupPath;
        string AvatarPath;
        LoginForm ParentForm;

        public RegistrationForm()
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
                picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(RegistrationForm));
            picAvatar.Image = ((System.Drawing.Image)(resources.GetObject("picAvatar.Image")));
            picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            User obj = new User();
            Student objstudent = new Student();

            if (txtUserID.Text.Trim().Length == 0 || txtPassword.Text.Trim().Length == 0 || txtStudentID.Text.Trim().Length == 0)
            {
                MessageBox.Show("StudentID, UserName, Password are blank", "Input Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                MessageBox.Show("Password and Confirm Password are not matched", "Input Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            User SpecificOne = ParentForm.UserList.Find(x => (x.UserName == txtStudentID.Text) && (x.Password == txtPassword.Text));
            if (SpecificOne != null)
            {
                MessageBox.Show("UserID is existed", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            obj.UserName = txtUserID.Text;
            obj.Password = txtPassword.Text;
            obj.StudentID = txtStudentID.Text;

            objstudent.StudentID = txtStudentID.Text;
            objstudent.StudentName = txtStudentName.Text;
            objstudent.email = txtEmail.Text;
            objstudent.Avatar = picAvatar.Image;
            objstudent.Birthday = dtBirthday.Value;
            objstudent.Gender = (rdMale.Checked == true) ? Sex.Male : Sex.Female;

            ParentForm.UserList.Add(obj);
            ParentForm.StudentList.Add(objstudent);

            MessageBox.Show("New UserID has been created", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStudentID.Text = "";
            txtStudentName.Text = "";
            dtBirthday.Value = DateTime.Now;
            rdMale.Checked = true;
            rdFemale.Checked = false;
            txtUserID.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtPasswordConfirm.Text = "";

            ComponentResourceManager resources = new ComponentResourceManager(typeof(RegistrationForm));
            picAvatar.Image = ((System.Drawing.Image)(resources.GetObject("picAvatar.Image")));
            picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            ParentForm.Show();
        }
    }
}
