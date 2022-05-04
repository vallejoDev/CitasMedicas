using Barri.Assetment.CitaMedica.ParteRole.Common;
using Barri.Assetment.CitaMedica.ParteRole.Domain.Commands;
using Barri.Assetment.CitaMedica.ParteRole.Domain.Infraestructure;
using Barri.Assetment.CitaMedica.ParteRole.Domain.Model;
using Barri.Assetment.CitaMedica.ParteRole.Domain.Model.DTO;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Barri.Assetment.CitaMedica.ParteRole.Domain.Application
{
    public class CreatePatientHandler : IRequestHandler<CreatePatientCommand, PatientDTO>
    {
        private IParteRoleRepository _repository;
        public CreatePatientHandler(IParteRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<PatientDTO> Handle(CreatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = new Person
            {
                IdTipoParteRole = (int)eTipoParteRole.Paciente,
                Nombre = request.Nombre,
                ApellidoPaterno = request.ApellidoPaterno,
                ApellidoMaterno = request.ApellidoMaterno,
                Mail = request.Mail
            };
            var idParteRole = await _repository.Insert(patient);

            return await Task.FromResult(new PatientDTO { 
                IdParteRole = idParteRole,
                IdTipoParteRole = (int)eTipoParteRole.Paciente,
                Nombre = patient.Nombre,
                ApellidoPaterno = patient.ApellidoPaterno,
                ApellidoMaterno = patient.ApellidoMaterno,
                Mail = patient.Mail
            });
        }
    }
}
