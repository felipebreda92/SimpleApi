using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<CustomerRepository>();
await using var app = builder.Build();

app.MapGet("/all", ([FromServices] CustomerRepository repo) =>
{
    return repo.GetAll();
});

app.MapGet("/getbyid/{id}", ([FromServices] CustomerRepository repo, Guid id) =>
{
    var customer = repo.GetById(id);
    return customer is not null ? Results.Ok(customer) : Results.NotFound();
});

app.MapPost("/create", ([FromServices] CustomerRepository repo, Customer customer) =>
{
    repo.Create(customer);
    return customer is not null ? Results.Ok() : Results.NoContent();
});

app.MapPut("/update", ([FromServices] CustomerRepository repo, Customer customer) =>
{
    repo.Update(customer);
    return customer is not null ? Results.Ok() : Results.NoContent();
});

app.MapDelete("/delete/{id}", ([FromServices] CustomerRepository repo, Guid id) =>
{
    repo.Delete(id);
});

await app.RunAsync();

public record Customer(Guid Id, string FullName);