using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class DataContact : IEquatable<DataContact>, IComparable<DataContact>
    {
        private string firstname;
        private string middlename = "";
        private string lastname;
        private string nickname = "";
        private string title = "";
        private string company = "";
       // private string address = "";

     
        public DataContact(string firstname, string lastName)
        {
            this.firstname = firstname;
            this.lastname = lastName;
        }

        public bool Equals(DataContact other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return this.CompareTo(other) == 0;
        }
        public override int GetHashCode()
        {

            return Firstname.GetHashCode() + Lastname.GetHashCode();

        }
        public override string ToString()
        {
            return "Firstname = " + Firstname + " " + Lastname;
        }
        public int CompareTo(DataContact other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
                return Firstname.CompareTo(other.Firstname);

            return Lastname.CompareTo(other.Lastname);
        }
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }

        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }
        /* public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            } 
        } */
    }
}
