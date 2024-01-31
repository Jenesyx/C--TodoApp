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

namespace TodoAppPC
{
    /// <summary>
    /// Interaction logic for AddProjectDialog.xaml
    /// </summary>
    public partial class AddProjectDialog : Window
    {
        public string ProjectName
        {
            get { return projectNameTextBox.Text; }
            set { projectNameTextBox.Text = value; }
        }

        public string ProjectDescription
        {
            get { return projectDescriptionTextBox.Text; }
            set { projectDescriptionTextBox.Text = value; }
        }
        public AddProjectDialog()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(projectNameTextBox.Text) || string.IsNullOrWhiteSpace(projectDescriptionTextBox.Text))
            {
                MessageBox.Show("Please enter a name and a description for the project!");
                return;
            }

            ProjectName = projectNameTextBox.Text;
            ProjectDescription = projectDescriptionTextBox.Text;
            this.DialogResult = true; 
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
