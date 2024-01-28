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
using TodoAppPC.Models;

namespace TodoAppPC
{
    /// <summary>
    /// Interaction logic for TodosWindow.xaml
    /// </summary>
    public partial class TodosWindow : Window
    {
        private readonly Projekte _selectedProject;
        private readonly bool _isAdmin;
        private readonly Mitarbeiter _currentUser;

        public TodosWindow(Mitarbeiter currentUser, bool isAdmin, Projekte selectedProject)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _isAdmin = isAdmin;
            _selectedProject = selectedProject;

            btnAddTodo.Visibility = _isAdmin || _selectedProject.MitarbeiterId == _currentUser.MitarbeiterId
                ? Visibility.Visible
                : Visibility.Collapsed;

            LoadTodos();
        }

        private void LoadTodos()
        {
            // Fetch and display the list of todos for the selected project
        }

        private void BtnAddTodo_Click(object sender, RoutedEventArgs e)
        {
            // Open dialog to add new todo
        }
    }
}
