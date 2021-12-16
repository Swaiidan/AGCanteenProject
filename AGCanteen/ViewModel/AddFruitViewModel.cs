using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AGCanteen.Model;
using AGCanteen.Controller;
using AGCanteen.ViewModel;
using AGCanteen.ViewModel.Commands;

namespace AGCanteen.ViewModel
{
    public class AddFruitViewModel : Bindable
    {

        public ICommand AddFruit { get; set; }
        public ICommand CancelFruitItem { get; set; }
        public Action CloseWindow { get; set; }
        public String FruitName { get; set; }
        public Decimal FruitPrice { get; set; }


        public AddFruitViewModel()
        {
            this.AddFruit = new AddButtonAddFruitWindowCMD(AddFruitItem);
            this.CancelFruitItem = new CancelFruitCMD(CancelFruit);


        }

        public void AddFruitItem(object p)
        {

            Fruit fruitItem = new Fruit()
            {
                Name = FruitName,
                Price = FruitPrice
            };

            Fruit.SelectedFruit = fruitItem;


            //adding a new BreakfastItem
            EmployeeController.CRUDFruit FruitItem = new EmployeeController.CRUDFruit();

            FruitItem.AddFruit();


            //updating fruitList in BreakfastPageViewmodel


            BreakfastPageViewModel.FruitItem.LoadFruitList();

            CloseFunction();

        }


        public void CancelFruit(object p)
        {
            CloseFunction();
        }

        public void CloseFunction()
        {
            CloseWindow();
        }
    }
}