using Barri.Assetment.CitaMedica.Agenda.Domain.Commands;
using Barri.Assetment.CitaMedica.Agenda.Domain.Infraestructure;
using Barri.Assetment.CitaMedica.Agenda.Domain.Model.DTO;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Barri.Assetment.CitaMedica.Agenda.Domain.Application
{
    public class GetHorariosHandler : IRequestHandler<GetHorariosCommand, IEnumerable<HorarioDTO>>
    {
        public IAgendaRepository _repository { get; set; }
        public GetHorariosHandler(IAgendaRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<HorarioDTO>> Handle(GetHorariosCommand request, CancellationToken cancellationToken)
        {
            var horarios = await _repository.GetAllHorarios();
            return await Task.FromResult(horarios.Select(_ => new HorarioDTO
            {
                IdHorario = _.IdHorario,
                Hora = _.HoraInicio
            }));
        }
    }
}
