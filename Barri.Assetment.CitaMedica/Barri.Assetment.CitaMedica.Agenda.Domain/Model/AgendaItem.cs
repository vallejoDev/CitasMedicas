using System;

namespace Barri.Assetment.CitaMedica.Agenda.Domain.Model
{
    public class AgendaItem
    {
        public int IdAgenda { get; set; }
        public int IdHorario { get; set; }
        public int IdParteRoleDoctor { get; set; }
        public int IdParteRolePaciente { get; set; }
        public DateTime Fecha { get; set; }
    }
}
