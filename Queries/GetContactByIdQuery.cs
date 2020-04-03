using ContactAPI.Domain.Response;
using MediatR;

namespace ContactAPI.Queries
{
    public class GetContactByIdQuery : IRequest<ContactResponse>
    {
        public int Id { get; set; }

        public GetContactByIdQuery(int id)
        {
            Id = id;
        }

    }
}
