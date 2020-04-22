using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class DataContact : IEquatable<DataContact>, IComparable<DataContact>
    {
        private string allPhones;
        private string allEmails;
        private string AllInformations;

        public DataContact(string firstname)
        {
            Firstname = firstname;
        }
        public DataContact()
        {
        }
        //public DataContact(string firstname, string lastName)
        //{
        //    Firstname = firstname;
        //    Lastname = lastName;
        //}

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
            return "Firstname = " + Firstname + "\nlastname = " + Lastname + "\nmiddlename = " + Middlename + "\nnickname = " + Nickname;
        }
        public int CompareTo(DataContact other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (this.Lastname == other.Lastname)
            {
                return this.Firstname.CompareTo(other.Lastname);
            }
            else
                return other.Lastname.CompareTo(this.Lastname);
        }
        //public int CompareTo(DataContact other)
        //{
        //    if (Object.ReferenceEquals(other, null))
        //    {
        //        return 1;
        //    }
        //    if (Lastname.CompareTo(other.Lastname) == 0)
        //        return Firstname.CompareTo(other.Firstname);

        //    return Lastname.CompareTo(other.Lastname);
        //}
        [Column(Name = "firstname")]
        public string Firstname { get; set; }
        [Column(Name = "middlename")]
        public string Middlename { get; set; }
        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }
        [Column(Name = "home")]
        public string HomePhone { get; set; }
        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }
        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }
        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string IdContacts { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ ()-]", "") + "\r\n";
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
        /* метод если нужно будет отдельно почистить email
         private string CleanUpEmail(string email)
         {
             if (email == null || email == "")
             {
                 return "";
             }
             return email + "\r\n";
         } */
        // метод для очистки данных от лишних скобок()-
        public string allInformations
        {
            get
            {
                return (CleanUp(AllInformations)).Trim();
            }
            set
            {
                AllInformations = value;
            }
        }

        public static List<DataContact> GetAllContact() 
        {
            using (AddresBookDB db = new AddresBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
    }
}
