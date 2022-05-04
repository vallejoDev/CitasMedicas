using Barri.Assetment.CitaMedica.Model;
using MediatR;

namespace Barri.Assetment.CitaMedica.Orchester
{
    public class BookingCommand : IRequest<Unit>
    {
        public Reservation Reservation { get; set; }
    }
}
