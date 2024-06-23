using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using MainData;
using AttributeData;

delegate void MilkInputOutput();

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            Milk milk = new Milk();

            MilkInputOutput MilkInput = new MilkInputOutput(milk.InputMilkInfo);
            MilkInputOutput MilkOutput = new MilkInputOutput(milk.OutputMilkInfo);
            MilkInput.Invoke();
            MilkOutput.Invoke();

            Type type = typeof(Milk);
            string OutputMessage = "Milk's Origin:";
            foreach (Object attributes in type.GetCustomAttributes(false))
            {
                MilkMoreInfo info = (MilkMoreInfo)attributes;
                if (info != null)
                {
                    OutputMessage += String.Format("\n\tManufacturer: {0}", info.Manufacturer);
                    OutputMessage += String.Format("\n\tCompany Name: {0}", info.CompanyName);
                    Console.WriteLine(OutputMessage);
                    Console.WriteLine("--------------------------------");
                }
            }

            Console.ReadKey();
        }
    }
}

namespace MainData
{
    interface InputOutput
    {
        void InputMilkInfo();
        void OutputMilkInfo();
    }

    [MilkMoreInfo("Riot Games", "Garena Fried Chicken")]
    class Milk : InputOutput
    {
        private string MilkName;
        private string MilkID;
        private DateTime ProductionDate;
        private DateTime ExpiredDate;
        private int Quantity;
        
        public Milk(string MilkName = "Not assigned", string ProductionDate = "01/01/1900",
                    string ExpiredDate = "01/01/1900", int Quantity = 0)
        {
            this.MilkName = MilkName;
            this.ProductionDate = DateTime.ParseExact(ProductionDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.MilkID = String.Format("MILK{0}", this.ProductionDate.ToString("ddMMyyyy"));
            this.ExpiredDate = DateTime.ParseExact(ExpiredDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.Quantity = Quantity;
        }

        public string ValMilkName
        {
            get { return MilkName; }
            set { MilkName = value; }
        }
        public string ValMilkID
        {
            get { return MilkID; }
        }
        public string ValProductionDate
        {
            get { return ProductionDate.ToString("dd/MM/yyyy"); }
            set
            {
                ProductionDate = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                MilkID = String.Format("MILK{0}", this.ProductionDate.ToString("ddMMyyyy"));
            }
        }
        public string ValExpiredDate
        {
            get { return ExpiredDate.ToString("dd/MM/yyyy"); }
            set { ExpiredDate = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture); }
        }
        public int ValQuantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }

        public void InputProductionDate()
        {
            Console.WriteLine("Input Production Date:");
            try
            {
                ValProductionDate = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Not a date! Please input again. (Example: 01/05/2021)");
                InputProductionDate();
            }
        }
        public void InputExpiredDate()
        {
            Console.WriteLine("Input Expired Date:");
            try
            {
                ValExpiredDate = Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.WriteLine("Not a date! Please input again. (Example: 01/05/2021)");
                InputExpiredDate();
            }
        }
        public void InputQuantity()
        {
            Console.WriteLine("Input Quantity:");
            try
            {
                ValQuantity = int.Parse(Console.ReadLine());
                if(Quantity <= 0)
                {
                    throw new WrongNumException();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Not a number! Please input again.");
                InputQuantity();
            }
            catch (WrongNumException)
            {
                Console.WriteLine("Unreasonable quantity (negative or 0)! Please input again.");
                InputQuantity();
            }
        }
        
        public void InputMilkInfo()
        {
            Console.WriteLine("Getting Milk Info ..............");
            Console.WriteLine("Input Milk Name:");
            ValMilkName = Console.ReadLine();
            InputProductionDate();     
            InputExpiredDate();
            InputQuantity();
            Console.WriteLine("--------------------------------");
        }
        public void OutputMilkInfo()
        {
            Console.WriteLine("Displaying Milk Info ..............");
            Console.WriteLine("Milk Name: {0}", ValMilkName);
            Console.WriteLine("Milk ID: {0}", ValMilkID);
            Console.WriteLine("Production Date: {0}", ValProductionDate);
            Console.WriteLine("Expired Date: {0}", ValExpiredDate);
            Console.WriteLine("Quantity: {0}", ValQuantity);
            Console.WriteLine("--------------------------------");
        }
    }
    class WrongNumException : Exception
    {
        public WrongNumException() { }
        public WrongNumException(string message) : base(message) { }
    }
}

namespace AttributeData
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    class MilkMoreInfo : System.Attribute
    {
        public string Manufacturer { get; set; }
        public string CompanyName { get; set; }

        public MilkMoreInfo(string Manufacturer = "", string CompanyName = "")
        {
            this.Manufacturer = Manufacturer;
            this.CompanyName = CompanyName;
        }
    }
}