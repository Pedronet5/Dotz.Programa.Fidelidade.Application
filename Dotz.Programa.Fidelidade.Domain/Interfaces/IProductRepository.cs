using Dotz.Programa.Fidelidade.Domain.Requests;
using Dotz.Programa.Fidelidade.Domain.Queries;
using System.Collections.Generic;

namespace Dotz.Programa.Fidelidade.Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<GetProductQueryResult> GetAllProduct();
        bool PostProduct(ProductRequest productModel);
        GetProductQueryResult GetByProductId(int ProductId);
        bool DeleteProduct(int ProductId);
        bool PutProduct(ProductPutRequest productPutRequest);
        IEnumerable<GetProductQueryResult> GetProductsExchangeListing(float Userbalance);

    }
}
