using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.IO;
using ExcelDataReader;
using Microsoft.VisualBasic.FileIO;


namespace HR_Management_System
{
    /// <summary>
    /// Interaction logic for Timesheet.xaml
    /// </summary>
    public partial class Timesheet : Window
    {
        public Timesheet()
        {
            InitializeComponent();

            var load = new EmployeeRecords();
            load.LoadEmployees();
           // datagridduplicateofemployeerecords.ItemsSource = default;
            //DataTable employeetable = LoadEmployeeTimesheet("C:\\Users\\hp\\Downloads\\time-card-calculator.xlsx ");
            //datagridtimesheet.ItemsSource = employeetable.DefaultView;

        }
        
        //public DataTable LoadEmployeeTimesheet(string filePath)
        //{
            //System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            ////string filePath = "C:\\Users\\hp\\Downloads ";

            //using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            //{
            //    using (var reader = ExcelReaderFactory.CreateReader(stream))
            //    {

            //        var result = reader.AsDataSet();
            //        return result.Tables[0];   
            //    }
            //}

          //  LoadEmployees();
        //}
    }
}
