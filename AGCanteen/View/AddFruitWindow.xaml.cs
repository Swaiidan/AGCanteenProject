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
    /// Interaction logic for AddFruitWindow.xaml
    /// </summary>
    public partial class AddFruitWindow : Window
    {

        private AddFruitViewModel AddFruitModel;
        public AddFruitWindow()
        {
            InitializeComponent();

            this.AddFruitModel = new AddFruitViewModel();
            this.DataContext = this.AddFruitModel;

            //closes the window if the action is invoked
            this.AddFruitModel.CloseWindow = new Action(() => Close());

        }
    }
}
