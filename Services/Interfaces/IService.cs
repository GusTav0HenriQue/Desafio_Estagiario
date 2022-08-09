using System.Net;
using Service.Helpers;

namespace Service.Interfaces
{
    public interface IService
    {
        ResponseService GenereteServiceResponseErro(string mensagem, HttpStatusCode status = HttpStatusCode.BadRequest);
        ResponseService<T> GenerateServiceResponseErro<T>(string mensagem, HttpStatusCode status = HttpStatusCode.BadRequest);

        ResponseService GenereteServiceResponseSucess(HttpStatusCode status = HttpStatusCode.OK);
        ResponseService<T> GenereteServiceResponseSucess<T>(T value, HttpStatusCode status = HttpStatusCode.OK);
    }
}
