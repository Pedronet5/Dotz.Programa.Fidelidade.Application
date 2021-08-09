using Dotz.Programa.Fidelidade.Domain.Interfaces;
using Dotz.Programa.Fidelidade.Domain.Requests;
using Dotz.Programa.Fidelidade.Domain.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Dotz.Programa.Fidelidade.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("GetCategory")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GetCategoryQueryResult), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,employee,manager")]
        public IActionResult GetCategory([FromQuery] int categoryId)
        {
            try
            {
                var result = _categoryRepository.GetCategory(categoryId);

                if (result == null)
                    return new NotFoundObjectResult($"Nenhuma categoria encontrada para o id informado: {categoryId}");
                else
                    return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllCategory")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(GetCategoryQueryResult), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,employee,manager")]
        public IActionResult GetAllCategory()
        {
            try
            {
                var result = _categoryRepository.GetAllCategory();

                if (result == null)
                    return new NotFoundObjectResult($"Nenhuma categoria encontrada");
                else
                    return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("PostCategory")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(bool), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,manager,employee")]
        public IActionResult PostCategory([FromQuery] CategoryRequest categoryRequest)
        {
            try
            {
                var result = _categoryRepository.PostCategory(categoryRequest);

                if (!result)
                    return new UnprocessableEntityObjectResult("Ocorreu um problema na gravação da categoria");
                else
                    return new OkObjectResult(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("PutCategory")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(bool), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,manager,employee")]
        public IActionResult PutCategory([FromQuery] CategoryPutRequest categoryPutRequest)
        {
            try
            {
                var result = _categoryRepository.PutCategory(categoryPutRequest);

                if (!result)
                    return new UnprocessableEntityObjectResult("Ocorreu um problema na atualização da categoria");
                else
                    return new OkObjectResult(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteCategory")]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(void), (int)StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(bool), (int)StatusCodes.Status200OK)]
        [Authorize(Roles = "admin,manager,employee")]
        public IActionResult DeleteCategory([FromQuery] int CategoryId)
        {
            try
            {
                var result = _categoryRepository.DeleteCategory(CategoryId);

                if (!result)
                    return new UnprocessableEntityObjectResult("Ocorreu um problema na exclusão da categoria");
                else
                    return new OkObjectResult(result);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
