using OOPFundamentals.Dtos;
using OOPFundamentals.Dtos.Products;

namespace OOPFundamentals.Services;

public interface IProductService
{
    CommonResponse<List<ProductDto?>> GetAll();
    CommonResponse<ProductDto?> GetById(int id);
    CommonResponse<ProductDto?> Create(CreateProductDto dto);
    CommonResponse<ProductDto?> Update(int id, UpdateProductDto dto);
    CommonResponse<bool> Delete(int id);
}