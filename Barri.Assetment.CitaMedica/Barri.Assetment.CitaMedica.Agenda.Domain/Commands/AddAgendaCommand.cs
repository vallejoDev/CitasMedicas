using MediatR;
using System;

namespace Barri.Assetment.CitaMedica.Agenda.Domain.Commands
{
    public class AddAgendaCommand : IRequest<Unit>
    {
        public int IdParteRoleDoctor { get; set; }
        public int IdParteRolePaciente { get; set; }
        public int IdHorario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
