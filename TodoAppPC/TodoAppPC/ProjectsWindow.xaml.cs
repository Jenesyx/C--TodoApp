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
using TodoAppPC.Models;

namespace TodoAppPC
{
    /// <summary>
    /// Interaction logic for ProjectsWindow.xaml
    /// </summary>
    /// 
    public partial class ProjectsWindow : Window
    {
        private readonly bool _isAdmin;
        private readonly Mitarbeiter _currentUser;
        IO_controller ioc = new IO_controller();

        public ProjectsWindow(Mitarbeiter currentUser, bool isAdmin)
        {
            InitializeComponent();
            ioc = new IO_controller();
            _currentUser = currentUser;
            _isAdmin = isAdmin;
            LoadProjects();
        }

        private void LoadProjects()
        {
            try
            {
                var projects = ioc.Pv.GetProjekte();
                ProjectsList.ItemsSource = projects;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading projects: {ex.Message}");
            }
        }

        private void BtnAddProject_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddProjectDialog(); // Assuming you have a custom dialog for adding projects
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    var projectName = dialog.ProjectName; // Assume dialog returns project name
                    var projectDescription = dialog.ProjectDescription; // Assume dialog returns project description

                    ioc.Pv.CreateProject(projectName, projectDescription, _currentUser.MitarbeiterId);
                    LoadProjects(); // Refresh the list of projects
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that occur during project creation
                    MessageBox.Show($"An error occurred while adding the project: {ex.Message}");
                }
            }
        }
    }
}
