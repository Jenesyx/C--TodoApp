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
using TodoApp.Controller;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IO_controller ioc = new IO_controller();
        public MainWindow()
        {
            InitializeComponent();

            ioc = new IO_controller();

            var Namen = ioc.Mv.MitarbeiterName();
            ComboUser.ItemsSource = Namen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ComboUser.SelectedItem != null)
            {
                ProjektUebersicht newUebersicht = new ProjektUebersicht();
                newUebersicht.Show();
                var Projekte = ioc.Pv.GetProjekte();
                newUebersicht.UebersichtData.ItemsSource = ioc.Pv.GetProjekte();
                Close();
            }
            else
            {
                MessageBox.Show("Kein User ausgewählt!");
            }

        }
    }
}