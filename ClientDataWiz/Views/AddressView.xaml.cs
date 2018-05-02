using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ClientDataWiz.ViewModels;

namespace ClientDataWiz.Views
{
    /// <summary>
    /// Interaction logic for AddressView.xaml
    /// </summary>
    public partial class AddressView : UserControl
    {
        public AddressView()
        {
            InitializeComponent();
        }

        private void ControlLoaded(object sender, RoutedEventArgs e)
        {
            Address.Focus();
            Address.Focusable = true;
            Keyboard.Focus(Address);

            MainWindowViewModel.IsNextEnabled = MainWindowViewModel.ControlValidation.Address;
            MainWindowViewModel.IsLastPage = false;
        }
    }
}
