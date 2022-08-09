using System.Net;
using Dominio.Helpers;

namespace Dominio.Interfaces.Service
{
    public interface IService
    {
        ResponseService GenereteServiceResponseErro(string mensagem, HttpStatusCode status = HttpStatusCode.BadRequest);
        ResponseService<T> GenerateServiceResponseErro<T>(string mensagem, HttpStatusCode status = HttpStatusCode.BadRequest);

        ResponseService GenereteServiceResponseSucess(HttpStatusCode status = HttpStatusCode.OK);
        ResponseService<T> GenereteServiceResponseSucess<T>(T value, HttpStatusCode status = HttpStatusCode.OK);

    }
}
