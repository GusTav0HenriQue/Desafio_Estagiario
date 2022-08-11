using System.Net;
using FluentValidation;
using FluentValidation.Results;
using Service.Helpers;
using Service.Interfaces;
using Dominio.Enums;
using System.Globalization;

namespace Service.Services
{
    public abstract class AbstractService : IService
    {
        public ResponseService<T> GenerateErroServiceResponse<T>(string mensagem, HttpStatusCode status = HttpStatusCode.BadRequest) => new()
        {
            Status = status,
            Mensagem= mensagem,
            Sucesso = false,
            Value = default
        };

        public ResponseService GenereteErroServiceResponse(string mensagem, HttpStatusCode status = HttpStatusCode.BadRequest) => new()
        {
            Status = status,
            Mensagem = mensagem,
            Sucesso = false,
        };

        public ResponseService GenereteServiceResponseSucess(HttpStatusCode status = HttpStatusCode.OK)=> new()
        {
            Mensagem=string.Empty,
            Sucesso = true,
            Status = status
        };

        public ResponseService<T> GenereteServiceResponseSucess<T>(T value, HttpStatusCode status = HttpStatusCode.OK) => new()
        {
            Status = status,
            Mensagem = string.Empty,
            Sucesso = true,
            Value = value
        };

        private readonly List<string> _notificacao;
        protected AbstractService()
        {
            _notificacao = new List<string>();
        }
        protected void Notificar(ValidationResult validationResult)
        {
            foreach(var erro in validationResult.Errors)
            {
                Notificar(erro.ErrorMessage);
            }
        }

        protected void Notificar(string menssagem)
        {
            _notificacao.Add(new string(menssagem));
        }
        public List<string> GetNotifcacao()
        {
           return _notificacao;
        }
        public static bool VerificarId(int id)
        {
            return (id <= 0);
        }

        protected bool RealizarValidacao<V,E>(V validacao, E entity) where V : AbstractValidator<E>
        {
            var autenticado = validacao.Validate(entity);

            if (autenticado.IsValid) return true;

            Notificar(autenticado);

            return false;
        }
        public static ElencoPapel ConverterEnum(string enumNome) 
        {
            ElencoPapel elencoPapel = (ElencoPapel)Enum.Parse(typeof(ElencoPapel), CultureInfo.CurrentCulture.TextInfo.ToTitleCase(enumNome));

            if (elencoPapel == ElencoPapel.Ator)
                return ElencoPapel.Ator;

            else
                return ElencoPapel.Diretor;


            throw new ArgumentOutOfRangeException("Não existe um Enum com esse Nome");
        }

    }
}
