using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public DateTime? CreatedDate { get; set; }

        public Group Group { get; set; }
        public int GroupId { get; set; }

    }
}
