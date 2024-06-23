using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Runtime.InteropServices;
using MainData;
using AttributeData;

delegate int BookReadWrite(string filename);

namespace LibraryManagement
{
    class Program
    {

        [DllImport("User32.dll")]
        public static extern int MessageBox(int hParent, string Message, string Caption, int Type);

        static void Main(string[] args)
        {
            Book book = new Book("The Butthole", "That LMAO Chad", "11/11/2011", 500);

            //Console.WriteLine("Book Information:");
            //Console.WriteLine("\tTitle: {0}", book.ValTitle);
            //Console.WriteLine("\tAuthor: {0}", book.ValAuthor);
            //Console.WriteLine("\tPublished Date: {0}", book.ValPublishedDate);
            //Console.WriteLine("\tPrice: {0}", book.ValPrice);

            //string OutputMessage;
            //OutputMessage = String.Format("\nTitle: {0}", book.ValTitle);
            //OutputMessage += String.Format("\nAuthor: {0}", book.ValAuthor);
            //OutputMessage += String.Format("\nPublished Date: {0}", book.ValPublishedDate);
            //OutputMessage += String.Format("\nPrice: {0}", book.ValPrice);
            //MessageBox(0, OutputMessage, "Book Information:", 1);

            //Type type = typeof(Book);
            //string OutputMessage = "Book Modification Information:";
            //foreach(Object attributes in type.GetCustomAttributes(false))
            //{
            //    CodingInfo info = (CodingInfo)attributes;
            //    if (info != null)
            //    {
            //        OutputMessage += String.Format("\n\tDevoloper: {0}", info.DevoloperName);
            //        OutputMessage += String.Format("\n\tCreated Date: {0}", info.CreatedDate);
            //        OutputMessage += String.Format("\n\tModified Date: {0}", info.ModifiedDate);
            //        OutputMessage += String.Format("\n\tComment: {0}", info.Comment);
            //        Console.WriteLine(OutputMessage);
            //    }
            //}

            //// "BookData.txt" has to be in LibraryManageMent/bin/debug, if not, you have to put the right location in
            //int numline = book.ReadBookFromFile("BookData.txt");
            //if (numline > 0)
            //{
            //    Console.WriteLine("Book Information:");
            //    Console.WriteLine("\tTitle: {0}", book.ValTitle);
            //    Console.WriteLine("\tAuthor: {0}", book.ValAuthor);
            //    Console.WriteLine("\tPublished Date: {0}", book.ValPublishedDate);
            //    Console.WriteLine("\tPrice: {0}", book.ValPrice);
            //    Console.WriteLine("Read successfully");
            //}
            //book.ValPrice = 1000;
            //book.WriteBookToFile("BookData.txt");
            //Console.WriteLine("Write successfully");

            //BookReadWrite ReadAction = new BookReadWrite(book.ReadBookFromFile);
            //BookReadWrite WriteAction = new BookReadWrite(book.WriteBookToFile);
            //int numline = ReadAction.Invoke("BookData.txt");
            //if (numline > 0)
            //{
            //    Console.WriteLine("Book Information:");
            //    Console.WriteLine("\tTitle: {0}", book.ValTitle);
            //    Console.WriteLine("\tAuthor: {0}", book.ValAuthor);
            //    Console.WriteLine("\tPublished Date: {0}", book.ValPublishedDate);
            //    Console.WriteLine("\tPrice: {0}", book.ValPrice);
            //    Console.WriteLine("Read successfully");
            //}
            //book.ValPrice = 999999;
            //WriteAction.Invoke("BookData.txt");
            //Console.WriteLine("Write succesfully");

            Console.ReadKey();
        }
    }
}

namespace MainData
{
    interface IBookAction
    {
        int ReadBookFromFile(string filename);
        int WriteBookToFile(string filename);
    }

    [CodingInfo("Mr A", "12/11/2021", "12/11/2021", "Created class Book")]
    class Book : IBookAction
    {
        private string Title;
        private string Author;
        private DateTime PublishedDate;
        private float Price;

        public Book(string Title = "Not assigned", string Author = "Not assigned",
                    string PublishedDate = "01/01/1900", float Price = 0)
        {
            this.Title = Title;
            this.Author = Author;
            this.PublishedDate = DateTime.ParseExact(PublishedDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.Price = Price;
        }

        public string ValTitle
        {
            get { return Title; }
            set { Title = value; }
        }
        public string ValAuthor
        {
            get { return Author; }
            set { Author = value; }
        }
        public string ValPublishedDate
        {
            get { return PublishedDate.ToString("dd/MM/yyyy"); }
            set { PublishedDate = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture); }
        }
        public float ValPrice
        {
            get { return Price; }
            set { Price = value; }
        }

        public int ReadBookFromFile(string filename)
        {
            int counter = 0;
            string line;

            // Read the file and display it line-by-line
            System.IO.StreamReader file = new System.IO.StreamReader(filename);
            while((line = file.ReadLine()) != null)
            {
                string[] terms = line.Split(':');
                if (line.Contains("Title:")) ValTitle = terms[1].Trim();
                if (line.Contains("Author:")) ValAuthor = terms[1].Trim();
                if (line.Contains("Published Date:")) ValPublishedDate = terms[1].Trim();
                if (line.Contains("Price:")) ValPrice = float.Parse(terms[1].Trim());
                counter++;
            }
            file.Close();
            return counter;
        }
        public int WriteBookToFile(string filename)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(filename);

            string OutputMessage;
            OutputMessage = String.Format("Title: {0}", ValTitle);
            file.WriteLine(OutputMessage);
            OutputMessage = String.Format("Author: {0}", ValAuthor);
            file.WriteLine(OutputMessage);
            OutputMessage = String.Format("Published Date: {0}", ValPublishedDate);
            file.WriteLine(OutputMessage);
            OutputMessage = String.Format("Price: {0}", ValPrice);
            file.WriteLine(OutputMessage);

            file.Close();
            return -1;
        }
    }
}

namespace AttributeData
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    class CodingInfo : System.Attribute
    {
        public string DevoloperName { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedDate { get; set; }
        public string Comment { get; set; }

        public CodingInfo(string DevoloperName = "", string CreatedDate = "", string ModifiedDate = "", string Comment = "")
        {
            this.DevoloperName = DevoloperName;
            this.CreatedDate = CreatedDate;
            this.ModifiedDate = ModifiedDate;
            this.Comment = Comment;
        }
    }
}