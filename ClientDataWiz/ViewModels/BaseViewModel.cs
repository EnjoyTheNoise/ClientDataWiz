using System.ComponentModel;

namespace ClientDataWiz.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public static event PropertyChangedEventHandler StaticPropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        protected void OnPropertyChanged(string propName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propName));
        }

        public static void OnStaticPropertyChanged(string propName)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propName));
        }
    }
}
