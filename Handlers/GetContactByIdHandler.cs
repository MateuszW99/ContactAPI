using ContactAPI.Domain.Response;
using ContactAPI.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ContactAPI.Handlers
{
    public class GetContactByIdHandler : IRequestHandler<GetContactByIdQuery, ContactResponse>
    {
        private readonly Context.DataContext _dataContext;

        public GetContactByIdHandler(Context.DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ContactResponse> Handle(GetContactByIdQuery query, CancellationToken cancellationToken)
        {
            var contact = await _dataContext.Contacts.FindAsync(query.Id);            
            return contact == null ? null : new ContactResponse { Contact = contact };
        }
    }
}
