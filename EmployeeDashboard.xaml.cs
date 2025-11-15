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
    /// Interaction logic for EmployeeDashboard.xaml
    /// </summary>
    public partial class EmployeeDashboard : Window
    {
        public EmployeeDashboard()
        {
            InitializeComponent();
        }


        private void txtgodash_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = txtgodash.Text.Trim();

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
                    return;
                }
                else
                {
                    MessageBox.Show($"Found {employeeFromDb.Count} ");
                }

                //populate txt boxes

            }
        }
    }
}