using Dotz.Programa.Fidelidade.Domain.Queries;
using Dotz.Programa.Fidelidade.Domain.Requests;
using System.Collections.Generic;

namespace Dotz.Programa.Fidelidade.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        GetCategoryQueryResult GetCategory(int categoryId);
        IEnumerable<GetCategoryQueryResult> GetAllCategory();
        bool PostCategory(CategoryRequest categoryRequest);
        bool PutCategory(CategoryPutRequest categoryPutRequest);
        bool DeleteCategory(int CategoryId);
    }
}
