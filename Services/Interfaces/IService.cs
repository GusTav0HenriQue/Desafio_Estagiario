using System.Net;
using Service.Helpers;

namespace Service.Interfaces
{
    public interface IService
    {
        ResponseService GenereteErroServiceResponse(string mensagem, HttpStatusCode status = HttpStatusCode.BadRequest);
        ResponseService<T> GenerateErroServiceResponse<T>(string mensagem, HttpStatusCode status = HttpStatusCode.BadRequest);

        ResponseService GenereteServiceResponseSucess(HttpStatusCode status = HttpStatusCode.OK);
        ResponseService<T> GenereteServiceResponseSucess<T>(T value, HttpStatusCode status = HttpStatusCode.OK);
    }
}
