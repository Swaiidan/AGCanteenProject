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
using System.Windows;

namespace AGCanteen.ViewModel
{
    public class BreakfastPageViewModel : Bindable
    {


        public ObservableCollection<BreakfastItem> ListOfBreakfastItems { get; set; } = new ObservableCollection<BreakfastItem>();

        public BreakfastItem SelectedBFItem { get; set; }


        public ICommand AddBFItem { get; set; }
        public ICommand DeleteBFItem { get; set; }

        public BreakfastPageViewModel()
        {
            this.AddBFItem = new AddBreakfastItemCMD(AddBreakfastItem);
            this.DeleteBFItem = new DeleteBreakfastItemCMD(DeleteBreakfastItem);
            this.LoadAllBreakfastItems();

        }

        public void LoadAllBreakfastItems()
        {
            //clear BreakfastItemLIst
            ListOfBreakfastItems.Clear();

            //Adding Breakfeastitems TO BreakfastItemList

            EmployeeController.CRUDBreakFastItems breakfast = new EmployeeController.CRUDBreakFastItems();

            List<BreakfastItem> BFItems = breakfast.AllBreakfastItems();

                      foreach(var item in BFItems)
                    {
                      ListOfBreakfastItems.Add(item);
                }


        }
        public void AddBreakfastItem(object p)
        {
            EmployeeController.CRUDBreakFastItems breakfast = new EmployeeController.CRUDBreakFastItems();

            //adding a new BreakfastItem
            breakfast.AddBreakfastItem();

            //updates List with BreakfastItems
            this.LoadAllBreakfastItems();
        }

        public void DeleteBreakfastItem(object p)
        {

            EmployeeController.CRUDBreakFastItems breakfast = new EmployeeController.CRUDBreakFastItems();

            if(SelectedBFItem == null)
            {
                MessageBox.Show("Please Select an Item");
            }
            else
            {
                
                if (MessageBox.Show("Are you sure you want to delete this item?", "Messeage", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                    //delete bfitem from database
                    breakfast.DeleteBreakfastItem(); }
            }

            //updates List with BreakfastItems
            this.LoadAllBreakfastItems();

        }


    }
}
