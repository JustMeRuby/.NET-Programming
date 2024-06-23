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
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
using System.Data.SqlClient;

namespace SmartphoneManagement
{
    public partial class FrmPhoneManagement : System.Windows.Forms.Form
    {
        public List<SmartPhone> SPList = new List<SmartPhone>();
        // loadData = 0 (chưa có dữ liệu)
        // loadData = 1 (chưa có dữ liệu từ excel)
        // loadData = 2 (chưa có dữ liệu từ sql)
        public int loadData = 0;
        static string ProjectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        string ExcelFilaPath = ProjectPath + "\\Data\\SmartPhoneList.xlsx";
        //string connectionString = "Data Source = ; Initial Catalog = SmartPhoneID; Intergrated Security = SSPI";
        int CurrentPhoneIndex = -1;
        DataTable datatable;
        BindingSource binding = new BindingSource();
        
        public int ReadDataFromFile(List<SmartPhone> DataList, string FilePath, int colCount)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(FilePath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            xlWorksheet.Columns.ClearFormats();
            xlWorksheet.Rows.ClearFormats();

            int rowCount = xlWorksheet.UsedRange.Rows.Count;

            int numPhone = 0;
            string SmartPhoneID = "";
            string SmartPhoneName = "";
            string SmartPhoneType = "";
            DateTime AnnouncedDate = DateTime.Now;
            string Platform = "";
            string Camera = "";
            string RAM = "";
            string Battery = "";
            int Price = 0;
            string Avatar = "";

            for (int i = 2; i <= colCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    switch (j)
                    {
                        case 1:
                            SmartPhoneID = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 2:
                            SmartPhoneName = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 3:
                            SmartPhoneType = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 4:
                            AnnouncedDate = DateTime.ParseExact(xlRange.Cells[i, j].Value2.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                            break;
                        case 5:
                            Platform = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 6:
                            Camera = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 7:
                            RAM = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 8:
                            Battery = xlRange.Cells[i, j].Value2.ToString();
                            break;
                        case 9:
                            Price = Convert.ToInt32(xlRange.Cells[i, j].Value2.ToString());
                            break;
                        case 10:
                            SmartPhoneID = xlRange.Cells[i, j].Value2.ToString();
                            break;
                    }
                }
                DataList.Add(new SmartPhone());
                DataList[numPhone].SmartPhoneID = SmartPhoneID;
                DataList[numPhone].SmartPhoneName = SmartPhoneName;
                DataList[numPhone].SmartPhoneType = SmartPhoneType;
                DataList[numPhone].AnnouncedDate = AnnouncedDate;
                DataList[numPhone].Platform = Platform;
                DataList[numPhone].Camera = Camera;
                DataList[numPhone].RAM = RAM;
                DataList[numPhone].Battery = Battery;
                DataList[numPhone].Price = Price;
                DataList[numPhone].Avatar = Avatar;
                numPhone = numPhone + 1;
            }
            xlApp.Quit();

            MessageBox.Show("Load Data From Excel Finished! : " + (rowCount - 1).ToString() + " Records");

            return (rowCount - 1); // Không tính dòng tiêu đề
        }

        public FrmPhoneManagement()
        {
            InitializeComponent();

            var sublist = SPList.Select(x => new
                                        {
                                            SmartPhoneID = x.SmartPhoneID,
                                            SmartPhoneName = x.SmartPhoneName,
                                            SmartPhoneType = x.SmartPhoneType,
                                            AnnouncedDate = x.AnnouncedDate.ToString("dd/MM/yyyy"),
                                            Platform = x.Platform,
                                            Camera = x.Camera,
                                            RAM = x.RAM,
                                            Battery = x.Battery,
                                            Price = x.Price.ToString() + "USD",
                                        }).ToList();

            datatable.Columns.Add("SmartPhoneID");
            datatable.Columns.Add("SmartPhoneName");
            datatable.Columns.Add("SmartPhoneType");
            datatable.Columns.Add("AnnouncedDate");
            datatable.Columns.Add("Platform");
            datatable.Columns.Add("Camera");
            datatable.Columns.Add("RAM");
            datatable.Columns.Add("Battery");
            datatable.Columns.Add("Price");
            

            DataRow newrow;
            foreach (var bi in sublist)
            {
                newrow = datatable.NewRow();
                newrow["SmartPhoneID"] = bi.SmartPhoneID;
                newrow["SmartPhoneName"] = bi.SmartPhoneName;
                newrow["SmartPhoneType"] = bi.SmartPhoneType;
                newrow["AnnouncedDate"] = bi.AnnouncedDate;
                newrow["Platform"] = bi.Platform;
                newrow["Camera"] = bi.Camera;
                newrow["RAM"] = bi.RAM;
                newrow["Battery"] = bi.Battery;
                newrow["Price"] = bi.Price;
                datatable.Rows.Add(newrow);
                datatable.AcceptChanges();
            }

            binding.AllowNew = true;
            binding.DataSource = datatable;
            dgwPhoneList.AutoGenerateColumns = false;
            dgwPhoneList.DataSource = binding;
        }

        private void dgwPhoneList_SelectionChanged(object sender, EventArgs e)
        {
            CurrentPhoneIndex = dgwPhoneList.CurrentRow.Index;
            if (CurrentPhoneIndex >= 0 && CurrentPhoneIndex < SPList.Count)
                picPhoneImage.Image = Image.FromFile(ProjectPath + "\\Data\\" + SPList[CurrentPhoneIndex].Avatar);
        }

        private void btnLoadExcel_Click(object sender, EventArgs e)
        {
            loadData = 1;
            datatable = new DataTable();
            SPList.Clear();

            int colCount = 10;
            int NumDataRow = ReadDataFromFile(SPList, ExcelFilaPath, colCount);

            var sublist = SPList.Select(x => new
                                        {
                                            SmartPhoneID = x.SmartPhoneID,
                                            SmartPhoneName = x.SmartPhoneName,
                                            SmartPhoneType = x.SmartPhoneType,
                                            AnnouncedDate = x.AnnouncedDate.ToString("dd/MM/yyyy"),
                                            Platform = x.Platform,
                                            Camera = x.Camera,
                                            RAM = x.RAM,
                                            Battery = x.Battery,
                                            Price = x.Price.ToString() + "USD",
                                        }).ToList();

            binding.AllowNew = true;
            binding.DataSource = datatable;
            dgwPhoneList.AutoGenerateColumns = false;
            dgwPhoneList.DataSource = binding;
        }
    }
}
