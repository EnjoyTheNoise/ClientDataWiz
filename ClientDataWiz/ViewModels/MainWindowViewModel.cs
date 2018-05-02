using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using ClientDataWiz.Helpers;
using ClientDataWiz.Models;

namespace ClientDataWiz.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public static User User;
        public static ControlValidation ControlValidation;

        private ControlViewModel _currViewModel;
        public ObservableCollection<ControlViewModel> Controls;

        private static bool _isNextEnabled;
        private static bool _isPrevEnabled;
        private static bool _isCancelEnabled;
        private static bool _isLastPage;

        public ICommand Prev { get; }
        public ICommand Next { get; }
        public ICommand Cancel { get; }

        public string NextBtn { get; set; }

        public static bool IsNextEnabled
        {
            get => _isNextEnabled;
            set
            {
                _isNextEnabled = value;
                OnStaticPropertyChanged("Next");
            }
        }

        public static bool IsPrevEnabled
        {
            get => _isPrevEnabled;
            set
            {
                _isPrevEnabled = value;
                OnStaticPropertyChanged("Prev");
            }
        }

        public static bool IsCancelEnabled
        {
            get => _isCancelEnabled;
            set
            {
                _isCancelEnabled = value;
                OnStaticPropertyChanged("Cancel");
            }
        }

        public static bool IsLastPage
        {
            get => _isLastPage;
            set
            {
                _isLastPage = value;
                OnStaticPropertyChanged("Next");
            }
        }

        public ControlViewModel CurrViewModel
        {
            get => _currViewModel;
            set
            {
                _currViewModel = value;
                OnPropertyChanged("CurrViewModel");
            }
        }

        public bool IsNextCorrect(object state)
        {
            return IsNextEnabled;
        }

        public bool IsPrevCorrect(object state)
        {
            return IsPrevEnabled;
        }

        public bool IsCancelPossible(object state)
        {
            return IsCancelEnabled;
        }

        public MainWindowViewModel()
        {
            Controls = new ObservableCollection<ControlViewModel>
            {
                new FirstPageViewModel(),
                new FirstNameViewModel(),
                new LastNameViewModel(),
                new AddressViewModel(),
                new PhoneViewModel(),
                new LastPageViewModel()
            };

            Prev = new RelayCommand(obj => PrevControl(), IsPrevCorrect);
            Next = new RelayCommand(obj => NextControl(), IsNextCorrect);
            Cancel = new RelayCommand(obj => CancelApplication(), IsCancelPossible);

            CurrViewModel = Controls[0];
            IsPrevEnabled = IsNextEnabled = IsCancelEnabled = true;
            NextBtn = "Next";
        }

        private void NextControl()
        {
            if (IsLastPage && NextBtn == "Finish")
            {
                Application.Current.Shutdown();
            }
            else if (IsLastPage)
            {
                NextBtn = "Finish";
                OnPropertyChanged("NextBtn");
            }

            if (!IsPrevEnabled) IsPrevEnabled = true;
            CurrViewModel = NextElement(Controls, CurrViewModel);
        }

        private void PrevControl()
        {
            if (IsLastPage && NextBtn == "Finish")
            {
                IsCancelEnabled = true;
                NextBtn = "Next";
                OnPropertyChanged("NextBtn");
            }

            OnPropertyChanged("IsPrevEnabled");

            CurrViewModel = PrevElement(Controls, CurrViewModel);
        }

        private static void CancelApplication()
        {
            Application.Current.Shutdown();
        }

        public static ControlViewModel NextElement(ObservableCollection<ControlViewModel> list, ControlViewModel item)
        {
            if (User == null)
            {
                User = new User();
            }

            if (ControlValidation == null)
            {
                ControlValidation = new ControlValidation();
            }

            return list[list.IndexOf(item) + 1 == list.Count ? 0 : list.IndexOf(item) + 1];
        }

        public static ControlViewModel PrevElement(ObservableCollection<ControlViewModel> list, ControlViewModel item)
        {
            return list[list.IndexOf(item) - 1 == -1 ? 0 : list.IndexOf(item) - 1];
        }
    }
}
