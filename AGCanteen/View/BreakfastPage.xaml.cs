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
using System.Windows.Navigation;
using System.Windows.Shapes;
using AGCanteen.ViewModel;
using AGCanteen.Controller;

namespace AGCanteen.View
{
    /// <summary>
    /// Interaction logic for BreakfastPage.xaml
    /// </summary>
    public partial class BreakfastPage : UserControl
    {
        private BreakfastPageViewModel bfViewModel;

        public BreakfastPage()
        {
            InitializeComponent();
            

            this.bfViewModel = new BreakfastPageViewModel();
            this.DataContext = this.bfViewModel;
           

        }
    }
}
