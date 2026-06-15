using OOPFundamentals.Models;

namespace OOPFundamentals.Repositories;

public interface IProductRepository
{
    List<Product?> GetAll();
    Product? GetById(int id);
    Product? Add(Product product);
    Product? Update(Product product);
    bool Detele(int id);
}