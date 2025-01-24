using c240tube.context;
using c240tube.entity;
using c240tube.service.abstracts;

namespace c240tube.service.concrete
{
    public class CustomerService : ICustomerService
    {
        private C240tubeContext _context;

        public CustomerService(C240tubeContext context)
        {
            _context = context;
        }


        public void save(string name, string phone, Auth auth)
        {
            Customer customer = new Customer();
            customer.Name = name;
            customer.Phone = phone;
            customer.Auth = auth;

            _context.Customer.Add(customer);
            _context.SaveChanges();
            
        }
    }
}
