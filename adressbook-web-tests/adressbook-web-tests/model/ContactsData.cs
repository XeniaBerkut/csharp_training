using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allInfo;

        public ContactData()
        {           
        }

        public ContactData(string allInfo)
        {
            AllInfo = allInfo;
        }

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
            MobilePhone = mobile;
            WorkPhone = work;
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
            return "Firstname=" + Firstname + ", Lastname=" + Lastname + ", AllInfo=" + AllInfo;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return (Firstname + Lastname).CompareTo(other.Firstname + other.Lastname);
        }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "middlename")]
        public string Middlename { get; set; }

        [Column(Name = "lastname")]
        public string Lastname { get; set; }

        [Column(Name = "nickname")]
        public string Nickname { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "address")]
        public string Address { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "email")]
        public string Email { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "phone2")]
        public string Phone2 { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "fax")]
        public string Fax { get; set; }

        [Column(Name = "address2")]
        public string Address2 { get; set; }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        [Column(Name = "homepage")]
        public string Homepage { get; set; }

        [Column(Name = "bday")]
        public string Bday { get; set; }

        [Column(Name = "bmonth")]
        public string Bmonth { get; set; }

        [Column(Name = "byear")]
        public string Byear { get; set; }

        [Column(Name = "aday")]
        public string Aday { get; set; }

        [Column(Name = "amonth")]
        public string Amonth { get; set; }

        [Column(Name = "ayear")]
        public string Ayear { get; set; }      


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
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(Phone2)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
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
        public string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            //return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
           return Regex.Replace(phone, "[ ()-]", "") + "\r\n";
        }

        
        public string AllInfo
        {
            get
            {
                if (allInfo != null)
                {
                    return allInfo;
                }
                else
                {
                    string info = null;
                    if (Firstname != ""){ info = Firstname + " "; }
                    if (Middlename != "") { info = info + Middlename + " "; }
                    if (Lastname != "") { info = info + Lastname; }
                    if (Nickname != "") { info = info + "\r\n" + Nickname; }
                    if (Title != "") { info = info + "\r\n" + Title; }
                    if (Company != "") { info = info + "\r\n" + Company; }
                    if (Address != "") { info = info + "\r\n" + Address; }
                    if ((HomePhone != "") || (MobilePhone != "") || (WorkPhone != "") || (Fax != ""))
                    {
                        info = info + "\r\n";
                        if (HomePhone != "") { info = info +  "\r\n" + "H: " + HomePhone; }
                        if (MobilePhone != "") { info = info + "\r\n" + "M: " + MobilePhone; }
                        if (WorkPhone != "") { info = info + "\r\n" + "W: " + WorkPhone; }
                        if (Fax != "") { info = info + "\r\n" + "F: " + Fax; }
                    }
                    if ((Email != "") || (Email2 != "") || (Email3 != "") || (Homepage != ""))
                    {
                        if (Email != "") { info = info + "\r\n" + "\r\n" + Email; }
                        if (Email2 != "") { info = info + "\r\n" + Email2; }
                        if (Email3 != "") { info = info + "\r\n" + Email3; }
                        if (Homepage != "") { info = info + "\r\n" + "Homepage:" + "\r\n" + Homepage; }
                    }
                    if ((Bday != "0") || (Bmonth != "-") || (Byear != ""))
                    {
                        info = info + "\r\n" + "\r\n" + "Birthday ";
                        if (Bday != "0") { info = info + Bday + "."; }
                        if (Bmonth != "-") { info = info + " " + Bmonth; }
                        if (Byear != "") { info = info + " " + Byear + " (18)"; }
                    }
                    if ((Aday != "0") || (Amonth != "-") || (Ayear != ""))
                    {
                        info = info + "\r\n" + "Anniversary ";
                        if (Aday != "0") { info = info + Aday + "."; }
                        if (Amonth != "-") { info = info + " " + Amonth; }
                        if (Ayear != "") { info = info + " " + Ayear + " (17)"; }
                    }
                    if (Address2 != "") { info = info + "\r\n" + "\r\n" + Address2; }
                    if (Phone2 != "") { info = info + "\r\n" + "\r\n" + "P: " + Phone2; }
                    if (Notes != "") { info = info + "\r\n" + "\r\n" +  Notes; }
                    return info;
                }
            }
            set
            {
                allInfo = value;
            }
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts select g).ToList();
            }
        }
    }
}
