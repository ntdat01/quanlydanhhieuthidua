using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Application
{
    public interface ICrudService<TEntityDto, TEntityCreateDto, TEntityUpdateDto> : IReadOnlyService<TEntityDto> where TEntityDto : class where TEntityCreateDto : class where TEntityUpdateDto : class
    {
        /// <summary>
        /// Hàm thêm mới một bản ghi
        /// </summary>
        /// <param name="entityUpdateDto">Bản ghi</param>
        /// <returns>Bản ghi được thêm</returns>
        /// Created by: ntdat (18/08/2023)
        Task<TEntityDto> CreateAsync(TEntityCreateDto entityUpdateDto);

        /// <summary>
        /// Hàm cập nhật một bản ghi
        /// </summary>
        /// <param name="entityUpdateDto">Bản ghi</param>
        /// <returns>Bản ghi được cập nhật</returns>
        /// Created by: ntdat (18/08/2023)
        Task<TEntityDto> UpdateAsync(Guid id, TEntityUpdateDto entityUpdateDto);

        /// <summary>
        /// Hàm xóa một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi</param>
        /// <returns>Xóa bản ghi</returns>
        /// Created by: ntdat (18/08/2023)
        Task<int> DeleteAsync(Guid id);

        /// <summary>
        /// Hàm xóa nhiều bản ghi
        /// </summary>
        /// <param name="ids">Id các bản ghi</param>
        /// <returns>Số lượng bản ghi đã xóa</returns>
        /// Created by: ntdat (15/08/2023)
        Task<int> DeleteManyAsync(List<Guid> ids);
    }
}
