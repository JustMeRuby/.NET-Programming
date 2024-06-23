using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainData;

namespace Lab03
{
    class Program
    {
        static void UpdateNumberOfCustomers(Company company)
        {
            company.ValNumberOfCustomers = company.Customers.Count;
        }
        static void Main(string[] args)
        {
            Company company = new Company("Gangster Company");

            company.CompanyAddOrRemoveEvent += new Company.CompanyHandler(UpdateNumberOfCustomers);

            //company.Customers.Add(new Customer("Customer A", "Address A", "1111111111", CustomerType.TrungThanh));
            //company.Customers.Add(new Customer("Customer B", "Address B", "2222222222", CustomerType.TiemNang));
            //company.Customers.Add(new Customer("Customer C", "Address C", "3333333333", CustomerType.CanQuanTam));
            //company.CompanyInfo();

            //Console.WriteLine("Customer Searching ..................\n");
            //company.SearchCustomer("Customer A").CustomerInfo();
            //company.SearchCustomer("Customer Z").CustomerInfo();
            //company.SearchCustomer(1).CustomerInfo();
            //company.SearchCustomer(99).CustomerInfo();

            //Console.WriteLine("Customer Searching ..................\n");
            //Console.WriteLine(company.SearchCustomer("Customer A").ConvertToString());
            //Console.WriteLine(company.SearchCustomer("Customer Z").ConvertToString());
            //Console.WriteLine(company.SearchCustomer(1).ConvertToString());
            //Console.WriteLine(company.SearchCustomer(99).ConvertToString());

            company.AddCustomer(new Customer("Customer A", "Address A", "1111111111", CustomerType.TrungThanh));
            company.AddCustomer(new Customer("Customer B", "Address B", "2222222222", CustomerType.TiemNang));
            company.AddCustomer(new Customer("Customer C", "Address C", "3333333333", CustomerType.CanQuanTam));
            Console.WriteLine();
            company.CompanyInfo();
            Customer customer = company.SearchCustomer("Customer A");
            company.RemoveCustomer(customer);
            Console.WriteLine();
            company.CompanyInfo();

            Console.ReadKey();
        }
    }
}

namespace MainData
{
    public enum CustomerType { TrungThanh, TiemNang, CanQuanTam, KhachHangKhac}
    public class Customer
    {
        private string CustomerID;
        private string CustomerAddress;
        private string CustomerPhone;
        private CustomerType CustomerType;

        public Customer(string CustomerID = "Not assigned", string CustomerAddress = "Not assigned",
                        string CustomerPhone = "0000000000", CustomerType CustomerType = CustomerType.KhachHangKhac)
        {
            this.CustomerID = CustomerID;
            this.CustomerAddress = CustomerAddress;
            this.CustomerPhone = CustomerPhone;
            this.CustomerType = CustomerType;
        }

        public void CustomerInfo()
        {
            if (CustomerID != "Not assigned")
            {
                string CustomerTypeString = Enum.GetName(typeof(CustomerType), CustomerType);
                Console.WriteLine("Displaying Customer Info ...............");
                Console.WriteLine("Customer ID: {0}", CustomerID);
                Console.WriteLine("Customer Address: {0}", CustomerAddress);
                Console.WriteLine("Customer Phone: {0}", CustomerPhone);
                Console.WriteLine("Customer Type: {0}", CustomerTypeString);
            }
        }

        public string ValCustomerID
        {
            get { return CustomerID; }
            set { CustomerID = value; }
        }
        public string ValCustomerAddress
        {
            get { return CustomerAddress; }
            set { CustomerAddress = value; }
        }
        public string ValCustomerPhone
        {
            get { return CustomerPhone; }
            set { CustomerPhone = value; }
        }
        public CustomerType ValCustomerType
        {
            get { return CustomerType; }
            set { CustomerType = value; }
        }
    }
    public class Company
    {
        public List<Customer> Customers { get; set; }
        private string Name;
        Dictionary<CustomerType, string> CustomerTypeInfo = new Dictionary<CustomerType, string>();
        public delegate void CompanyHandler(Company company);
        public event CompanyHandler CompanyAddOrRemoveEvent;
        int NumberOfCustomers = 0;

        public Company(string Name = "Not assigned")
        {
            this.Name = Name;
            Customers = new List<Customer>();
            CustomerTypeInfo.Add(CustomerType.TrungThanh, "Khac hang TrungThanh la khach hang TrungThanh");
            CustomerTypeInfo.Add(CustomerType.TiemNang, "Khac hang TiemNang la khach hang TiemNang");
            CustomerTypeInfo.Add(CustomerType.CanQuanTam, "Khac hang CanQuanTam la khach hang CanQuanTam");
            CustomerTypeInfo.Add(CustomerType.KhachHangKhac, "Khac hang KhachHangKhac la khach hang KhachHangKhac");
        }

        public void CompanyInfo()
        {
            Console.WriteLine("Displaying Company Info ..................\n------------");
            Console.WriteLine("Company Name: {0}", Name);
            Console.WriteLine("Number of Customers: {0}, icluding:\n", Customers.Count);
            foreach (Customer customer in Customers)
            {
                KeyValuePair<CustomerType, string> info = CustomerTypeInfo.FirstOrDefault(o => o.Key == customer.ValCustomerType);
                customer.CustomerInfo();
                Console.WriteLine("---{0}---", info.Value);
                Console.WriteLine("------------------------------");
            }
            Console.WriteLine();
        }

        public Customer SearchCustomer<T>(T search)
        {
            Customer r = new Customer();
            if (typeof(T) == typeof(string))
            {
                r = Customers.FirstOrDefault(o => o.ValCustomerID == search.ToString());
                if (r != null) { return r; }
            }
            else if (typeof(T) == typeof(int))
            {
                if (Convert.ToInt32(search) < Customers.Count)
                {
                    return Customers[Convert.ToInt32(search)];
                }
            }
            Console.WriteLine("404 Not Found");
            return new Customer();
        }

        public void OnCompanyChanger(Company company)
        {
            if (CompanyAddOrRemoveEvent != null)
            {
                CompanyAddOrRemoveEvent(this);
            }
        }
        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
            OnCompanyChanger(this);
            Console.WriteLine("{0} has been added", customer.ValCustomerID);
        }
        public void RemoveCustomer(Customer customer)
        {
            Customers.Remove(customer);
            OnCompanyChanger(this);
            Console.WriteLine("{0} has been removed", customer.ValCustomerID);
        }

        public string ValName
        {
            get { return Name; }
            set { Name = value; }
        }
        public int ValNumberOfCustomers
        {
            get { return NumberOfCustomers; }
            set { NumberOfCustomers = value; }
        }
    }
    public static class MyExtensions
    {
        public static string ConvertToString(this Customer customer)
        {
            string CustomerTypeString = Enum.GetName(typeof(CustomerType), customer.ValCustomerType);

            if (customer.ValCustomerID != "Not assigned")
            {
                string detail = "";
                detail += String.Format("Displaying Customer Info ...............\n");
                detail += String.Format("Customer ID: {0}\n", customer.ValCustomerID);
                detail += String.Format("Customer Address: {0}\n", customer.ValCustomerAddress);
                detail += String.Format("Customer Phone: {0}\n", customer.ValCustomerPhone);
                detail += String.Format("Customer Type: {0}\n", CustomerTypeString);
                return detail;
            }
            else return "";
        }
    }
}