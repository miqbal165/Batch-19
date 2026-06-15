using OOPFundamentals.Models;

namespace OOPFundamentals.Repositories.Impl;

public class ProductRepository : IProductRepository
{
    private List<Product?> _data = new();
    private int _id = 1;
    public Product Add(Product product)
    {
        product.Id = _id++;
        _data.Add(product);
        return product;
    }

    public bool Detele(int id)
    {
        Product? data = GetById(id);
        if (data == null)
        {
            return false;
        }

        _data.Remove(data);
        return true;
    }

    public List<Product?> GetAll()
    {
        return _data;
    }

    public Product? GetById(int id)
    {
        return _data.FirstOrDefault(d => d.Id == id);
    }

    public Product? Update(Product product)
    {
        Product? data = GetById(product.Id);
        if (data == null)
        {
            return null;
        }

        data.Name = product.Name;
        data.Price = product.Price;

        return data;
    }
}