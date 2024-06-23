using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassRegistrationApp
{
    public partial class ClassSelectionForm : Form
    {
        LoginForm ParentForm;
        public int idxRegistration;
        public string strRegistration;
        Student currentStudent;
        User currentUser;

        public ClassSelectionForm()
        {
            InitializeComponent();
            ParentForm = LoginForm.OriginalForm;
            foreach (Course obj in ParentForm.CourseList)
                lsbCourseList.Items.Add(obj.CourseName);

            rtxtRegistrationInfo.Text = "";
        }

        public void SetCurrentUser(User user)
        {
            currentUser = user;
            currentStudent = ParentForm.StudentList.Find(x => (x.StudentID == currentUser.StudentID));

            idxRegistration = ParentForm.CourseRegList.FindIndex(x => (x.StudentID == currentUser.StudentID));
            if (idxRegistration >= 0)
            {
                foreach (Course obj in ParentForm.CourseRegList[idxRegistration].CourseEnrollList)
                {
                    int idx = lsbCourseList.FindString(obj.CourseName.Trim());
                    lsbCourseList.SetSelected(idx, true);
                }
            }

            ShowRegistrationInfo();
        }

        public string ShowRegistrationInfo()
        {
            strRegistration = "\t\tCourse Registration of Student\n";
            strRegistration += "________________________________________\n";
            strRegistration += String.Format("StudentID: {0}\nStudent Name: {1}\n",
                                            currentStudent.StudentID, currentStudent.StudentName);
            int sumscredit;
            if (idxRegistration >= 0)
                sumscredit = ParentForm.CourseRegList[idxRegistration].CalculateSumCredit();
            else
                sumscredit = 0;

            strRegistration += String.Format("Sum of Registered Credit: {0}\n", sumscredit);
            strRegistration += "________________________________________\n";
            strRegistration += "CourseID\t\tNumber of Credit\t\tCourse Name\n";

            Course obj;
            foreach (Object selectedItem in lsbCourseList.SelectedItems)
            {
                obj = ParentForm.CourseList.Find(x => (x.CourseName == selectedItem.ToString()));

                if (obj != null)
                    strRegistration += obj.CourseID + "\t\t" + obj.NumCredit + "\t\t\t" + obj.CourseName + "\n";
            }

            rtxtRegistrationInfo.Text = strRegistration;
            return strRegistration;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            ParentForm.ResetLogin = true;
            ParentForm.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (idxRegistration < 0)
            {
                ParentForm.CourseRegList.Add(new CourseRegistration(currentStudent.StudentID));
                idxRegistration = ParentForm.CourseRegList.FindIndex(x => (x.StudentID == currentStudent.StudentID));

                Course obj;
                foreach (Object selectItem in lsbCourseList.SelectedItems)
                {
                    obj = ParentForm.CourseList.Find(x => (x.CourseName == selectItem.ToString()));
                    ParentForm.CourseRegList[idxRegistration].CourseEnrollList.Add(obj);
                }
            }

            ShowRegistrationInfo();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ShowRegistrationInfo(), "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
