using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AGCanteen.ViewModel;

namespace AGCanteen.View
{
    /// <summary>
    /// Interaction logic for AddBreakfastItem.xaml
    /// </summary>
    public partial class AddBreakfastItemWindow : Window
    {

        private AddBreakfastItemViewModel AddBfModel;
        public AddBreakfastItemWindow()
        {
            InitializeComponent();

            this.AddBfModel = new AddBreakfastItemViewModel();
            this.DataContext = this.AddBfModel;

            //closes the window if the action is invoked
            this.AddBfModel.CloseWindow = new Action(() => Close());

        }
    }
}
