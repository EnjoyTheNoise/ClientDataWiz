using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
