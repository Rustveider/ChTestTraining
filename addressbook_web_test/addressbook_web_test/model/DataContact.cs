using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class DataContact : IEquatable<DataContact>, IComparable<DataContact>
    {
        public DataContact(string firstname)
        {
            Firstname = firstname;
        }

        public DataContact(string firstname, string lastName)
        {
            Firstname = firstname;
            Lastname = lastName;
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
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }
        public override int GetHashCode()
        {

            return Firstname.GetHashCode() + Lastname.GetHashCode();

        }
        public override string ToString()
        {
            return "Firstname = " + Firstname + "; lastname = " + Lastname;
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
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string IdContacts { get; set; }
    }
}
