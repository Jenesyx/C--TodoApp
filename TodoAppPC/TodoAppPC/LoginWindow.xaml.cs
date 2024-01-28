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
using TodoAppPC.Contorller;

namespace TodoAppPC
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        IO_controller ioc = new IO_controller();
        public LoginWindow()
        {
            InitializeComponent();
            ioc = new IO_controller();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            var user = ioc.Mv.GetUserByUsername(username);

            if (user != null)
            {
                bool isAdmin = user.Admin == 1;
                ProjectsWindow projectsWindow = new ProjectsWindow(user, isAdmin);
                projectsWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("User not found. Please check the username and try again.");
            }
        }

    }
}
