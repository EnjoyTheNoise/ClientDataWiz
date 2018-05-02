using System.Windows;
using System.Windows.Controls;
using ClientDataWiz.ViewModels;

namespace ClientDataWiz.Views
{
    /// <summary>
    /// Interaction logic for FirstPageView.xaml
    /// </summary>
    public partial class FirstPageView : UserControl
    {
        public FirstPageView()
        {
            InitializeComponent();
        }

        private void ControlLoaded(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel.IsPrevEnabled = false;
            MainWindowViewModel.IsNextEnabled = true;
        }
    }
}
