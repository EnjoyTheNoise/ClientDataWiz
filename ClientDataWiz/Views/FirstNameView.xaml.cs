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
    /// Interaction logic for FirstNameView.xaml
    /// </summary>
    public partial class FirstNameView : UserControl
    {
        public FirstNameView()
        {
            InitializeComponent();
        }

        private void ControlLoaded(object sender, RoutedEventArgs e)
        {
            FirstName.Focus();
            FirstName.Focusable = true;
            Keyboard.Focus(FirstName);
            MainWindowViewModel.IsNextEnabled = MainWindowViewModel.ControlValidation.FirstName;
            MainWindowViewModel.IsPrevEnabled = true;
        }
    }
}
