using OfficeOpenXml;
//using OfficeOpenXml.Export;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using static HR_Management_System.MainDBcontext;




namespace HR_Management_System
{
    /// <summary>
    /// Interaction logic for PayrollPage.xaml
    /// </summary>
    public partial class PayrollPage : Window
    {
        public ObservableCollection<PayrollManagement> Payroll { get; set; }
            = new ObservableCollection<PayrollManagement>();

        public PayrollPage()
        {
            InitializeComponent();
            DataContext = this;

            TransferAllEmployeesToPayroll();
            LoadPayrollData();
        }

        private void TransferAllEmployeesToPayroll()
        {
            using (var db = new MainDatabaseContext())
            {
                var employees = db.Employee.ToList();

                foreach (var employee in employees)
                {
                    db.Database.EnsureCreated();
                    //checks if current employee record has a corresponding record in the PayrollMangement
                    var existingPayroll = db.PayrollManagement
                        .FirstOrDefault(p => p.EmployeeId == employee.EmployeeId);
                    

                    //if null, the employee is not yet in the datagrid so it's added
                    if (existingPayroll == null)
                    {
                        var payroll = new PayrollManagement
                        {
                            EmployeeId = employee.EmployeeId,
                            FirstName = employee.FirstName,
                            LastName = employee.LastName,
                            Department= employee.Department,

                        };

                        db.PayrollManagement.Add(payroll);
                    }
                }

                db.SaveChanges();
            }
        }

        private void LoadPayrollData()
        {
            Payroll.Clear();
            using (var db = new MainDatabaseContext())
            {
                var payrolldata = db.PayrollManagement.ToList();
                foreach (var payroll in payrolldata)
                {
                    Payroll.Add(payroll);
                }
            }
        }


        private async void PayrollDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (datagridpayroll.SelectedItem is PayrollManagement payroll)
            {
                await ExportSinglePayrollToExcel(payroll);
            }
        }




        private async Task ExportSinglePayrollToExcel(PayrollManagement payroll)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var file = new FileInfo(fileName: @"C:\TEST\PayrollReport.xlsx");


            var people = new ObservableCollection<PayrollManagement> { payroll };

            await SaveExcelFile(people, file);


        }

        private static async Task SaveExcelFile(ObservableCollection<PayrollManagement> people, FileInfo file)
        {
            using var package = new ExcelPackage(file);
            var existingWorksheet = package.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == "MainReport");
            var ws = existingWorksheet ?? package.Workbook.Worksheets.Add(Name: "MainReport");

            if (existingWorksheet == null)
            {
                var range = ws.Cells[Address: "A1"].LoadFromCollection(people, PrintHeaders: true);
                range.AutoFitColumns();

                await package.SaveAsync();
            }
            //else
            //{
            //    //MessageBox.Show("An Excel sheet has already been downloaded of the latest PayrollReport");

            //}


        }

    }
}
