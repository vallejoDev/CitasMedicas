using Barri.Assetment.CitaMedica.ParteRole.Common;
using Barri.Assetment.CitaMedica.ParteRole.Domain.Commands;
using Barri.Assetment.CitaMedica.ParteRole.Domain.Infraestructure;
using Barri.Assetment.CitaMedica.ParteRole.Domain.Model.DTO;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Barri.Assetment.CitaMedica.ParteRole.Domain.Application
{
    public class GetDoctorsHandler : IRequestHandler<GetDoctorsCommand, IEnumerable<DoctorDTO>>
    {
        private IParteRoleRepository _repository;
        public GetDoctorsHandler(IParteRoleRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<DoctorDTO>> Handle(GetDoctorsCommand request, CancellationToken cancellationToken)
        {
            var doctors = await _repository.GetAll((int)eTipoParteRole.Medico);
            return await Task.FromResult(doctors.Select(_ => new DoctorDTO
            {
                IdParteRole = _.IdParteRole,
                IdTipoParteRole = _.IdTipoParteRole,
                Nombre = _.Nombre,
                ApellidoMaterno = _.ApellidoMaterno,
                ApellidoPaterno = _.ApellidoPaterno
            }));
        }
    }
}
