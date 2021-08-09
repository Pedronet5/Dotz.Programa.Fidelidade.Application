using Dapper;
using Dotz.Programa.Fidelidade.Domain.Interfaces;
using Dotz.Programa.Fidelidade.Domain.Queries;
using Dotz.Programa.Fidelidade.Domain.Requests;
using System;
using System.Data;
using System.Linq;

namespace Dotz.Programa.Fidelidade.Infrastructure.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public GetCategoryQueryResult GetCategory(int categoryId)
        {
            try
            {
                var query = $@"SELECT id AS Id, name AS Name
                               From category
                               WHERE id = @Id";

                var entity = _unitOfWork.Connection.Query<GetCategoryQueryResult>(query, new { Id = categoryId }, commandType: CommandType.Text);

                return entity.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool PostCategory(CategoryRequest categoryRequest)
        {
            try
            {
                var query = $@"INSERT INTO category (name, updatedate) 
                               VALUES (@Name, sysdate(3))";

                var parameters = new DynamicParameters();
                parameters.Add("@Name", categoryRequest.Name);

                _unitOfWork.Connection.Query(query, parameters, commandType: CommandType.Text);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool PutCategory(CategoryPutRequest categoryPutRequest)
        {
            try
            {
                var query = $@"UPDATE category set name = @Name, updatedate = sysdate(3)                             
                               WHERE id = @Id ";

                var parameters = new DynamicParameters();
                parameters.Add("@Id", categoryPutRequest.Id);
                parameters.Add("@Name", categoryPutRequest.Name);

                _unitOfWork.Connection.Query(query, parameters, commandType: CommandType.Text);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCategory(int CategoryId)
        {
            try
            {
                var query = $@"DELETE FROM category WHERE id = @Id ";

                _unitOfWork.Connection.Query(query,
                    new { Id = CategoryId }, commandType: CommandType.Text);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
