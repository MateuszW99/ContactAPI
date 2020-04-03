using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactAPI.Models;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using ContactAPI.Queries;
using ContactAPI.Commands;

namespace ContactAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediatR;

        public ContactsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        public async Task<ActionResult> GetContacts()
        {
            var query = new GetAllContactsQuery();
            var result = await _mediatR.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var query = new GetContactByIdQuery(id);
            var result = await _mediatR.Send(query);
            return result == null ? NotFound() : (IActionResult) Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact([FromBody]CreateContactCommand command)
        {
            var result = await _mediatR.Send(command);
            return CreatedAtAction("GetContact", new { id = command.Contact.ID }, result.Contact);
        }
    }
}
