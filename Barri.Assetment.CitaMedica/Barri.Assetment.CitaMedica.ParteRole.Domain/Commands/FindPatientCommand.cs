using Barri.Assetment.CitaMedica.ParteRole.Domain.Model.DTO;
using MediatR;

namespace Barri.Assetment.CitaMedica.ParteRole.Domain.Commands
{
    public class FindPatientCommand : IRequest<PatientDTO>
    {
        public string Mail { get; set; }
    }
}
