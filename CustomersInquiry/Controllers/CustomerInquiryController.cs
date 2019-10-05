using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Business.Model;

namespace CustomersInquiry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInquiryController : ControllerBase
    {
        private readonly ICustomerInquiryManager _customerInquiryManager;

        public CustomerInquiryController(ICustomerInquiryManager customerInquiryManager)
        {
            _customerInquiryManager = customerInquiryManager;
        }

        [HttpGet("customerProfile")]
        public ActionResult GetCustomerProfile([FromQuery, RegularExpression("[0-9]{1,10}", ErrorMessage="CustomerId is not valid")] decimal customerId, 
            [FromQuery, EmailAddress, StringLength(25)] string email)
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