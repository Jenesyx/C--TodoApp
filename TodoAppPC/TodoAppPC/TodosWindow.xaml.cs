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
    /// Interaction logic for TodosWindow.xaml
    /// </summary>
    public partial class TodosWindow : Window
    {
        private readonly Projekte _selectedProject;
        private readonly bool _isAdmin;
        private readonly Mitarbeiter _currentUser;
        IO_controller ioc = new IO_controller();

        public TodosWindow(Mitarbeiter currentUser, bool isAdmin, Projekte selectedProject)
        {
            InitializeComponent();
            ioc = new IO_controller();
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
            var todos = ioc.Tv.GetTodosByProjectId(_selectedProject.ProjektId);
            TodosList.ItemsSource = todos;
        }

        private void BtnAddTodo_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddTodoDialog();
            if (dialog.ShowDialog() == true)
            {
                ioc.Tv.CreateTodo(dialog.TodoName, dialog.TodoDescription, dialog.TodoStatus, _selectedProject.ProjektId, _currentUser.MitarbeiterId);
                LoadTodos();
            }
            else
            {
                MessageBox.Show("Issue in TodoWindow add new Todo!");
            }
        }

        private void ChangeTodo_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var todo = button.DataContext as Todos;
            if (todo != null)
            {
                var dialog = new AddTodoDialog()
                {
                    TodoName = todo.Name,
                    TodoDescription = todo.Beschreibung
                };

                if (dialog.ShowDialog() == true)
                {
                    int status = todo.Status ?? 0;
                    ioc.Tv.UpdateTodo(todo.TodoId, dialog.TodoName, dialog.TodoDescription, status);
                    LoadTodos();
                }
            }
        }


        private void DeleteTodo_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var todo = button.DataContext as Todos;
            if (MessageBox.Show("Are you sure you want to delete this todo?", "Confirm Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    ioc.Tv.DeleteTodo(todo.TodoId);
                    LoadTodos();
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
                MessageBox.Show("Bad error by Deleting Todo!");
            }
        }


    }
}
