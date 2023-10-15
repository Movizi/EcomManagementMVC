using EcomManagement.Models.Products;

namespace EcomManagement.Contracts
{
    public interface IProductImageRepository : ICrudRepository<ProductImage>
    {
        public List<ProductImage> GetImagesByProductId(int productId);
    }
}
