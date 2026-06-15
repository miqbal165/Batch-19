using OOPFundamentals.Dtos;
using OOPFundamentals.Dtos.Products;
using OOPFundamentals.Models;
using OOPFundamentals.Repositories;
using OOPFundamentals.Utils.Mappers;

namespace OOPFundamentals.Services.Impl;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public CommonResponse<ProductDto?> Create(CreateProductDto dto)
    {
        Product? newProduct = _repo.Add(ProductMapper.ToModel(dto));
        ProductDto? productDtoResponse = ProductMapper.ToDto(newProduct);
        return CommonResponse<ProductDto?>.Ok(
            productDtoResponse, "Success create new product"
            );
    }

    public CommonResponse<bool> Delete(int id)
    {
        bool success = _repo.Detele(id);
        if (!success)
        {
            return CommonResponse<bool>.Fail("Not Found");
        }

        return CommonResponse<bool>.Ok(true, "Success delete product");
    }

    public CommonResponse<List<ProductDto?>> GetAll()
    {
        List<ProductDto?> listProductResponse = ProductMapper.ToDtoList(_repo.GetAll());
        return CommonResponse<List<ProductDto?>>.Ok(listProductResponse);
    }

    public CommonResponse<ProductDto?> GetById(int id)
    {
        Product? product = _repo.GetById(id);
        if (product == null)
        {
            return CommonResponse<ProductDto?>.Fail($"Product with id {id} is not found");
        }

        ProductDto? productResponse = ProductMapper.ToDto(product);

        return CommonResponse<ProductDto?>.Ok(productResponse);
    }

    CommonResponse<ProductDto?> IProductService.Update(int id, UpdateProductDto dto)
    {
        Product? product = _repo.Update(ProductMapper.ToModel(id, dto));

        if (product == null)
        {
            return CommonResponse<ProductDto?>.Fail($"Product with id {id} is not found");
        }

        ProductDto? productDtoResponse = ProductMapper.ToDto(product);
        return CommonResponse<ProductDto?>.Ok(productDtoResponse, "Success update product");
    }
}