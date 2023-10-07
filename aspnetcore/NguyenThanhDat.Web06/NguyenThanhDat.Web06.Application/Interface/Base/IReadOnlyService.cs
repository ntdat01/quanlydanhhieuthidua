using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Application
{
    public interface IReadOnlyService<TEntityDto> where TEntityDto : class
    {
        /// <summary>
        /// Hàm thêm lấy ra tất cả danh hiệu thi đua
        /// </summary>
        /// <param name="entity">Danh sách danh hiệu thi đua</param>
        /// <returns>Danh sách danh hiệu thi đua</returns>
        /// Created by: ntdat (18/08/2023) 
        Task<List<TEntityDto>> GetAllAsync();

        /// <summary>
        /// Hàm lấy danh hiệu thi đua theo Id
        /// </summary>
        /// <param name="entityId">Id danh hiệu thi đua</param>
        /// <returns>Danh hiệu thi đua</returns>
        Task<TEntityDto> GetAsync(Guid id);
    }
}
