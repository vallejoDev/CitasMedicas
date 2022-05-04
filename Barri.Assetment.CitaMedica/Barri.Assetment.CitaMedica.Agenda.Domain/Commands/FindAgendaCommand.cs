using Barri.Assetment.CitaMedica.Agenda.Domain.Model.DTO;
using MediatR;
using System;
using System.Collections.Generic;

namespace Barri.Assetment.CitaMedica.Agenda.Domain.Commands
{
    public class FindAgendaCommand : IRequest<IEnumerable<AgendaInfoDTO>>
    {
        public int IdParteRoleDoctor { get; set; }
        public DateTime Fecha { get; set; }
    }
}
