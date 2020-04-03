using ContactAPI.Commands;
using ContactAPI.Domain.Response;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ContactAPI.Handlers
{
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, ContactResponse>
    {
        private readonly Context.DataContext _dataContext;

        public CreateContactHandler(Context.DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ContactResponse> Handle(CreateContactCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return null;
            }
            await _dataContext.Contacts.AddAsync(command.Contact);
            await _dataContext.SaveChangesAsync();
            var contact = await _dataContext.Contacts.FindAsync(command.Contact.ID);
            if (contact == null)
            {
                return null;
            }
            return new ContactResponse { Contact = contact };
        }
    }
}
