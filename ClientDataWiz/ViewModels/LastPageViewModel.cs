using static ClientDataWiz.ViewModels.MainWindowViewModel;

namespace ClientDataWiz.ViewModels
{
    public class LastPageViewModel : ControlViewModel
    {
        public string FirstName => User.FirstName;
        public string LastName => User.LastName;
        public string Street => User.Street;
        public string ZipCode => User.ZipCode;
        public string City => User.City;
        public string Phone => User.Phone;
        public override string UserData { get; set; }
        protected override bool FieldValidation(int fieldType = 0)
        {
            throw new System.NotImplementedException();
        }
    }
}
