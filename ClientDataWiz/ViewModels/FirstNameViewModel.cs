using static ClientDataWiz.ViewModels.MainWindowViewModel;

namespace ClientDataWiz.ViewModels
{
    public class FirstNameViewModel : ControlViewModel
    {
        public override string UserData
        {
            get => User.FirstName;
            set
            {
                User.FirstName = value;
                ControlValidation.FirstName = ValidateAndUpdate();
            }
        }

        protected override bool FieldValidation(int type = 0)
        {
            return ValidateLength(2, 30, User.FirstName, "First name");
        }
    }
}
