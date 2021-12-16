using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AGCanteen.Model;
using AGCanteen.ViewModel.Commands;
using AGCanteen.View;
using System.Windows;
using AGCanteen.Controller;

namespace AGCanteen.ViewModel
{
    public class AddBreakfastItemViewModel : Bindable
    {

        public ICommand AddBfItem { get; set; }
        public ICommand CancelBFItem { get; set; }
        public Action CloseWindow { get; set; }

        public String BreakfastItemName { get; set; }
        public Decimal BreakfastItemPrice { get; set; }


        public AddBreakfastItemViewModel()
        {
            this.AddBfItem = new AddButtonAddBreakfastWindowCMD(AddBreakfastItem);
            this.CancelBFItem = new CancelBreakfastItemCMD(CancelBreakfastItem);
            

        }

        public void AddBreakfastItem(object p)
        {

            BreakfastItem BFItem = new BreakfastItem()
            {
                Name = BreakfastItemName,
                Price = BreakfastItemPrice
            };

            BreakfastItem.SelectedBFItem = BFItem;


            //adding a new BreakfastItem
            EmployeeController.CRUDBreakFastItems breakfast = new EmployeeController.CRUDBreakFastItems();
            
            breakfast.AddBreakfastItem();


            //updateing BreakfastItemlist in BreakfastPageViewmodel
            BreakfastPageViewModel.BFItem.LoadAllBreakfastItems();


            CloseFunction();
            
        }


        public void CancelBreakfastItem(object p)
        {
            CloseFunction();
        }

        public void CloseFunction()
        {
            CloseWindow();
        }

        



    }
}
