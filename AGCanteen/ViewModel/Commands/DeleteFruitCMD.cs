using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AGCanteen.ViewModel.Commands
{
    class DeleteFruitCMD : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<Object> MyAddDelegate { get; set; }

        public DeleteFruitCMD(Action<Object> MyAddDelegate)
        {
            this.MyAddDelegate = MyAddDelegate;

        }

        public bool CanExecute(object parameter)
        {
            return true;//hardcoded true
        }

        public void Execute(object parameter)
        {

            this.MyAddDelegate?.Invoke(parameter);
        }
    }
}
