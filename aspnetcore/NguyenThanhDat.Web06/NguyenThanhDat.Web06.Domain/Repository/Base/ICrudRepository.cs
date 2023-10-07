using NguyenThanhDat.Web06.Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Domain
{
    public interface ICrudRepository<TEntity> : IReadOnlyRepository<TEntity>
        where TEntity : IEntity
    {
        /// <summary>
        /// Hàm thêm mới một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi</param>
        /// <returns>Bản ghi được thêm</returns>
        /// Created by: ntdat (18/08/2023)
        Task<int> CreateAsync(TEntity entity);

        /// <summary>
        /// Hàm cập nhật một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi</param>
        /// <returns>Bản ghi được cập nhật</returns>
        /// Created by: ntdat (18/08/2023)
        Task<int> UpdateAsync(TEntity entity);

        /// <summary>
        /// Hàm xóa một bản ghi
        /// </summary>
        /// <param name="entity">Bản ghi</param>
        /// <returns>Xóa bản ghi</returns>
        /// Created by: ntdat (18/08/2023)
        Task<int> DeleteAsync(TEntity entity);

        /// <summary>
        /// Hàm xóa nhiều bản ghi
        /// </summary>
        /// <param name="entities">Danh sách bản ghi</param>
        /// <returns>Số lượng bản ghi đã xóa</returns>
        /// Created by: ntdat (18/08/2023)
        Task<int> DeleteManyAsync(List<TEntity> entities);
    }
}
