using Barri.Assetment.CitaMedica.ParteRole.Domain.Commands;
using Barri.Assetment.CitaMedica.ParteRole.Domain.Infraestructure;
using Barri.Assetment.CitaMedica.ParteRole.Domain.Model.DTO;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Barri.Assetment.CitaMedica.ParteRole.Domain.Application
{
    public class FindPatientHandler : IRequestHandler<FindPatientCommand, PatientDTO>
    {
        private IParteRoleRepository _repository;
        public FindPatientHandler(IParteRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<PatientDTO> Handle(FindPatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _repository.Find(request.Mail);

            return await Task.FromResult(new PatientDTO
            {
                IdParteRole = patient.IdParteRole,
                IdTipoParteRole = patient.IdTipoParteRole,
                Nombre = patient.Nombre,
                ApellidoPaterno = patient.ApellidoPaterno,
                ApellidoMaterno = patient.ApellidoMaterno,
                Mail = patient.Mail
            });
        }
    }
}
