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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TodoApp.Controller;

namespace TodoApp
{
    /// <summary>
    /// Interaction logic for ProjektUebersicht.xaml
    /// </summary>
    public partial class ProjektUebersicht : Page
    {
        IO_controller ioc = new IO_controller();

        public ProjektUebersicht()
        {
            InitializeComponent();
            var Projekt = ioc.Pv.GetProjekte();
            UebersichtData.ItemsSource = Projekt;
        }
    }
}
