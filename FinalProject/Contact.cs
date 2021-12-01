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
        public string f_name { set; get; }
        public string l_name { set; get; }
        public string email { set; get; }
        public string phone_number { set; get; }


        public Contact(int id, string f, string l, string e, string p)
        {
            this.Id = id;
            this.f_name = f;
            this.l_name = l;
            this.email = e;
            this.phone_number = p;

        }

        public override string ToString()
        {
            string str;

            str = "Id: " + this.Id
                + "First Name: " + this.f_name
                + "Last Name: " + this.l_name
                + "Email: " + this.email
                + "Phone Number" + this.phone_number;


            return str;
        }
    }
}
