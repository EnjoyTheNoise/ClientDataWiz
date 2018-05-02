using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ClientDataWiz.ViewModels;

namespace ClientDataWiz.Views
{
    /// <summary>
    /// Interaction logic for PhoneView.xaml
    /// </summary>
    public partial class PhoneView : UserControl
    {
        public PhoneView()
        {
            InitializeComponent();
        }

        private void ControlLoaded(object sender, RoutedEventArgs e)
        {
            PhoneNumber.Focus();
            PhoneNumber.Focusable = true;
            Keyboard.Focus(PhoneNumber);

            MainWindowViewModel.IsNextEnabled = MainWindowViewModel.ControlValidation.Phone;
            MainWindowViewModel.IsLastPage = true;
        }
    }
}
