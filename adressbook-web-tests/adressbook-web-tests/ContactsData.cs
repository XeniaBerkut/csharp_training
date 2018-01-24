using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactData
    {
        private string firstname;
        private string middlename;
        private string lastname;
        private string nickname = "";
        private string company = "";
        private string address = "";
        private string mobile = "";
        private string work = "";
        private string email = "";



        public ContactData(string firstname, string middlename, string lastname)
        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
        }

        public ContactData(string firstname, string middlename, string lastname, string nickname, string company, string address, string mobile, string work, string email)
        {
            this.firstname = firstname;
            this.middlename = middlename;
            this.lastname = lastname;
            this.nickname = nickname;
            this.company = company;
            this.address = address;
            this.mobile = mobile;
            this.work = work;
            this.email = email;
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

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }

        }

        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
            }

        }

        public string Work
        {
            get
            {
                return work;
            }
            set
            {
                work = value;
            }

        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }

        }
    }
}
