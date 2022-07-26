using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class CreateContactDto
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public int GroupId { get; set; }
    }
}
