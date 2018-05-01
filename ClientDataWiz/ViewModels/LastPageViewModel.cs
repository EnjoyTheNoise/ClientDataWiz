using static ClientDataWiz.ViewModels.MainWindowViewModel;

namespace ClientDataWiz.ViewModels
{
    public class LastPageViewModel : ControlViewModel
    {
        public string FirstName => User.FirstName;
        public string LastName => User.LastName;
        public string AddressStreet => User.Street;
        public string AddressPostCode => User.ZipCode;
        public string AddressCity => User.City;
        public string PhoneNumber => User.Phone;
        public override string UserData { get; set; }
        protected override bool FieldValidation(int fieldType = 0)
        {
            throw new System.NotImplementedException();
        }
    }
}
