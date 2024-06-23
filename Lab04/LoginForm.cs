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
    public partial class LoginForm : Form
    {
        public static LoginForm OriginalForm;
        public List<Customer> CustomerList;
        public List<User> UserList;
        public List<Flight> FlightList;
        public List<FlightRegistration> FlightRegList;
        public string startupPath;
        public bool ResetLogin;

        public LoginForm()
        {
            InitializeComponent();
            OriginalForm = this;
            startupPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            CustomerList = new List<Customer>();
            CustomerList.Add(new Customer("ST001", "Admin", "123456789", "Vietnam",
                                        Image.FromFile(startupPath + "\\Images\\Doraemon.jpg"), DateTime.Now));

            UserList = new List<User>();
            UserList.Add(new User("Admin", "1234", "ST001"));

            FlightList = new List<Flight>();
            FlightList.Add(new Flight("CO001", Rank.A, new TimeSpan(0, 30, 0), new TimeSpan(1, 30, 0)));
            FlightList.Add(new Flight("CO002", Rank.B, new TimeSpan(2, 30, 0), new TimeSpan(3, 30, 0)));
            FlightList.Add(new Flight("CO003", Rank.C, new TimeSpan(4, 30, 0), new TimeSpan(5, 30, 0)));
            FlightList.Add(new Flight("CO004", Rank.D, new TimeSpan(6, 30, 0), new TimeSpan(7, 30, 0)));
            FlightList.Add(new Flight("CO005", Rank.A, new TimeSpan(8, 30, 0), new TimeSpan(9, 30, 0)));
            FlightList.Add(new Flight("CO006", Rank.B, new TimeSpan(10, 30, 0), new TimeSpan(11, 30, 0)));
            FlightList.Add(new Flight("CO007", Rank.C, new TimeSpan(12, 30, 0), new TimeSpan(13, 30, 0)));

            FlightRegList = new List<FlightRegistration>();
            ResetLogin = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text.Length == 0)
            {
                MessageBox.Show("Please enter UserID", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUserID.Focus();
                return;
            }
            if (txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Please enter password", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Focus();
                return;
            }

            User SpecificOne = UserList.Find(x => (x.UserID == txtUserID.Text) && (x.Password == txtPassword.Text));
            if (SpecificOne == null)
            {
                MessageBox.Show("UserID and Password are not match.\nPlease reinput or register a new one",
                                "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUserID.Text = "";
                txtPassword.Text = "";
                txtUserID.Focus();
                return;
            }

            AirTicketBookingForm obj = new AirTicketBookingForm();
            User currentUser = UserList.Find(x => (x.UserID == txtUserID.Text) && (x.Password == txtPassword.Text));
            obj.SetCurrentUser(currentUser);
            this.Hide();
            obj.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void linkLblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AccountRegistrationForm obj = new AccountRegistrationForm();
            this.Hide();
            obj.Show();
        }

        private void linkLblRegister_VisibleChanged(object sender, EventArgs e)
        {
            if (ResetLogin == true)
            {
                txtUserID.Text = "";
                txtPassword.Text = "";
            }
        }
    }
}
