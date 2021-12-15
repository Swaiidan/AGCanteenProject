using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AGCanteen.ViewModel.Commands
{
    class UpdateCMD : ICommand
    {

        public event EventHandler CanExecuteChanged;

        private Action<Object> MyUpdateDelegate { get; set; }

        public UpdateCMD(Action<Object> MyUpdateDelegate)
        {
            this.MyUpdateDelegate = MyUpdateDelegate;

        }

        public bool CanExecute(object parameter)
        {
            return true;//hardcoded true
        }

        public void Execute(object parameter)
        {

            this.MyUpdateDelegate?.Invoke(parameter);
        }
    }



}