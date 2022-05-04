using Barri.Assetment.CitaMedica.Agenda.Domain.Model.DTO;
using MediatR;
using System.Collections.Generic;

namespace Barri.Assetment.CitaMedica.Agenda.Domain.Commands
{
    public class GetHorariosCommand : IRequest<IEnumerable< HorarioDTO>>
    {
    }
}
