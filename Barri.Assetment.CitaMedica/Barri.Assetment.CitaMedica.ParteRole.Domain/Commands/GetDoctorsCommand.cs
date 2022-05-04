using Barri.Assetment.CitaMedica.ParteRole.Domain.Model.DTO;
using MediatR;
using System.Collections.Generic;

namespace Barri.Assetment.CitaMedica.ParteRole.Domain.Commands
{
    public class GetDoctorsCommand : IRequest<IEnumerable<DoctorDTO>>
    {
    }
}
