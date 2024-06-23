using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04
{
    public partial class AirTicketBookingForm : Form
    {
        LoginForm ParentForm;
        public int idxRegistration;
        public string strRegistration;
        Customer currentCustomer;
        User currentUser;

        public AirTicketBookingForm()
        {
            InitializeComponent();
            ParentForm = LoginForm.OriginalForm;

            foreach (Flight obj in ParentForm.FlightList)
                lsbFlightList.Items.Add(obj.FlightID);

            rtxtRegistrationInfo.Text = "";
        }

        public void SetCurrentUser(User user)
        {
            currentUser = user;
            currentCustomer = ParentForm.CustomerList.Find(x => (x.CustomerID == currentUser.CustomerID));

            idxRegistration = ParentForm.FlightRegList.FindIndex(x => (x.CustomerID == currentCustomer.CustomerID));
            if (idxRegistration >= 0)
            {
                foreach (Flight obj in ParentForm.FlightRegList[idxRegistration].FlightEnrollList)
                {
                    int idx = lsbFlightList.FindString(obj.FlightID.Trim());
                    lsbFlightList.SetSelected(idx, true);
                }
            }

            ShowRegistrationInfo();
        }

        public string ShowRegistrationInfo()
        {
            strRegistration = "\tFlight Registration of Customer\n";
            strRegistration += "________________________________________\n";
            strRegistration += String.Format("CustomerID: {0}\nCustomer Name: {1}\n",
                                            currentCustomer.CustomerID, currentCustomer.CustomerName);
            int sumsflight;
            if (idxRegistration >= 0)
                sumsflight = ParentForm.FlightRegList[idxRegistration].CalculateSumFlight();
            else
                sumsflight = 0;

            strRegistration += String.Format("Total number of Flights: {0}\n", sumsflight);
            strRegistration += "________________________________________\n";
            strRegistration += "FlightID\tType\tDepart\tArrive\n";

            Flight obj;
            foreach (Object selectedItem in lsbFlightList.SelectedItems)
            {
                obj = ParentForm.FlightList.Find(x => (x.FlightID == selectedItem.ToString()));

                if (obj != null)
                    strRegistration += obj.FlightID + "\t" + obj.FlightType + "\t" + obj.TimeDepart + "\t" + obj.TimeArrival + "\n";
            }

            rtxtRegistrationInfo.Text = strRegistration;
            return strRegistration;
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (idxRegistration < 0)
            {
                ParentForm.FlightRegList.Add(new FlightRegistration(currentCustomer.CustomerID));
                idxRegistration = ParentForm.FlightRegList.FindIndex(x => (x.CustomerID == currentCustomer.CustomerID));

                Flight obj;
                foreach (Object selectItem in lsbFlightList.SelectedItems)
                {
                    obj = ParentForm.FlightList.Find(x => (x.FlightID == selectItem.ToString()));
                    ParentForm.FlightRegList[idxRegistration].FlightEnrollList.Add(obj);
                }
            }
            else
            {
                ParentForm.FlightRegList[idxRegistration].FlightEnrollList.Clear();

                Flight obj;
                foreach (Object selectItem in lsbFlightList.SelectedItems)
                {
                    obj = ParentForm.FlightList.Find(x => (x.FlightID == selectItem.ToString()));
                    ParentForm.FlightRegList[idxRegistration].FlightEnrollList.Add(obj);
                }
            }

            ShowRegistrationInfo();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ShowRegistrationInfo(), "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            ParentForm.ResetLogin = true;
            ParentForm.Show();
        }
    }
}
