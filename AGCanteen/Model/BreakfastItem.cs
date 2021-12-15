using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGCanteen.ViewModel;
using AGCanteen.Controller;

namespace AGCanteen.Model
{
    public class BreakfastItem : Bindable
    {

        public static BreakfastItem SelectedBFItem { get; set; }

        private ObservableCollection<BreakfastItem> _ListOfBreakfastItems;
        public ObservableCollection<BreakfastItem> ListOfBreakfastItems { get { return _ListOfBreakfastItems; } set { _ListOfBreakfastItems = value; this.OnPropertyChanged(); } }

        public BreakfastItem()
        {
            ListOfBreakfastItems = new ObservableCollection<BreakfastItem>();
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        private int id;
        public int ID { get { return id; } set { id = value; this.OnPropertyChanged(); } }
        public string Category { get; set; }
        public int CategoryID { get; set; }

        public void LoadAllBreakfastItems()
        {
            ListOfBreakfastItems = new ObservableCollection<BreakfastItem>();

            //Adding Breakfastitems TO BreakfastItemList

            EmployeeController.CRUDBreakFastItems breakfast = new EmployeeController.CRUDBreakFastItems();

            List<BreakfastItem> BFItems = breakfast.AllBreakfastItems();

            foreach (var item in BFItems)
            {
                ListOfBreakfastItems.Add(item);
            }


        }


    }





}
