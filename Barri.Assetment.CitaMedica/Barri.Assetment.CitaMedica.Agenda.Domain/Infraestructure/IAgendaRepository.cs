using Barri.Assetment.CitaMedica.Agenda.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barri.Assetment.CitaMedica.Agenda.Domain.Infraestructure
{
    public interface IAgendaRepository
    {
        Task<IEnumerable<Horario>> GetAllHorarios();
        Task<IEnumerable<AgendaInfo>> Find(int idParteRoleDoctor, DateTime fecha);
        Task Insert(AgendaItem agenda);
    }
}
