using Barri.Assetment.CitaMedica.ParteRole.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barri.Assetment.CitaMedica.ParteRole.Domain.Infraestructure
{
    public interface IParteRoleRepository
    {
        Task<IEnumerable<Person>> GetAll(int idTipoParteRole);
        Task <Person> Find(string mail);
        Task<Person> Get(int idParteRole);
        Task<int> Insert(Person person);
    }
}
