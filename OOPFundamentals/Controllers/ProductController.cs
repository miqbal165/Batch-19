using OOPFundamentals.Dtos.Products;
using OOPFundamentals.Services;

namespace OOPFundamentals.Controllers;

public class ProductController
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        _service = service;
    }

    public void GetAll() => Print(_service.GetAll());

    public void GetById(int id) => Print(_service.GetById(id));

    public void Create(string name, decimal price)
        => Print(_service.Create(new CreateProductDto { Name = name, Price = price }));

    public void Update(int id, string name, decimal price)
        => Print(_service.Update(id, new UpdateProductDto { Name = name, Price = price }));

    public void Delete(int id) => Print(_service.Delete(id));

    private void Print(object obj)
    {
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(obj));
    }
}