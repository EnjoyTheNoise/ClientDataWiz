using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataWiz.ViewModels
{
    public abstract class ControlViewModel : BaseViewModel
    {
        public abstract string UserField { get; set; }
        public string ErrorDesc { get; set; }
        private bool _isValid;
        protected abstract bool FieldValid(int type = 0);

    }
}
