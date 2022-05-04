using Barri.Assetment.CitaMedica.Agenda.Domain.Commands;
using Barri.Assetment.CitaMedica.Agenda.Domain.Infraestructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Barri.Assetment.CitaMedica.Agenda.Domain.Application
{
    public class AddAgendaHandler : IRequestHandler<AddAgendaCommand, Unit>
    {
        public IAgendaRepository _repository { get; set; }
        public AddAgendaHandler(IAgendaRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(AddAgendaCommand request, CancellationToken cancellationToken)
        {
            await _repository.Insert(new Model.AgendaItem
            {
                IdHorario = request.IdHorario,
                Fecha = request.Fecha,
                IdParteRoleDoctor = request.IdParteRoleDoctor,
                IdParteRolePaciente = request.IdParteRolePaciente
            });

            return await Task.FromResult(Unit.Value);
        }
    }
}
