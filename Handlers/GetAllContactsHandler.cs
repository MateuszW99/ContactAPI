using ContactAPI.Models;
using ContactAPI.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContactAPI.Handlers
{
    public class GetAllContactsHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<Contact>>
    {
        private readonly Context.DataContext _dataContext;

        public GetAllContactsHandler(Context.DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Contact>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _dataContext.Contacts.ToListAsync();
            return contacts;
        }
    }
}
