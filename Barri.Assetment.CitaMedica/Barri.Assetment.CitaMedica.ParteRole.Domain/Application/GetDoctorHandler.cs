using Barri.Assetment.CitaMedica.ParteRole.Domain.Commands;
using Barri.Assetment.CitaMedica.ParteRole.Domain.Infraestructure;
using Barri.Assetment.CitaMedica.ParteRole.Domain.Model.DTO;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Barri.Assetment.CitaMedica.ParteRole.Domain.Application
{
    public class GetDoctorHandler : IRequestHandler<GetDoctorCommand, DoctorDTO>
    {
        private IParteRoleRepository _repository;
        public GetDoctorHandler(IParteRoleRepository repository)
        {
            _repository = repository;
        }

        public async Task<DoctorDTO> Handle(GetDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await _repository.Get(request.IdParteRole);

            return await Task.FromResult(new DoctorDTO
            {
                IdParteRole = doctor.IdParteRole,
                IdTipoParteRole = doctor.IdTipoParteRole,
                Nombre = doctor.Nombre,
                ApellidoPaterno = doctor.ApellidoPaterno,
                ApellidoMaterno = doctor.ApellidoMaterno,
            });
        }
    }
}
