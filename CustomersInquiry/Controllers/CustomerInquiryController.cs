using System.ComponentModel.DataAnnotations;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Business.Model;

namespace CustomersInquiry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInquiryController : ControllerBase
    {
        private readonly ICustomerInquiryManager _customerInquiryManager;

        private const string InvalidCustomerId = "Invalid Customer ID";
        private const string InvalidEmail = "Invalid Email";

        public CustomerInquiryController(ICustomerInquiryManager customerInquiryManager)
        {
            _customerInquiryManager = customerInquiryManager;
        }

        [HttpGet("customerProfile")]
        public ActionResult GetCustomerProfile([FromQuery, RegularExpression("[0-9]{1,10}", ErrorMessage=InvalidCustomerId)] decimal customerId, 
            [FromQuery, EmailAddress(ErrorMessage = InvalidEmail), StringLength(25, ErrorMessage = InvalidEmail)] string email)
        {
            if(customerId == decimal.Zero && string.IsNullOrEmpty(email))
            {
                return BadRequest("No inquiry data provided");
            }

            CustomerProfile customerProfile;
            
            try
            {
                customerProfile = _customerInquiryManager.GetCustomerProfile(customerId, email);
            }
            catch(CustomerNotFoundException ex)
            {
                return NotFound(ex.Message);
            }   

            return Ok(customerProfile);
        }
    }
}