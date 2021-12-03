using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGCanteen.Controller
{
    class EmployeeeController
    {
        public class CRUD  // abstract + subclassing better!
        {

            public void ReadAll()
            {
              
                }
            }

           
            static void Main(string[] args)
            {
            using (var db = new Model.DB_AGCanteenEntities())
            {


                // Display all members from the database
                var query = from p in db.tbl_Customer
                            orderby p.Fld_CustomerName
                            select p;

                Console.WriteLine("all names in the database:");





                foreach (var item in query)
                {

                    Console.WriteLine("Name: " + item.Fld_CustomerName + " phonenumber: " + item.Fld_Phonenumber + " Email: " + item.Fld_CustomerID);
                }

            }


                            Console.Read();


            }

        }
    }
