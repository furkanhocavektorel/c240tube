
using c240tube.entity;
using Microsoft.AspNetCore.Mvc;

namespace c240tube.controller
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {

        [HttpGet("bolme")]
        public double GetCustomers()
        {
            int a=0; 
            int b=10;
            double d=-88;

            try
            {
                d = b / a;

            }
            catch (Exception ex)
            {
                Console.WriteLine("hata aldık 0 a bölme hatası napıyosun");
            }
            
            return d;
        }

        [HttpGet("get")]

        public Customer GetCustomer()
        {
       
            return null;
        }
    }
}
