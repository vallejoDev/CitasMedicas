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
    public class FindAgendaHandler : IRequestHandler<FindAgendaCommand, IEnumerable<AgendaInfoDTO>>
    {
        public IAgendaRepository _repository { get; set; }
        public FindAgendaHandler(IAgendaRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<AgendaInfoDTO>> Handle(FindAgendaCommand request, CancellationToken cancellationToken)
        {
            var agendas = await _repository.Find(request.IdParteRoleDoctor, request.Fecha);

            return await Task.FromResult(agendas.Select(_ => new AgendaInfoDTO
            {
                IdAgenda = _.IdAgenda,
                IdHorario = _.IdHorario,
                IdParteRoleDoctor = _.IdParteRoleDoctor,
                IdParteRolePaciente = _.IdParteRolePaciente,
                Fecha = _.Fecha,
                Nombre = _.Nombre,
                ApellidoPaterno = _.ApellidoPaterno,
                ApellidoMaterno = _.ApellidoMaterno,
                Mail = _.Mail
            }));
        }
    }
}
