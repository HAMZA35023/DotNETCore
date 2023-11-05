using Microsoft.AspNetCore.Mvc;
using PatientDemo.BusinessLogic;
using PatientDemo.Views;
using System.ComponentModel.DataAnnotations;

namespace PatientDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientRequestController : ControllerBase
    {
        private PatientInfographicsBL patientBL = new PatientInfographicsBL();

        public PatientRequestController()
        {
        }

        [HttpPost("PostPatientData",Name = "PatientRequestData")]
        public IActionResult PostPatientInformation([FromBody] PatientDataView patientData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string message = patientBL.SavePatientInfographics(patientData);
                    return Ok(message);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex);
            }
        }

    }
}