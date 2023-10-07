using Microsoft.AspNetCore.Mvc;
using NguyenThanhDat.Web06.Application;

namespace NguyenThanhDat.Web06.Controllers.Base
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseCrudController<TEntityDto, TEntityCreateDto, TEntityUpdateDto> : BaseReadOnlyController<TEntityDto> where TEntityDto : class where TEntityCreateDto : class where TEntityUpdateDto : class
    {
        public readonly ICrudService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> CrudService;
        public BaseCrudController(ICrudService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> crudService) : base(crudService)
        {
            CrudService = crudService;
        }

        /// <summary>
        /// Tạo mới một bản ghi
        /// </summary>
        /// <returns>Bản ghi được thêm mới</returns>
        /// Created by: ntdat (18/08/2023)
        [HttpPost]
        public async Task<IActionResult> CreateAsync(TEntityCreateDto entityCreateDto)
        {
            var result = await CrudService.CreateAsync(entityCreateDto);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        /// Cập nhật bản ghi
        /// </summary>
        /// <param name="id">ID bản ghi</param>
        /// <param name="entity">Thông tin bản ghi</param>
        /// <returns>Kết quả</returns>
        /// Created by: ntdat (13/08/2023)
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync(string id, TEntityUpdateDto entityUpdateDto)
        {
            var result = await CrudService.UpdateAsync(Guid.Parse(id), entityUpdateDto);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Xóa danh hiệu thi đua
        /// </summary>
        /// <param name="id">ID danh hiệu thi đua</param>
        /// <returns>Kết quả</returns>
        /// Created by: ntdat (13/08/2023)
        [HttpDelete]
        [Route("id")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var result = await CrudService.DeleteAsync(Guid.Parse(id));
            return StatusCode(StatusCodes.Status200OK, result); 
        }

        /// <summary>
        /// Xóa nhiều danh hiệu thi đua
        /// </summary>
        /// <param name="id">ID danh hiệu thi đua</param>
        /// <returns>Kết quả</returns>
        /// Created by: ntdat (15/08/2023)
        [HttpDelete]
        public async Task<IActionResult> DeleteManyAsync(List<string> ids)
        {
            var result = await CrudService.DeleteManyAsync(ids.Select(id => Guid.Parse(id)).ToList());
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
