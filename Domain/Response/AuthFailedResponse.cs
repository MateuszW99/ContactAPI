using System.Collections.Generic;

namespace ContactAPI.Domain.Response
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> ErrorMessages { get; set; }
    }
}
