using System.Text.RegularExpressions;
using static ClientDataWiz.ViewModels.MainWindowViewModel;

namespace ClientDataWiz.ViewModels
{
    public class AddressViewModel : ControlViewModel
    {
        private bool _isZipCodeValid;
        private bool _isCityValid;
        private bool _isAddressValid;

        public override string UserData
        {
            get => User.Street;
            set
            {
                User.Street = value;
                ControlValidation.Address = ValidateAndUpdate("UserStreet", 1);
            }
        }

        public string UserZipCode
        {
            get => User.ZipCode;
            set
            {
                User.ZipCode = value;
                ControlValidation.Address = ValidateAndUpdate("UserZipCode", 2);
            }
        }

        public string UserCity
        {
            get => User.City;
            set
            {
                User.City = value;
                ControlValidation.Address = ValidateAndUpdate("UserCity", 3);
            }
        }

        protected override bool FieldValidation(int field = 0)
        {
            if (field == 1)
            {
                _isAddressValid = ValidateAddress();
            }
            else if (field == 2)
            {
                _isZipCodeValid = ValidateZipCode();
            }
            else if (field == 3)
            {
                _isCityValid = ValidateCity();
            }

            return _isAddressValid && _isZipCodeValid && _isCityValid;
        }

        private bool ValidateCity()
        {
            return ValidateLength(2, 100, User.City, "City");
        }

        private bool ValidateZipCode()
        {
            var pattern = new Regex(@"^[0-9]{2}-[0-9]{3}$");
            return ValidateRegexPattern(pattern, User.ZipCode, "Invalid format, example: 78-650");
        }

        private bool ValidateAddress()
        {
            var pattern = new Regex(@"^[\p{L}]{2,} [0-9]{1,}\s?(\/\s?[0-9]{1,})?$");
            return ValidateRegexPattern(pattern, User.Street, "Invalid format, example: Górnickiego 22/34");
        }
    }
}
