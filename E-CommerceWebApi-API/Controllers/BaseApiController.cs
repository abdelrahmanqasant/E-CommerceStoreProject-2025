using E_CommerceWebApi_Core.Entities;
using E_CommerceWebApi_Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mock_E_CommerceProject_API.RequestHelpers;

namespace E_CommerceWebApi_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected async Task<ActionResult> CreatePagedResult<T>
            (IGenericRepository<T> repo , ISpecification<T> spec , int pageIndex , int pageSize) where T : BaseEntity
        {
            var items = await repo.ListAsync(spec);
            var count = await repo.CountAsync(spec);
            var pagination = new Pagination<T>(pageIndex, pageSize, count, items);
            return Ok(pagination);
        }
    }
}
