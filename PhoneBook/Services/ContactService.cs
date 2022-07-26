using AutoMapper;
using PhoneBook.Entities;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services
{
    public class ContactService : IContactService
    {
        private readonly PhoneBookContext _phoneBookContext;
        private readonly IMapper _mapper;

        public ContactService(PhoneBookContext phoneBookContext, IMapper mapper)
        {
            _phoneBookContext = phoneBookContext;
            _mapper = mapper;
        }

        public IEnumerable<ContactDto> GetAll()
        {
            var contacts = _phoneBookContext.Contacts.ToList();

            var contactsDtos = _mapper.Map<List<ContactDto>>(contacts);

            return contactsDtos;
        }

        public ContactDto GetById(int id)
        {
            var contact = _phoneBookContext.Contacts.FirstOrDefault(c => c.Id == id);

            if (contact is null)
            {
                return null;
            }

            var contactDto = _mapper.Map<ContactDto>(contact);

            return contactDto;
        }

        public int Create(CreateContactDto dto)
        {
            var contact = _mapper.Map<Contact>(dto);
            _phoneBookContext.Contacts.Add(contact);
            _phoneBookContext.SaveChanges();

            return contact.Id;
        }

        public void DeleteContact(int id)
        {
            var contact = _phoneBookContext.Contacts.FirstOrDefault(c => c.Id == id);

            if(contact is null)
            {
                throw new Exception("Contact doesn't exist!");
            }
            _phoneBookContext.Contacts.Remove(contact);
            _phoneBookContext.SaveChanges();
        }
    }
}
