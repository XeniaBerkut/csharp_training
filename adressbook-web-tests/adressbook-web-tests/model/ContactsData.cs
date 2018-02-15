using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        
        public ContactData(string firstname, string middlename, string lastname)
        {
            Firstname = firstname;
            Middlename = middlename;
            Lastname = lastname;
        }

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public ContactData(string firstname, string middlename, string lastname, string nickname, string company, string address, string mobile, string work, string email)
        {
            Firstname = firstname;
            Middlename = middlename;
            Lastname = lastname;
            Nickname = nickname;
            Company = company;
            Address = address;
            Mobile = mobile;
            Work = work;
            Email = email;
        }

        public bool Equals(ContactData other)
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
            //return 0;
            return (Firstname+Lastname).GetHashCode();
        }

        public override string ToString()
        {
            return "Firstname=" + Firstname + ", Lastname=" + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return (Firstname + Lastname).CompareTo(other.Firstname + other.Lastname);
        }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Nickname { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Mobile { get; set; }

        public string Work { get; set; }

        public string Email { get; set; }

        public string Id { get; set; }
    }
}
