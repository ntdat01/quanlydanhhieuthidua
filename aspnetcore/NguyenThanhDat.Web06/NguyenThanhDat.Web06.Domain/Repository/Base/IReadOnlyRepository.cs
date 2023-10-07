using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Domain.Repository.Base
{
    public interface IReadOnlyRepository<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// Hàm lấy ra tất cả danh hiệu thi đua
        /// </summary>
        /// <param name="emulation">Danh sách danh hiệu thi đua</param>
        /// <returns>Danh sách danh hiệu thi đua</returns>
        /// Created by: ntdat (14/08/2023)
        Task<List<TEntity>> GetAllAsync();

        /// <summary>
        /// Lấy danh hiệu thi đua theo Id
        /// </summary>
        /// <param name="emulationId">Id danh hiệu thi đua</param>
        /// <returns>Danh hiệu thi đua</returns>
        Task<TEntity> GetAsync(Guid id);

        /// <summary>
        /// Hàm tìm danh hiệu thi đua có tồn tại không
        /// </summary>
        /// <param name="emulationId">Id danh hiệu thi đua</param>
        /// <returns>Nếu không tìm thấy trả về null</returns>
        /// Created by: ntdat (15/08/2023)
        Task<TEntity?> FindAsync(Guid id);

        /// <summary>
        /// Lấy danh sách bản ghi theo Id
        /// </summary>
        /// <param name="ids">Id các bản ghi</param>
        /// <returns>Danh sách bản ghi</returns>
        Task<List<TEntity>> GetByListIdAsync(List<Guid> ids);

        Task<(List<TEntity>, List<Guid>)> GetListByIdsAsync(List<Guid> ids);
    }
}
