using System;

namespace Barri.Assetment.CitaMedica.Agenda.Domain.Model
{
    public class AgendaInfo
    {
        public int IdAgenda { get; set; }
        public int IdHorario { get; set; }
        public int IdParteRoleDoctor { get; set; }
        public int IdParteRolePaciente { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Mail { get; set; }
    }
}
