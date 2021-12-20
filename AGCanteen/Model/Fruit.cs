using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AGCanteen.Controller;

namespace AGCanteen.Model
{
    public class Fruit : Bindable
    {
        public static Fruit SelectedFruit { get; set; }

        private ObservableCollection<Fruit> _ListOfFruit;
        public ObservableCollection<Fruit> ListOfFruit { get { return _ListOfFruit; } set { _ListOfFruit = value; this.OnPropertyChanged(); } }

        public Fruit()
        {
            ListOfFruit = new ObservableCollection<Fruit>();
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        private int id;
        public int ID { get { return id; } set { id = value; this.OnPropertyChanged(); } }

        public int CategoryID { get; set; }
        public void LoadFruitList()
        {
            ListOfFruit = new ObservableCollection<Fruit>();

            EmployeeController.CRUDFruit fruit = new EmployeeController.CRUDFruit();

            List<Fruit> FruitList = fruit.AllFruits();

            foreach (var item in FruitList)
            {
                ListOfFruit.Add(item);
            }


        }
    }




}
