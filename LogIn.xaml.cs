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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();

        }


        //global variable
         public static object? VerifiedUser { get; internal set; }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {  
            //placeholders for the username and password
            string username = txtemployeeidLIpg.Text;
            string password = txtpassword.Password;

            using (var db = new MainDatabaseContext())
            {
                var employee = db.User.FirstOrDefault(e => e.EmployeeId.ToString() == username && e.Password == password);
                if (employee != null)
                {
                    if (!employee.IsEnabled)
                    {
                        MessageBox.Show("This account has been disabled");
                        return;
                    }

                    // global variable storage
                    VerifiedUser = employee;

                    MessageBox.Show($"Welcome, {employee.Role}!");

                    //convert to switch case
                    if(employee.Role== "HR Manager")
                    {
                        MainWindow mm = new MainWindow();
                        mm.Show();
                    }
                    if(employee.Role=="Admin")
                    {
                        MainWindow mm = new MainWindow();
                        mm.Show();
                    }
                    else 
                    {
                        MainWindow mm = new MainWindow();
                        mm.Show();
                    }



                        this.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect Credentials");
                }
            }
        }
        
       
    }
}
