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
    /// Interaction logic for AddTodoDialog.xaml
    /// </summary>
    public partial class AddTodoDialog : Window
    {
        public string TodoName
        {
            get { return nameTextBox.Text; }
            set { nameTextBox.Text = value; }
        }

        public string TodoDescription
        {
            get { return descriptionTextBox.Text; }
            set { descriptionTextBox.Text = value; }
        }
        public AddTodoDialog()
        {
            InitializeComponent();
        }
        public int TodoStatus
        {
            get { return (statusComboBox.SelectedItem as ComboBoxItem) != null ? Convert.ToInt32((statusComboBox.SelectedItem as ComboBoxItem).Tag) : 0; }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Basic validation can be added here
            this.DialogResult = true;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text == "Enter name here...")
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Enter name here...";
                textBox.Foreground = Brushes.Gray;
            }
        }

    }
}
