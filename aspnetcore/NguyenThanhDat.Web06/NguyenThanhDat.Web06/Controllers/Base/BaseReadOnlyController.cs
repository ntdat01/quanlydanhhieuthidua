using Microsoft.AspNetCore.Mvc;
using NguyenThanhDat.Web06.Application;

namespace NguyenThanhDat.Web06
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseReadOnlyController<TEntityDto> : ControllerBase where TEntityDto : class
    {
        public readonly IReadOnlyService<TEntityDto> ReadOnlyService;

        protected BaseReadOnlyController(IReadOnlyService<TEntityDto> readOnlyService)
        {
            ReadOnlyService = readOnlyService;
        }

        /// <summary>
        /// Hàm lấy danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// Created by: ntdat (18/08/2023)
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await ReadOnlyService.GetAllAsync();

            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        /// Lấy một bản ghi
        /// </summary>
        /// <param name="id">ID danh hiệu thi đua</param>
        /// <returns>Một bản ghi</returns>
        /// <exception cref="Exception"></exception>
        /// Created by: ntdat (18/08/2023)
        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var result = await ReadOnlyService.GetAsync(Guid.Parse(id));
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
