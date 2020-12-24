using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopContactsApp.Classes
{
    class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Contact(string _Name, string _Email, string _Phone)
        {
            Name = _Name;
            Email = _Email;
            Phone = _Phone;
        }
    }
}
