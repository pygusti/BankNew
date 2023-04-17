using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork.Interfaces;

namespace Bank_Updated.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BankController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]

        public IActionResult GetCustomerTransactions([FromQuery] int count)
        {
            try
            {
                var CustomerBalance = _unitOfWork.customerRepository.CustomerTransaction(count);
                return Ok(CustomerBalance);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }
            
        }


    }
}
