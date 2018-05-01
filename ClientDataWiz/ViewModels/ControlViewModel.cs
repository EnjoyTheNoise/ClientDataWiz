using System.Text.RegularExpressions;
using System.Windows;
using static ClientDataWiz.ViewModels.MainWindowViewModel;

namespace ClientDataWiz.ViewModels
{
    public abstract class ControlViewModel : BaseViewModel
    {
        public abstract string UserData { get; set; }
        public string ErrorDesc { get; set; }
        private bool _isValid;
        protected abstract bool FieldValidation(int type = 0);
        public Visibility IsValid => _isValid ? Visibility.Collapsed : Visibility.Visible;

        public virtual bool ValidateAndUpdate(string property = "UserData", int type = 0)
        {
            _isValid = FieldValidation(type);

            IsNextEnabled = _isValid;

            OnPropertyChanged(property);
            return _isValid;
        }

        public virtual void ShowErrorOnChange(string desc)
        {
            ErrorDesc = desc;
            OnPropertyChanged("ErrorDesc");
            OnPropertyChanged("ShowError");
        }

        public virtual bool ValidateLength(int min, int max, string field, string fieldName)
        {
            bool isLengthValid = true;

            if (field == string.Empty)
            {
                ShowErrorOnChange(fieldName + " is empty!");
                isLengthValid = false;
            }
            else if (field.Length >= max && field.Length <= min)
            {
                ShowErrorOnChange(fieldName + "length is wrong! (between " + min + "-" + max + " characters)");
                isLengthValid = false;
            }
            else
            {
                ShowErrorOnChange("");
            }

            return isLengthValid;
        }

        public virtual bool ValidateRegexPattern(Regex pattern, string field, string errorDesc)
        {
            bool isPatternValid = true;

            if (field == null)
            {
                ShowErrorOnChange("Field cannot be empty!");
                isPatternValid = false;
            }
            else if (pattern.IsMatch(field))
            {
                ShowErrorOnChange("");
            }
            else
            {
                ShowErrorOnChange(errorDesc);
                isPatternValid = false;
            }

            return isPatternValid;
        }
    }
}
