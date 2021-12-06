using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGCanteen.Controller
{
    /*
    class CustomerController
    {
        // Assignment in class - 5 different assignments one group pr. assignment- send the solution code to tha@easv.dk
        public class CRUD  // abstract + subclassing better!
        {
            // # 1 READ all names emails telephones (+ membership type)

            public void ReadAll()
            {
                // DEMO CODE - DELETE THIS!!
                using (var db = new Models.MemberDBEntities1())
                {
                    CRUD c = new CRUD();


                    // Display all members from the database
                    var query = from b in db.Member
                                orderby b.member_name
                                select b;

                    Console.WriteLine("all names in the database:");
                    foreach (var item in query)
                    {

                        Console.WriteLine("Name: " + item.member_name + " phonenumber: " + item.phone + " Email: " + item.email + " member type: " + item.membership_type);
                    }

                }
            }

            // # 2 READ find a member by name

            public void UpdateEmail(int memberID, String email)
            {
                using (var db = new Models.MemberDBEntities1())
                {
                    //a find member in context LINQ

                    List<Member> myMembers = (from b in db.Member orderby b.member_name select b).ToList;
                    Member member = myMembers.Find(m => m.email.Equals(""));

                    //Change the email in the object


                    //SAVE THE CONTEXT
                }
            }

            // # 3 UPDATE change email of a member

            // # 4 DELETE a member by email

            // # 5 INSERT a complete new member 


            static void Main(string[] args)
            {
                /*
                // DEMO CODE - DELETE THIS!!
                using (var db = new Models.MemberDBEntities1())
                {

                    // Display all members from the database
                    var query = from b in db.Member
                                orderby b.member_name
                                select b;

                    Console.WriteLine("all names in the database:");
                    foreach (var item in query)
                    {

                        Console.WriteLine("Name: " + item.member_name + " phonenumber: " + item.phone + " Email: " + item.email + " member type: " + item.membership_type);
                    }

               */

              //  Console.Read();


            }

     //   }
  //  }
//}