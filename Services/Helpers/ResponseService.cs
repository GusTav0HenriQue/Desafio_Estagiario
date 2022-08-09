namespace Service.Helpers
{
    public class ResponseService
    {
        public HttpResponseMessage Status { get; set; }
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }

    }
    public class ResponseService<T> : ResponseService
    {
        public T value { get; set; }
    }
}
