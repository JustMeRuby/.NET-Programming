using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainData1;
using MainData2;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int nDog = 3;
            int nCat = 2;

            Dog Inu;
            Cat Neko;

            object[] PetList = new object[nDog + nCat];
            for(int i = 0; i < nDog; i++)
            {
                Inu = new Dog();
                Inu.InputInfo();
                PetList[i] = Inu;
            }
            for(int i = 0; i < nCat; i++)
            {
                Neko = new Cat();
                Neko.InputInfo();
                PetList[i + nDog] = Neko;
            }
            for(int i = 0; i < nDog + nCat; i++)
            {
                if (PetList[i].GetType() == typeof(Dog))
                {
                    Console.WriteLine("'Dog {0}' info: ", i + 1);
                    Inu = (Dog)PetList[i];
                    Inu.DisplayInfo();
                }
                else
                {
                    Console.WriteLine("'Cat {0}' info: ", i + 1 - nDog);
                    Neko = (Cat)PetList[i];
                    Neko.DisplayInfo();
                }
            }
            */
            Sport sport = new Sport();
            sport.InputDisplayList();
        }
    }
}

namespace MainData1
{
    class Dog
    {
        private string Name;
        private int Age;
        private float Weight;
        private float Height;
        public Dog(string name = "Not assigned", int age = 0, float weight = 0, float height = 0)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Height = height;
        }
        public void DisplayInfo()
        {
            Console.WriteLine("Name = {0}, Age = {1}, Height = {2}, Weight = {3}\n", Name, Age, Height, Weight);
        }
        public void InputInfo()
        {
            Console.WriteLine("Input Dog's Name: ");
            Name = Console.ReadLine();
            InputAge();
            InputHeight();
            InputWeight();
            Console.WriteLine("---------------------");
        }
        public void InputAge()
        {
            Console.WriteLine("Input Dog's Age: ");
            string AgeString = Console.ReadLine();
            try
            {
                Age = int.Parse(AgeString);
                if (Age < 0 || Age > 20)
                {
                    throw new NegativeOrOver20AgeException();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Input Age is not a number! Please input again.");
                InputAge();
            }
            catch (NegativeOrOver20AgeException)
            {
                Console.WriteLine("Input Age is negative or over 20! Please input again.");
                InputAge();
            }
        }
        public void InputHeight()
        {
            Console.WriteLine("Input Dog's Height: ");
            string HeightString = Console.ReadLine();
            try
            {
                Height = float.Parse(HeightString);
                if (Height < 0)
                {
                    throw new NegativeNumException();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Input Height is not a number! Please input again.");
                InputHeight();
            }
            catch (NegativeNumException)
            {
                Console.WriteLine("Input Height is negative! Please input again.");
                InputHeight();
            }
        }
        public void InputWeight()
        {
            Console.WriteLine("Input Dog's Weight: ");
            string WeightString = Console.ReadLine();
            try
            {
                Weight = float.Parse(WeightString);
                if (Weight < 0)
                {
                    throw new NegativeNumException();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Input Weight is not a number! Please input again.");
                InputWeight();
            }
            catch (NegativeNumException)
            {
                Console.WriteLine("Input Weight is negative! Please input again.");
                InputWeight();
            }
        }
    }
    class Cat
    {
        private string Name;
        private int Age;
        private float Weight;
        private float Height;
        public Cat(string name = "Not assigned", int age = 0, float weight = 0, float height = 0)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Height = height;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Name = {0}, Age = {1}, Height = {2}, Weight = {3}\n", Name, Age, Height, Weight);
        }
        public void InputInfo()
        {
            Console.WriteLine("Input Cat's Name: ");
            Name = Console.ReadLine();
            InputAge();
            InputHeight();
            InputWeight();
            Console.WriteLine("---------------------");
        }
        public void InputAge()
        {
            Console.WriteLine("Input Cat's Age: ");
            string AgeString = Console.ReadLine();
            try
            {
                Age = int.Parse(AgeString);
                if (Age < 0 || Age > 20)
                {
                    throw new NegativeOrOver20AgeException();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Input Age is not a number! Please input again.");
                InputAge();
            }
            catch (NegativeOrOver20AgeException)
            {
                Console.WriteLine("Input Age is negative or over 20! Please input again.");
                InputAge();
            }
        }
        public void InputHeight()
        {
            Console.WriteLine("Input Cat's Height: ");
            string HeightString = Console.ReadLine();
            try
            {
                Height = float.Parse(HeightString);
                if (Height < 0)
                {
                    throw new NegativeNumException();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Input Height is not a number! Please input again.");
                InputHeight();
            }
            catch (NegativeNumException)
            {
                Console.WriteLine("Input Height is negative! Please input again.");
                InputHeight();
            }
        }
        public void InputWeight()
        {
            Console.WriteLine("Input Cat's Weight: ");
            string WeightString = Console.ReadLine();
            try
            {
                Weight = float.Parse(WeightString);
                if (Weight < 0)
                {
                    throw new NegativeNumException();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Input Weight is not a number! Please input again.");
                InputWeight();
            }
            catch (NegativeNumException)
            {
                Console.WriteLine("Input Weight is negative! Please input again.");
                InputWeight();
            }
        }
    }
    class NegativeOrOver20AgeException : Exception
    {
        public NegativeOrOver20AgeException() { }
        public NegativeOrOver20AgeException(string message) : base(message) { }
    }
    class NegativeNumException : Exception
    {
        public NegativeNumException() { }
        public NegativeNumException(string message) : base(message) { }
    }
}

namespace MainData2
{
    class Sport
    {
        protected int StartingYear;
        public void setStartingYear(int n)
        {
            StartingYear = n;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine("Info about Sport: ..........");
            Console.WriteLine("--------------------------------------------");
        }
        public void InputDisplayList()
        {
            Console.WriteLine("Input List: ..........\n");
            Caller c = new Caller();
            Football football = new Football();
            Tennis tennis = new Tennis();
            Volleyball volleyball = new Volleyball();
            c.CallDisplayInfo(football);
            c.CallDisplayInfo(tennis);
            c.CallDisplayInfo(volleyball);
        }
    }
    class Football : Sport
    {
        private int Quantity;
        private int Playtime;
        private string BallType;

        public Football() { InputInfo(); }

        public void InputInfo()
        {
            Console.WriteLine("Input Football Info: .........");

            Console.WriteLine("Input Quantity (the amount of players needed in a match): ");
            string QuantityString = Console.ReadLine();
            Quantity = int.Parse(QuantityString);

            Console.WriteLine("Input Playtime (minute): ");
            string PlaytimeString = Console.ReadLine();
            Playtime = int.Parse(PlaytimeString);

            Console.WriteLine("Input Ball Type: ");
            BallType = Console.ReadLine();

            Console.WriteLine("Input Starting Year: ");
            string StartingYearString = Console.ReadLine();
            StartingYear = int.Parse(StartingYearString);

            Console.WriteLine("--------------------------------------------");
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("Football Info: .........");
            Console.WriteLine("The amount of players in a match: {0}", Quantity);
            Console.WriteLine("Playtime of a match: {0} minutes", Playtime);
            Console.WriteLine("Ball used: {0}", BallType);
            Console.WriteLine("Starting Year: {0}", StartingYear);
            Console.WriteLine("--------------------------------------------");
        }
    }
    class Tennis : Sport
    {
        private int Quantity;
        private int Playtime;
        private string BallType;

        public Tennis() { InputInfo(); }

        public void InputInfo()
        {
            Console.WriteLine("Input Tennis Info: .........");

            Console.WriteLine("Input Quantity (the amount of players needed in a match): ");
            string QuantityString = Console.ReadLine();
            Quantity = int.Parse(QuantityString);

            Console.WriteLine("Input Playtime (minute): ");
            string PlaytimeString = Console.ReadLine();
            Playtime = int.Parse(PlaytimeString);

            Console.WriteLine("Input Ball Type: ");
            BallType = Console.ReadLine();

            Console.WriteLine("Input Starting Year: ");
            string StartingYearString = Console.ReadLine();
            StartingYear = int.Parse(StartingYearString);

            Console.WriteLine("--------------------------------------------");
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("Tennis Info: .........");
            Console.WriteLine("The amount of players in a match: {0}", Quantity);
            Console.WriteLine("Playtime of a match: {0} minutes", Playtime);
            Console.WriteLine("Ball used: {0}", BallType);
            Console.WriteLine("Starting Year: {0}", StartingYear);
            Console.WriteLine("--------------------------------------------");
        }
    }
    class Volleyball : Sport
    {
        private int Quantity;
        private int Playtime;
        private string BallType;

        public Volleyball() { InputInfo(); }

        public void InputInfo()
        {
            Console.WriteLine("Input Volleyball Info: .........");

            Console.WriteLine("Input Quantity (the amount of players needed in a match): ");
            string QuantityString = Console.ReadLine();
            Quantity = int.Parse(QuantityString);

            Console.WriteLine("Input Playtime (minute): ");
            string PlaytimeString = Console.ReadLine();
            Playtime = int.Parse(PlaytimeString);

            Console.WriteLine("Input Ball Type: ");
            BallType = Console.ReadLine();

            Console.WriteLine("Input Starting Year: ");
            string StartingYearString = Console.ReadLine();
            StartingYear = int.Parse(StartingYearString);

            Console.WriteLine("--------------------------------------------");
        }
        public override void DisplayInfo()
        {
            Console.WriteLine("Volleyball Info: .........");
            Console.WriteLine("The amount of players in a match: {0}", Quantity);
            Console.WriteLine("Playtime of a match: {0} minutes", Playtime);
            Console.WriteLine("Ball used: {0}", BallType);
            Console.WriteLine("Starting Year: {0}", StartingYear);
            Console.WriteLine("--------------------------------------------");
        }
    }
    class Caller
    {
        public void CallDisplayInfo(Sport sport)
        {
            sport.DisplayInfo();
        }
    }
}