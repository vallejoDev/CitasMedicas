using Barri.Assetment.CitaMedica.ParteRole.Domain.Model.DTO;
using MediatR;

namespace Barri.Assetment.CitaMedica.ParteRole.Domain.Commands
{
    public class GetDoctorCommand : IRequest<DoctorDTO>
    {
        public int IdParteRole { get; set; }
    }
}
