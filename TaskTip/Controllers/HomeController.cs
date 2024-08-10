using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskTipCore.DTO;
using TaskTipCore.Services.Customer;
using TaskTipCore.Utility;

namespace TaskTip.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public HomeController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet]
        [Route("/نمایش مشتریان")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = _customerServices.FindAll().ToArray();
            return Ok(customers);
        }
        [HttpPost]
        [Route("/جدید")]
        public OperationResult Create([FromForm] CustomerDto customerDto)
        {
            OperationResult result = new OperationResult();
            if (customerDto != null)
            {
                result = _customerServices.Create(customerDto);
            }
            return result;
        }

        [HttpPost]
        [Route("/ویرایش")]
        public OperationResult update([FromForm] Guid ID, [FromForm] CustomerDto customerDto)
        {
            OperationResult result = new OperationResult();
            if (customerDto != null)
            {
                result = _customerServices.Update(ID, customerDto);
            }
            return result;
        }

        [HttpPost]
        [Route("/حذف")]
        public OperationResult Delete([FromForm] Guid ID)
        {
            OperationResult result = new OperationResult();
            var _customer = _customerServices.FindByID(ID);
            result = _customerServices.Delete(_customer);

            return result;
        }
    }
}
