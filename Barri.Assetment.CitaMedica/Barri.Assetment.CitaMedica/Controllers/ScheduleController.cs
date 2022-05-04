using Barri.Assetment.CitaMedica.Agenda.Domain.Commands;
using Barri.Assetment.CitaMedica.Model;
using Barri.Assetment.CitaMedica.Orchester;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Barri.Assetment.CitaMedica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<ScheduleController> _logger;

        private IMediator _mediator;

        public ScheduleController(IWebHostEnvironment webHostEnvironment, ILogger<ScheduleController> logger, IMediator mediator)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("horarios")]
        public async Task<IActionResult> GetHorarios()
        {
            var horarios = await _mediator.Send(new GetHorariosCommand());
            return await Task.FromResult(new JsonResult(horarios));
        }
        [HttpGet("filter")]
        public async Task<IActionResult> Filter([FromQuery] DateTime fecha, [FromQuery] int idParteRole)
        {
            var reservations = await _mediator.Send(new FindAgendaCommand
            {
                IdParteRoleDoctor = idParteRole,
                Fecha = fecha
            });
            return await Task.FromResult(new JsonResult(reservations));
        }
        [HttpPost]
        public async Task<IActionResult> Booking(Reservation reservation)
        {
            try
            {
                await _mediator.Send(new BookingCommand
                {
                    Reservation = reservation
                });
                return await Task.FromResult(new OkResult());
            }
            catch
            {
                return await Task.FromResult(new StatusCodeResult(500));
            }
        }
    }
}
