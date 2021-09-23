using SimpleApi.Models;

namespace SimpleApi.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        List<Customer> GetAll();
        Customer GetById(Guid Id);
        void Update(Customer customer);
        void Delete(Guid id);
    }
}
