using Barri.Assetment.CitaMedica.ParteRole.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Barri.Assetment.CitaMedica.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<PersonsController> _logger;

        private IMediator _mediator;

        public PersonsController(IWebHostEnvironment webHostEnvironment, ILogger<PersonsController> logger, IMediator mediator)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("doctors")]
        public async Task<IActionResult> GetDoctors()
        {
            try
            {
                var doctors = await _mediator.Send(new GetDoctorsCommand());
                return await Task.FromResult(new JsonResult(doctors));
            }
            catch
            {
                return await Task.FromResult(NotFound());
            }
        }
        [HttpGet("doctors/{idParteRole}")]
        public async Task<IActionResult> GetDoctor(int idParteRole)
        {
            try
            {
                var doctor = await _mediator.Send(new GetDoctorCommand
                {
                    IdParteRole = idParteRole
                });
                return await Task.FromResult(new JsonResult(doctor));
            }
            catch
            {
                return await Task.FromResult(NotFound());
            }
        }

        [HttpGet("patients/{mail}")]
        public async Task<IActionResult> GetPatient(string mail)
        {
            try
            {
                var doctor = await _mediator.Send(new FindPatientCommand
                {
                    Mail = mail
                });
                return await Task.FromResult(new JsonResult(doctor));
            }
            catch
            {
                return await Task.FromResult(NotFound());
            }
        }
    }
}
