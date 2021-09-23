using SimpleApi.Models;
using SimpleApi.Repository.Interfaces;
using SimpleApi.SecretSauce;
using SimpleAPI.Repository;

namespace SimpleApi.EndpointDefinitions
{
    public class CustomerEndpointDefinition : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/all", GetAll);

            app.MapGet("/getbyid/{id}", GetById);

            app.MapPost("/create", Create);

            app.MapPut("/update", Update);

            app.MapDelete("/delete/{id}", Delete);

        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
        }

        internal static IResult GetAll(ICustomerRepository repo)
        {
            var customer = repo.GetAll();
            return customer is not null ? Results.Ok(customer) : Results.NotFound();
        }

        internal static IResult GetById(ICustomerRepository repo, Guid id)
        {
            var customer = repo.GetById(id);
            return customer is not null ? Results.Ok(customer) : Results.NotFound();
        }

        internal static IResult Create(ICustomerRepository repo, Customer customer)
        {
            repo.Create(customer);
            return customer is not null ? Results.Ok() : Results.NoContent();
        }

        internal static IResult Update(ICustomerRepository repo, Customer customer)
        {
            repo.Update(customer);
            return customer is not null ? Results.Ok() : Results.NoContent();
        }

        internal static void Delete(ICustomerRepository repo, Guid id)
        {
            repo.Delete(id);
        }
    }
}
