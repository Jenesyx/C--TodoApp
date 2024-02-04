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
                MessageBox.Show($"An error! while loading projects: {ex.Message}");
            }
        }

        private void BtnAddProject_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddProjectDialog();
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    var projectName = dialog.ProjectName;
                    var projectDescription = dialog.ProjectDescription;

                    ioc.Pv.CreateProject(projectName, projectDescription, _currentUser.MitarbeiterId);
                    LoadProjects(); 
                }
                catch (Exception ex)
                {
                    var errorMessage = $"An error occurred (Add): {ex.Message}";
                    if (ex.InnerException != null)
                    {
                        errorMessage += $" Inner exception: {ex.InnerException.Message}";
                    }
                    MessageBox.Show(errorMessage);
                }
            }
            else
            {
                MessageBox.Show("Bad error by Adding Project!");
            }
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var project = button.DataContext as Projekte;

            var dialog = new AddProjectDialog
            {
                ProjectName = project.Name,
                ProjectDescription = project.Beschreibung
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    project.Name = dialog.ProjectName;
                    project.Beschreibung = dialog.ProjectDescription;
                    ioc.Pv.UpdateProject(project);
                    LoadProjects();
                }
                catch (Exception ex)
                {
                    var errorMessage = $"An error occurred (Change): {ex.Message}";
                    if (ex.InnerException != null)
                    {
                        errorMessage += $" Inner exception: {ex.InnerException.Message}";
                    }
                    MessageBox.Show(errorMessage);
                }
            }
            else
            {
                MessageBox.Show("Bad error by Changing Project!");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var project = button.DataContext as Projekte;
            if (MessageBox.Show("Are you sure you want to delete this project?", "Confirm Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    ioc.Pv.DeleteProject(project.ProjektId);
                    LoadProjects();
                }
                catch (Exception ex)
                {
                    var errorMessage = $"An error occurred (Delete): {ex.Message}";
                    if (ex.InnerException != null)
                    {
                        errorMessage += $" Inner exception: {ex.InnerException.Message}";
                    }
                    MessageBox.Show(errorMessage);
                }
            }
            else
            {
                MessageBox.Show("Bad error by Deleting Project!");
            }
        }

        private void OpenTodos_Click(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement button && button.DataContext is Projekte selectedProject)
            {
                var todosWindow = new TodosWindow(_currentUser, _isAdmin, selectedProject);
                todosWindow.Show();
            }
            else
            {
                MessageBox.Show("Can not open Todos!");
            }
        }
    }
}
