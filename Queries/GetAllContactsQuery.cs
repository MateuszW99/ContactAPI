using ContactAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Queries
{
    public class GetAllContactsQuery : IRequest<IEnumerable<Contact>>
    {

    }
}
