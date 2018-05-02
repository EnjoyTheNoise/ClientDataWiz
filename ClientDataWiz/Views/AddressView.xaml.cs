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
