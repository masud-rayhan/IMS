using IMS.DataAccess.Repository.IRepository;
using IMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost("createCountry")]
        public IActionResult CreateCountry(Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var myConuntry = new Country { Name = country.Name, ShortName = country.ShortName };
            try
            {
               bool x= _unitOfWork.Country.Add(myConuntry);
               bool y=_unitOfWork.Save();

                return Ok(new { Add=x ,Save=y});
            }
            catch
            {
                return StatusCode(500, "Internal Server Error. Please Try again later");
            }
        } 

        [HttpGet("getCountry")]
        public IActionResult GetCountry()
        {
            try
            {
                var result = _unitOfWork.Country.GetAll();
                return Ok(result);
            }
            catch
            {
                return NotFound();
            }
        }

        

    }
}
