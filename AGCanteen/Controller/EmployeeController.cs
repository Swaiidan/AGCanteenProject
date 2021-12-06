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
        
          
        
        public class CRUD  // abstract + subclassing better!
        {
            //READ all breakfastitems
             
             
            List<BreakfastItem> BreakfastItemList = new List<BreakfastItem>();
            public List<BreakfastItem> AllBreakfastItems()
            {
                

                using (var db = new Model.DB_AGCanteenEntities())
                {

                    var query = from b in db.Tbl_Breakfast
                                orderby b.Fld_BreakfastName
                                select b;

                    foreach(var item in db.Tbl_Breakfast)
                    {
                        BreakfastItem bfItem = new BreakfastItem();
                        bfItem.Name = item.Fld_BreakfastName;
                        bfItem.Price = (decimal)item.Fld_BreakfastPrice;

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
                        Name = "test3",
                        Price = 100,
                    };
                        Tbl_Breakfast bf = new Tbl_Breakfast();
                        bf.Fld_BreakfastName = breakfastItem.Name;
                        bf.Fld_BreakfastPrice = breakfastItem.Price;
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

                    BreakfastPageViewModel bfViewModel = new BreakfastPageViewModel();

                    try
                    {
                        var bfItem = (from bf in db.Tbl_Breakfast
                                    where bf.Fld_BreakfastName == "test3"
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

            // # 3 UPDATE change email of a member

            // # 4 DELETE a member by email

            // # 5 INSERT a complete new member 


            

        }
    }
}