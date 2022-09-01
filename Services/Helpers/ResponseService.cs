using System.Net;

namespace Service.Helpers
{
    public class ResponseService
    {
        public HttpStatusCode Status { get; set; }
        public bool Sucesso { get; set; }
        public string? Mensagem { get; set; }

    }
    public class ResponseService<T> : ResponseService
    {
        public T? Value { get; set; }
    }
}
