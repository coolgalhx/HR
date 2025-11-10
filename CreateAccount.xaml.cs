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
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        public CreateAccount()
        {
            InitializeComponent();
            LoadUsers();
        }

        private List<User> users;

        private void LoadUsers()
        { 
            //opens the db context and binds the data to the data grid
            using (var db = new MainDatabaseContext())
            {
                users = db.User.ToList();
                datagridcreateaccount.ItemsSource = users;
            }
        }

        private void btnEnable_Click(object sender, RoutedEventArgs e)
        { 
            using (var db = new MainDatabaseContext())
            {
                db.Database.EnsureCreated();

                var user = new User
                {
                    
                    Username = txtusernameAEpg.Text,
                    Password = txtpasswordAEpg.Text,
                    Role = txtrole.Text,
                    IsEnabled = true,
                };
                db.User.Add(user);
                db.SaveChanges();
                LoadUsers();

                MessageBox.Show("!");
            }
        }

      
        

       
    }
}

