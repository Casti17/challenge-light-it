using Microsoft.AspNetCore.Mvc;
using PatientRegistry.Domain;
using PatientRegistry.Services;

namespace PatientRegistrationChallenge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly PatientsService _patientsService;

        public PatientsController(PatientsService patientsService)
        {
            _patientsService = patientsService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] Patient patient, [FromForm] IFormFile documentPhoto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var resultMessage = await _patientsService.RegisterPatientAsync(patient, documentPhoto);
                return Ok(new { message = resultMessage });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            try
            {
                var patients = await _patientsService.GetPatientsAsync();
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
