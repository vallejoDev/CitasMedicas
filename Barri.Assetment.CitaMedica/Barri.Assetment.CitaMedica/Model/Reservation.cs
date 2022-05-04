using System;

namespace Barri.Assetment.CitaMedica.Model
{
    public class Reservation
    {
        public int? IdReservation { get; set; }
        public int IdParteRoleDoctor { get; set; }
        public DateTime Fecha { get; set; }
        public int IdHora { get; set; }
        public Patient Patient { get; set; }
    }
}
