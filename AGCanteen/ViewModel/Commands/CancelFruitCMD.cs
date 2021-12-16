using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AGCanteen.ViewModel.Commands
{
    class CancelFruitCMD : ICommand
    {

        public event EventHandler CanExecuteChanged;

        private Action<Object> MyCancelelegate { get; set; }

        public CancelFruitCMD(Action<Object> MyAddDelegate)
        {
            this.MyCancelelegate = MyAddDelegate;

        }

        public bool CanExecute(object parameter)
        {
            return true;//hardcoded true
        }

        public void Execute(object parameter)
        {

            this.MyCancelelegate?.Invoke(parameter);
        }
    }



}

