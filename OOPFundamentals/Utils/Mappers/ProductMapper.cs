using OOPFundamentals.Dtos.Products;
using OOPFundamentals.Models;

namespace OOPFundamentals.Utils.Mappers;

public class ProductMapper
{
    public static ProductDto? ToDto(Product? product)
    {
        if (product == null)
        {
            return null;
        }

        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }

    public static List<ProductDto?> ToDtoList(List<Product> list)
    {
        return list.Select(ToDto).ToList();
    }

    public static Product ToModel(CreateProductDto dto)
    {
        return new Product
        {
            Name = dto.Name,
            Price = dto.Price
        };
    }

    public static Product ToModel(int id, UpdateProductDto dto)
    {
        return new Product
        {
            Id = id,
            Name = dto.Name,
            Price = dto.Price
        };
    }
}