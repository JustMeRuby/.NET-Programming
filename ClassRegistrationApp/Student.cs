using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassRegistrationApp
{
    public enum Sex { Male, Female }

    public class Student
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public Sex Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string email { get; set; }
        public Image Avatar { get; set; }

        public Student()
        {
            StudentID = "Not assigned";
        }
        public Student(string StudentID, string StudentName, Image Avatar, Sex Gender, DateTime Birthday, string email)
        {
            this.StudentID = StudentID;
            this.StudentName = StudentName;
            this.Avatar = Avatar;
            this.Gender = Gender;
            this.Birthday = Birthday;
            this.email = email;
        }
    }

    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string StudentID { get; set; }

        public User()
        {
            UserName = "Not assigned";
        }

        public User(string UserName, string Password, string StudentID)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.StudentID = StudentID;
        }
    }

    public class Course
    {
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public int NumCredit { get; set; }

        public Course()
        {
            CourseID = "Not assigned";
        }

        public Course(string CourseID, string CourseName, int NumCredit)
        {
            this.CourseID = CourseID;
            this.CourseName = CourseName;
            this.NumCredit = NumCredit;
        }
    }

    public class CourseRegistration
    {
        public string StudentID { get; set; }
        public List<Course> CourseEnrollList;

        public CourseRegistration()
        {
            StudentID = "Not assigned";
            CourseEnrollList = new List<Course>();
        }
        public CourseRegistration(string StudentID)
        {
            this.StudentID = StudentID;
            CourseEnrollList = new List<Course>();
        }

        public int CalculateSumCredit()
        {
            return CourseEnrollList.Sum(x => x.NumCredit);
        }
    }
}
