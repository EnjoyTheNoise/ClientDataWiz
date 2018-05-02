using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ClientDataWiz.ViewModels;

namespace ClientDataWiz.Views
{
    /// <summary>
    /// Interaction logic for LastNameView.xaml
    /// </summary>
    public partial class LastNameView : UserControl
    {
        public LastNameView()
        {
            InitializeComponent();
        }

        private void ControlLoaded(object sender, RoutedEventArgs e)
        {
            LastName.Focus();
            LastName.Focusable = true;
            Keyboard.Focus(LastName);
            MainWindowViewModel.IsNextEnabled = MainWindowViewModel.ControlValidation.LastName;
        }
    }
}
