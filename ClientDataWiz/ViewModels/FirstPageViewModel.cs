using System;

namespace ClientDataWiz.ViewModels
{
    public class FirstPageViewModel : ControlViewModel
    {
        public override string UserData { get; set; }

        protected override bool FieldValidation(int fieldType = 0)
        {
            throw new NotImplementedException();
        }
    }
}
