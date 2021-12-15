﻿using System;
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

                
                using (var db = new Model.DB_AGCanteenEntities())
                {


                    
                    foreach (var item in db.Tbl_Breakfast)
                    {
                        BreakfastItem bfItem = new BreakfastItem();
                        bfItem.Name = item.Fld_BreakfastName;
                        bfItem.Price = (decimal)item.Fld_BreakfastPrice;
                        bfItem.ID = (int)item.Fld_BrealfastID;

                        //finding category
                        var bfCat = (from cat in db.Tbl_BreakfastCategory
                                      where cat.Fld_CategoryID == 1
                                      select cat).SingleOrDefault();

                        bfItem.Category = bfCat.Fld_CategoryName;


                        BreakfastItemList.Add(bfItem);
                    }

                }

                return BreakfastItemList;
            }




            // Adding Breakfastitem

            public void AddBreakfastItem()
            {
                using (var db = new Model.DB_AGCanteenEntities())
                {

                    

                    try
                    {
                        var breakfastItem = new BreakfastItem()
                        {
                            Name = BreakfastItem.SelectedBFItem.Name,
                            Price = BreakfastItem.SelectedBFItem.Price,
                            CategoryID = 1
                        };
                        Tbl_Breakfast bf = new Tbl_Breakfast();
                        bf.Fld_BreakfastName = breakfastItem.Name;
                        bf.Fld_BreakfastPrice = breakfastItem.Price;
                        bf.Fld_CategoryID = breakfastItem.CategoryID;
                        db.Tbl_Breakfast.Add(bf);
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
                using (var db = new Model.DB_AGCanteenEntities())
                {



                    try
                    {
                        

                        var bfItem = (from bf in db.Tbl_Breakfast
                                      where bf.Fld_BrealfastID == BreakfastItem.SelectedBFItem.ID
                                      select bf).SingleOrDefault();

                        db.Tbl_Breakfast.Remove(bfItem);
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
                using (var db = new Model.DB_AGCanteenEntities())
                {

                    try
                    {
                        var breakfastItem = new BreakfastItem()
                        {
                            ID = BreakfastItem.SelectedBFItem.ID,
                            Name = BreakfastItem.SelectedBFItem.Name,
                            Price = BreakfastItem.SelectedBFItem.Price,
                            CategoryID = 1
                        };

                        var bfItem = (from bf in db.Tbl_Breakfast
                                      where bf.Fld_BrealfastID == breakfastItem.ID
                                      select bf).SingleOrDefault();

                        bfItem.Fld_BreakfastName = breakfastItem.Name;
                        bfItem.Fld_BreakfastPrice = breakfastItem.Price;
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
