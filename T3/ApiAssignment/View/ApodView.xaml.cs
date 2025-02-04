using ApiAssignment.ViewModel;
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

namespace ApiAssignment.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ApodView : UserControl
    {
        public ApodView()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var ApodViewModel = new ApodViewModel();
            DataContext = ApodViewModel;
        }
    }
}
