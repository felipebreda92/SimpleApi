namespace SimpleAPI.Repository
{
    public class CustomerRepository
    {
        private readonly Dictionary<Guid, Customer> _customers = new();

        public void Create(Customer customer)
        {
            if(customer is null){
                return;
            }
            _customers[customer.Id] = customer;
        }

        public List<Customer> GetAll()
        {
                return _customers.Values.ToList();
        }

        public Customer GetById(Guid Id)
        {
                return _customers[Id];
        }

        public void Update(Customer customer)
        {
            var existingCustomer = GetById(customer.Id);
            if(customer is null)
            {
                    return;
            }

            _customers[customer.Id] = customer;
        }

        public void Delete(Guid id)
        {
            _customers.Remove(id);
        }
    }
}