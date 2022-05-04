using Barri.Assetment.CitaMedica.ParteRole.Domain.Model.DTO;
using MediatR;

namespace Barri.Assetment.CitaMedica.ParteRole.Domain.Commands
{
    public class CreatePatientCommand : IRequest<PatientDTO>
    {
        public string Mail { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
    }
}
