using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        public Task<IEnumerable<ProductModel>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> FindById(long id)
        {
            throw new NotImplementedException();
        }
        public Task<ProductModel> Create(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> Update(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
