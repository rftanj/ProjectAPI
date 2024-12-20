using ProjectAPI.Models;
using ProjectAPI.Models.DB;
using ProjectAPI.Models.DTO;

namespace ProjectAPI.Services
{
    public class CustomerService
    {
        private readonly ApplicationContext _context;
        public CustomerService(ApplicationContext context) 
        {
            _context = context;
        }

        public List<CustomerDTO> GetListCustomers()
        {
            var customers =  _context.Customers.Select(x => new CustomerDTO
            {
                name = x.Name,
                address = x.Address,
                city = x.City,
                phone_number = x.PhoneNumber
            }).ToList();

            return customers;
        } 
    }
}
