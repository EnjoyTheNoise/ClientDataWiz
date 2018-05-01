using static ClientDataWiz.ViewModels.MainWindowViewModel;

namespace ClientDataWiz.ViewModels
{
    public class LastNameViewModel : ControlViewModel
    {
        public override string UserData
        {
            get => User.LastName;
            set
            {
                User.LastName = value;
                ControlValidation.LastName = ValidateAndUpdate();
            }
        }

        protected override bool FieldValidation(int fieldType = 0)
        {
            return ValidateLength(2,50, User.LastName, "Last name");
        }
    }
}
