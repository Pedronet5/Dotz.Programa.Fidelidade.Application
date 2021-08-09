using Dotz.Programa.Fidelidade.Domain.Queries;
using Dotz.Programa.Fidelidade.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Programa.Fidelidade.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        GetCategoryQueryResult GetCategory(int categoryId);
        bool PostCategory(CategoryRequest categoryRequest);
        bool PutCategory(CategoryPutRequest categoryPutRequest);
        bool DeleteCategory(int CategoryId);
    }
}
