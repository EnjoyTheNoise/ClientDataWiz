using System.Text.RegularExpressions;
using static ClientDataWiz.ViewModels.MainWindowViewModel;

namespace ClientDataWiz.ViewModels
{
    public class PhoneViewModel : ControlViewModel
    {
        public override string UserData
        {
            get => User.Phone;
            set
            {
                User.Phone = value;
                ControlValidation.Phone = ValidateAndUpdate();
            }
        }

        protected override bool FieldValidation(int type = 0)
        {
            var pattern = new Regex(@"^(?<!\w)(\(?(\+|00)?48\)?)?[ -]?\d{3}[ -]?\d{3}[ -]?\d{3}(?!\w)?");
            return ValidateRegexPattern(pattern, User.Phone, "Invalid phone number. Only numbers and '+' allowed");
        }
    }
}
