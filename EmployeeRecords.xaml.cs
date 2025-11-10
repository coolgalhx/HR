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
using static HR_Management_System.MainDBcontext;

namespace HR_Management_System
{
    /// <summary>
    /// Interaction logic for EmployeeRecords.xaml
    /// </summary>
    public partial class EmployeeRecords : Window
    {
        public EmployeeRecords()
        {
            InitializeComponent();
            LoadEmployees();
            //datagridloademployees.Items.Refresh();
        }
        public List<Employee> employees;

        public void LoadEmployees()
        {
            

            using (var db = new MainDatabaseContext())
            {
                employees = db.Employee.ToList();
                datagridloademployees.ItemsSource = employees;
                MessageBox.Show($"Loaded {employees.Count} employees from database.");
            }

        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new MainDatabaseContext())
            {
               // db.Database.EnsureCreated();

                var employee = new Employee
                {    
                    EmployeeId=Convert.ToInt32(txtemployeeidERpg.Text),
                    FirstName = txtfirstname.Text,
                    LastName = txtlastname.Text,
                    DateOfBirth = Convert.ToDateTime(txtdob.Text),
                    ContactInformation = txtcontactinformation.Text,
                    JobTitle = txtcontactinformation.Text,
                    Department = txtdepartment.Text,
                    EmploymentType = txtdepartment.Text,
                    Address= txtaddress.Text,
                    City = txtcity.Text,
                    NationalInsurance= txtdepartment.Text,

                };
                db.Employee.Add(employee);
                
                db.SaveChanges();
                LoadEmployees();

                MessageBox.Show("!");



            }

        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            string search = txtsearchbar.Text.Trim();

            if (string.IsNullOrWhiteSpace(search))
            {
                MessageBox.Show("Enter text to search");
                return;
            }
            using (var db = new MainDatabaseContext())
            {
                var employeeFromDb = db.Employee
                     //performs evaluation locally
                     .AsEnumerable()
                        .Where(a => a.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        a.LastName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                        a.EmployeeId.ToString().Contains(search))
                        .ToList();

                if (employeeFromDb.Count == 0)
                {
                    MessageBox.Show("No matching record found");
                    datagridloademployees.ItemsSource = null;
                    return;
                }
                else
                {
                    MessageBox.Show($"Found {employeeFromDb.Count} ");
                }


                datagridloademployees.ItemsSource = null;
                datagridloademployees.ItemsSource = employeeFromDb;
            }
        }  
    }
}
