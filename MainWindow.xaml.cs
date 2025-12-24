using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HR_Management_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void admin_dashboard_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount ca= new CreateAccount();
            ca.Show();
        }

        private void employee_dashboard_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDashboard employeeDashboard = new EmployeeDashboard();
            employeeDashboard.Show();
        }
    }
}