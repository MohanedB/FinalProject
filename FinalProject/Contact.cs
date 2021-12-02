using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
  public class Contact
    {
        public int Id { set; get; }
        public string first_name { set; get; }
        public string last_name { set; get; }
        public string email { set; get; }
        public string phone_num { set; get; }


        public Contact(int id, string f, string l, string e, string p)
        {
            this.Id = id;
            this.first_name = f;
            this.last_name = l;
            this.email = e;
            this.phone_num = p;

        }

        public override string ToString()
        {
            string str;

            str = "Id: " + this.Id
                + "First Name: " + this.first_name
                + "Last Name: " + this.last_name
                + "Email: " + this.email
                + "Phone Number" + this.phone_num;


            return str;
        }
    }
}
