using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Entities;
using PhoneBook.Models;
using PhoneBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Controllers
{
    [Route("contacts")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContactDto>> GetAll()
        {
            var contactsDtos = _contactService.GetAll();

            return Ok(contactsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<ContactDto> GetContactById([FromRoute] int id)
        {
            var contact = _contactService.GetById(id);

            if(contact is null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpPost]
        public ActionResult CreateContact([FromBody] CreateContactDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _contactService.Create(dto);

            return Created($"/contacts/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _contactService.DeleteContact(id);

            return NoContent();
        }
    }
}
