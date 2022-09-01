using System.Globalization;
using AutoMapper;
using Dominio.DTOs.ElencoDtos;
using Dominio.Entities;
using Dominio.Interfaces.Data;
using Service.Helpers;
using Service.Interfaces;
using Service.Validator.Elenco;

namespace Service.Services
{
    public class ElencoService : AbstractService, IElencoService
    {
        private readonly IMapper _mapper;
        private readonly IElencoRepository _eRepository;

        public ElencoService(IMapper mapper, IElencoRepository eRepository)
        {
            _mapper = mapper;
            _eRepository = eRepository;
        }

        public async Task<ResponseService> CadastrarElenco(CadastrarElencoDto cadastrarElencoDto, CancellationToken cancellationToken)
        {
            var artista = await _eRepository.GetElencoByName(cadastrarElencoDto.Nome, cancellationToken);

            if(artista == null)
            {
                await _eRepository.Add(new Elenco
                {
                    Nome = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(cadastrarElencoDto.Nome),
                    DataDeNascimento = DateTime.Parse(cadastrarElencoDto.DataDeNascimento),
                    Ativo = true,
                    Papel = ConverterEnum(cadastrarElencoDto.Papel)
                }, cancellationToken);
                await _eRepository.SaveChanges(cancellationToken);
                return GenereteServiceResponseSucess("O Artista foi Cadastrado com sucesso.");
            }

            return GenereteErroServiceResponse("O Artista ja foi cadastrado.");
        }

        public async Task<ResponseService> Delete(int id, CancellationToken cancellationToken)
        {
            if (VerificarId(id))
                return GenereteErroServiceResponse("O id não pode ser menor que zero.");
            var delete = await _eRepository.GetById(id, cancellationToken);

            if (delete == null)
                return GenereteErroServiceResponse($"O artista com o id {id} não foi encontrado.");
            await _eRepository.Delete(delete, cancellationToken);
            return GenereteServiceResponseSucess("O Artista foi deletado com sucesso.");
        }

        public ResponseService<IQueryable<ReadElencoDto>> GetAllElenco()
        {
            var artista = _eRepository.GetAll();
            if (!artista.Any())
                return GenerateErroServiceResponse<IQueryable<ReadElencoDto>>("Ainda não foi Cadastrado nenhum artista.");
            return GenereteServiceResponseSucess(_mapper.ProjectTo<ReadElencoDto>(artista));
        }

        public async Task<ResponseService> UpdateElenco(int id,UpdateElencoDto updateElencoDto, CancellationToken cancellationToken)
        {
            var artista = await _eRepository.GetById(id,cancellationToken);
            if (artista == null)
                return GenereteErroServiceResponse("Não encontramos o artista.");
            if (!RealizarValidacao(new UpdateElencoValidator(), updateElencoDto))
                return GenereteErroServiceResponse(GetNotifcacao().First());

            artista.AttElenco(artista);
            await _eRepository.SaveChanges(cancellationToken);

            return GenereteServiceResponseSucess(artista);
        }

    }
}
