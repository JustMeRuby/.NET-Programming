using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab04
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string PassPortNbr { get; set; }
        public string Nationality { get; set; }
        public DateTime Birthday { get; set; }
        public Image Avatar { get; set; }

        public Customer()
        {
            CustomerID = "Not assigned";
        }
        public Customer(string CustomerID, string CustomerName, string PassPortNbr, string Nationality, Image Avatar, DateTime Birthday)
        {
            this.CustomerID = CustomerID;
            this.CustomerName = CustomerName;
            this.PassPortNbr = PassPortNbr;
            this.Nationality = Nationality;
            this.Avatar = Avatar;
            this.Birthday = Birthday;
        }
    }

    public class User
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string CustomerID { get; set; }

        public User()
        {
            UserID = "Not assigned";
        }

        public User(string UserID, string Password, string CustomerID)
        {
            this.UserID = UserID;
            this.Password = Password;
            this.CustomerID = CustomerID;
        }
    }

    public enum Rank { A, B, C, D, Unknown}
    public class Flight
    {
        public string FlightID { get; set; }
        public Rank FlightType { get; set; }
        public TimeSpan TimeDepart { get; set; }
        public TimeSpan TimeArrival { get; set; }

        public Flight()
        {
            FlightID = "Not assigned";
        }

        public Flight(string FlightID, Rank FlightType, TimeSpan TimeDepart, TimeSpan TimeArrival)
        {
            this.FlightID = FlightID;
            this.FlightType = FlightType;
            this.TimeDepart = TimeDepart;
            this.TimeArrival = TimeArrival;
        }
    }

    public class FlightRegistration
    {
        public string CustomerID { get; set; }
        public List<Flight> FlightEnrollList;

        public FlightRegistration()
        {
            CustomerID = "Not assigned";
            FlightEnrollList = new List<Flight>();
        }
        public FlightRegistration(string CustomerID)
        {
            this.CustomerID = CustomerID;
            FlightEnrollList = new List<Flight>();
        }

        public int CalculateSumFlight()
        {           
            return FlightEnrollList.Count;
        }
    }
}
