using Barri.Assetment.CitaMedica.Agenda.Domain.Commands;
using Barri.Assetment.CitaMedica.ParteRole.Domain.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Barri.Assetment.CitaMedica.Orchester
{
    public class BookingHandler : IRequestHandler<BookingCommand, Unit>
    {
        IMediator _mediator;
        public BookingHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Unit> Handle(BookingCommand request, CancellationToken cancellationToken)
        {
            int idParteRolePaciente = request.Reservation.Patient.IdParteRole;
            if(MustCreatePatient(idParteRolePaciente))
            {
                var paciente = await _mediator.Send(new CreatePatientCommand
                {
                    Nombre = request.Reservation.Patient.Nombre,
                    ApellidoPaterno = request.Reservation.Patient.ApellidoPaterno,
                    ApellidoMaterno = request.Reservation.Patient.ApellidoMaterno,
                    Mail = request.Reservation.Patient.Mail
                });
                idParteRolePaciente = paciente.IdParteRole;
            }

            await _mediator.Send(new AddAgendaCommand
            {
                IdParteRoleDoctor = request.Reservation.IdParteRoleDoctor,
                IdParteRolePaciente = idParteRolePaciente,
                IdHorario = request.Reservation.IdHora,
                Fecha = request.Reservation.Fecha
            });
            return await Task.FromResult(Unit.Value);
        }

        private bool MustCreatePatient(int idParteRolePaciente) => idParteRolePaciente <= 0;
    }
}
