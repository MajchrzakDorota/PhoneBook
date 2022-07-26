using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
