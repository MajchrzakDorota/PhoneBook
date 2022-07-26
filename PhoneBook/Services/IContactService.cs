using PhoneBook.Models;

namespace PhoneBook.Services
{
    public interface IContactService
    {
        void DeleteContact(int id);
        int Create(CreateContactDto dto);
        IEnumerable<ContactDto> GetAll();
        ContactDto GetById(int id);
    }
}