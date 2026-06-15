using OOPFundamentals.Controllers;
using OOPFundamentals.Repositories;
using OOPFundamentals.Repositories.Impl;
using OOPFundamentals.Services;
using OOPFundamentals.Services.Impl;

namespace OOPFundamentals;


internal abstract class Program
{
    public static void Main()
    {
        IUserRepository userRepo = new UserRepository();
        IProductRepository productRepo = new ProductRepository();

        IAuthService authService = new AuthService(userRepo);
        IProductService productService = new ProductService(productRepo);

        var auth = new AuthController(authService);
        var product = new ProductController(productService);

        auth.Register("admin", "123");
        auth.Login("admin", "123");

        product.Create("Laptop", 10000);
        product.Create("Mouse", 200);

        product.GetAll();

        product.Update(1, "Laptop Gaming", 15000);

        product.Delete(2);

        product.GetAll();
    }
}