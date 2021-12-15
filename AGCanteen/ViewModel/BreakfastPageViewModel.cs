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
using AGCanteen.View;

namespace AGCanteen.ViewModel
{
    public class BreakfastPageViewModel : Bindable
    {

        public ICommand AddBFItem { get; set; }
        public ICommand DeleteBFItem { get; set; }
        public ICommand UpdateSelectedItem { get; set; }

        public static BreakfastItem BFItem { get; set; }
        public String BreakfastName { get; set; }
        public Decimal BreakfastPrice { get; set; }

        public BreakfastItem CurrentlySelectedName { get { return BreakfastItem.SelectedBFItem; } set { BreakfastItem.SelectedBFItem = value; OnPropertyChanged(); } }


        public BreakfastPageViewModel()
        {
            this.AddBFItem = new AddBreakfastItemCMD(AddBreakfastItem);
            this.DeleteBFItem = new DeleteBreakfastItemCMD(DeleteBreakfastItem);
            this.UpdateSelectedItem = new UpdateCMD(UpdateItem);
            BFItem = new BreakfastItem();
            BFItem.LoadAllBreakfastItems();

        }


        public void AddBreakfastItem(object p)
        {
            

            AddBreakfastItemWindow AddBFWindow = new AddBreakfastItemWindow();
            AddBFWindow.Show();



        }

        public void DeleteBreakfastItem(object p)
        {

            EmployeeController.CRUDBreakFastItems breakfast = new EmployeeController.CRUDBreakFastItems();

            if(BreakfastItem.SelectedBFItem == null)
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
            UpdateListOfBreakfastItems();

        }

        public void UpdateListOfBreakfastItems()
        {
            BFItem.LoadAllBreakfastItems();
        }

        public void UpdateItem(object p)
        {
            EmployeeController.CRUDBreakFastItems breakfast = new EmployeeController.CRUDBreakFastItems();

            
            
                BreakfastItem BreakfastItem = new BreakfastItem()
                {
                    ID = BreakfastItem.SelectedBFItem.ID,
                    Name = BreakfastName,
                    Price = BreakfastPrice
                };

                BreakfastItem.SelectedBFItem = BreakfastItem;

            

            breakfast.UpdateBreakfastItem();

            UpdateListOfBreakfastItems();


        }


    }
}
