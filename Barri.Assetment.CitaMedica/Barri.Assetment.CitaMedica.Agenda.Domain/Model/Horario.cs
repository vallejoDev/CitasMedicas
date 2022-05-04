using Dapper.Contrib.Extensions;
using System.ComponentModel;

namespace Barri.Assetment.CitaMedica.Agenda.Domain.Model
{
    [Table("Horario")]
    public class Horario
    {
        [Key]
        public int IdHorario { get; set; }
        public int HoraInicio { get; set; }
    }
}
