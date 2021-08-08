using Dapper;
using Dotz.Programa.Fidelidade.Domain.Interfaces;
using Dotz.Programa.Fidelidade.Domain.Queries;
using Dotz.Programa.Fidelidade.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Dotz.Programa.Fidelidade.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<GetProductQueryResult> GetAllProduct()
        {
            try
            {
                var query = @"SELECT id AS Id, name AS Name, valor AS Valor, categoryid As CategoryId
                              FROM product
                              ORDER BY id ASC";

                var entity = _unitOfWork.Connection.Query<GetProductQueryResult>(query, null, commandType: CommandType.Text);

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GetProductQueryResult GetByProductId(int ProductId)
        {
            try
            {
                var query = @"SELECT id AS Id, name AS Name, valor AS Valor, categoryid As CategoryId
                              FROM product
                              WHERE id = @Id
                              ORDER BY id ASC";

                var entity = _unitOfWork.Connection.Query<GetProductQueryResult>(query, new { Id = ProductId }, commandType: CommandType.Text);

                return entity.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool PostProduct(ProductRequest product)
        {
            try
            {
                var query = $@"INSERT INTO product (name, valor, categoryid, updatedate) 
                               VALUES (@Name, @Valor, @CategoryId, sysdate(3))";

                var parameters = new DynamicParameters();
                parameters.Add("@Name", product.Name);
                parameters.Add("@Valor", product.Valor);
                parameters.Add("@CategoryId", product.CategoryId);

                _unitOfWork.Connection.Query(query, parameters, commandType: CommandType.Text);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PutProduct(ProductPutRequest productPutRequest)
        {
            try
            {
                var query = $@"UPDATE product SET name = @Name, valor = @Valor, categoryid = @CategoryId, updatedate = sysdate(3)                             
                               WHERE id = @Id ";

                var parameters = new DynamicParameters();
                parameters.Add("@Name", productPutRequest.Name);
                parameters.Add("@Valor", productPutRequest.Valor);
                parameters.Add("@CategoryId", productPutRequest.CategoryId);
                parameters.Add("@Id", productPutRequest.Id);

                _unitOfWork.Connection.Query(query, parameters, commandType: CommandType.Text);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProduct(int ProductId)
        {
            try
            {
                var query = $@"DELETE FROM product WHERE id = @Id ";

                _unitOfWork.Connection.Query(query,
                    new { Id = ProductId }, commandType: CommandType.Text);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
