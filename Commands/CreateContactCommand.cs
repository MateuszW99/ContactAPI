using ContactAPI.Domain.Response;
using ContactAPI.Models;
using MediatR;

namespace ContactAPI.Commands
{
    public class CreateContactCommand : IRequest<ContactResponse>
    {
        public Contact Contact { get; set; }
    }
}
