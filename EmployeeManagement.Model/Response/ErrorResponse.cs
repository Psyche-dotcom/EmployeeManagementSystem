using System.Net;

namespace EmployeeManagement.Model.Response
{
    public class ErrorResponse
    {
        public string Title { get; set; } = default!;
        public string Message { get; set; } = default!;
        public HttpStatusCode StatusCode { get; set; } = default!;
    }
}
