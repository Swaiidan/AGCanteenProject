using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGCanteen.Model;
using AGCanteen.Controller;
using AGCanteen.ViewModel.Commands;
using System.Windows.Input;

namespace AGCanteen.ViewModel
{
    public class BreakfastPageViewModel : Bindable
    {

        BreakfastItem breakfastItem = new BreakfastItem() { Name = "Cake", Price = 10 };

        public ObservableCollection<BreakfastItem> ListOfBreakfastItems { get; set; } = new ObservableCollection<BreakfastItem>();


        public ICommand AddBFItem { get; set; }

        public BreakfastPageViewModel()
        {
            this.AddBFItem = new AddBreakfastItem(AddBreakfastItem);
            this.LoadAllBreakfastItems();

        }

        public void LoadAllBreakfastItems()
        {
            EmployeeController.CRUD breakfast = new EmployeeController.CRUD();

                      List<BreakfastItem> BFItems = breakfast.AllBreakfastItems();

                      foreach(var item in BFItems)
                    {
                      ListOfBreakfastItems.Add(item);
                }


        }


        public void AddBreakfastItem(object p)
        {

        }



    }
}
