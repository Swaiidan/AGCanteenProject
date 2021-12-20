using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AGCanteen.Model;
using AGCanteen.ViewModel;

namespace AGCanteen.Controller
{
    public class EmployeeController
    {

        public class CRUDBreakFastItems
        {


            //READ all breakfastitems

            List<BreakfastItem> BreakfastItemList = new List<BreakfastItem>();
            public List<BreakfastItem> AllBreakfastItems()
            {


                using (var db = new Model.AGCanteenWebShopEntities())
                {

                    //finding breakfastItems in products 
                    var bfProduct = (from bf in db.Tbl_Product
                                 where bf.Fld_ProductCategoryID > 1
                                 select bf);



                    foreach (var item in bfProduct)
                    {

                        BreakfastItem bfItem = new BreakfastItem();
                        bfItem.Name = item.Fld_ProductName;
                        bfItem.Price = (decimal)item.Fld_ProductPrice;
                        bfItem.ID = (int)item.Fld_ProductID;


                        BreakfastItemList.Add(bfItem);
                    }

                }

                return BreakfastItemList;
            }


            public void AddBreakfastItem()
            {
                using (var db = new Model.AGCanteenWebShopEntities())
                {



                    try
                    {
                        var breakfastItem = new BreakfastItem()
                        {
                            Name = BreakfastItem.SelectedBFItem.Name,
                            Price = BreakfastItem.SelectedBFItem.Price,
                            //hardcoded Breakfast Category
                            CategoryID = 2
                        };
                        Tbl_Product bf = new Tbl_Product();
                        bf.Fld_ProductName = breakfastItem.Name;
                        bf.Fld_ProductPrice = breakfastItem.Price;
                        bf.Fld_ProductCategoryID = breakfastItem.CategoryID;
                        db.Tbl_Product.Add(bf);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.InnerException.Message);
                    }


                }
            }

            public void DeleteBreakfastItem()
            {
                using (var db = new Model.AGCanteenWebShopEntities())
                {



                    try
                    {


                        var bfItem = (from bf in db.Tbl_Product
                                      where bf.Fld_ProductID == BreakfastItem.SelectedBFItem.ID
                                      select bf).SingleOrDefault();

                        db.Tbl_Product.Remove(bfItem);
                        db.SaveChanges();



                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e.InnerException.Message);
                    }


                }
            }


            public void UpdateBreakfastItem()
            {
                using (var db = new Model.AGCanteenWebShopEntities())
                {

                    try
                    {
                        var breakfastItem = new BreakfastItem()
                        {
                            ID = BreakfastItem.SelectedBFItem.ID,
                            Name = BreakfastItem.SelectedBFItem.Name,
                            Price = BreakfastItem.SelectedBFItem.Price,
                            
                        };

                        var bfItem = (from bf in db.Tbl_Product
                                      where bf.Fld_ProductID == breakfastItem.ID
                                      select bf).SingleOrDefault();

                        bfItem.Fld_ProductName = breakfastItem.Name;
                        bfItem.Fld_ProductPrice = breakfastItem.Price;
                        db.SaveChanges();


                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e.InnerException.Message);
                    }


                }
            }

        }

        public class CRUDFruit
        {
            List<Fruit> FruitList = new List<Fruit>();
            public List<Fruit> AllFruits()
            {


                using (var db = new Model.AGCanteenWebShopEntities())
                {

                    //finding fruits in products 
                    var bfProduct = from bf in db.Tbl_Product
                                     where bf.Fld_ProductCategoryID == 1
                                     select bf;

                    foreach (var fruit in bfProduct)
                    {
                        Fruit fr = new Fruit();
                        fr.Name = fruit.Fld_ProductName;
                        fr.Price = (decimal)fruit.Fld_ProductPrice;
                        fr.ID = (int)fruit.Fld_ProductID;

                        FruitList.Add(fr);
                    }

                }

                return FruitList;
            }

            public void DeleteBreakfastItem()
            {
                using (var db = new Model.AGCanteenWebShopEntities())
                {



                    try
                    {


                        var fruit = (from fr in db.Tbl_Product
                                     where fr.Fld_ProductID == Fruit.SelectedFruit.ID
                                     select fr).SingleOrDefault();

                        db.Tbl_Product.Remove(fruit);
                        db.SaveChanges();



                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e.InnerException.Message);
                    }
                }
            }

            public void AddFruit()
            {
                using (var db = new Model.AGCanteenWebShopEntities())
                {
                    try
                    {
                        var fr = new Fruit()
                        {
                            Name = Fruit.SelectedFruit.Name,
                            Price = Fruit.SelectedFruit.Price,
                            CategoryID = 1
                            
                        };
                        Tbl_Product f = new Tbl_Product();
                        f.Fld_ProductName = fr.Name;
                        f.Fld_ProductPrice = fr.Price;
                        f.Fld_ProductCategoryID = fr.CategoryID;
                        db.Tbl_Product.Add(f);
                        db.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.InnerException.Message);
                    }


                }
            }

            public void UpdateFruit()
            {
                using (var db = new Model.AGCanteenWebShopEntities())
                {

                    try
                    {
                        var fr = new Fruit()
                        {
                            ID = Fruit.SelectedFruit.ID,
                            Name = Fruit.SelectedFruit.Name,
                            Price = Fruit.SelectedFruit.Price,
                        };

                        var fruitItem = (from f in db.Tbl_Product
                                      where f.Fld_ProductID == fr.ID
                                      select f).SingleOrDefault();

                        fruitItem.Fld_ProductName = fr.Name;
                        fruitItem.Fld_ProductPrice = fr.Price;
                        db.SaveChanges();


                    }

                    catch (Exception e)
                    {
                        Console.WriteLine(e.InnerException.Message);
                    }


                }
            }



        }

    }
}