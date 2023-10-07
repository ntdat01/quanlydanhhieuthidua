using NguyenThanhDat.Web06.Domain;
using NguyenThanhDat.Web06.Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Application
{
    public abstract class BaseReadOnlyService<TEntity, TEntityDto> : IReadOnlyService<TEntityDto>
        where TEntity : IEntity
        where TEntityDto : class
    {
        protected readonly IReadOnlyRepository<TEntity> ReadOnlyRepository;

        public BaseReadOnlyService(IReadOnlyRepository<TEntity> repository)
        {
            ReadOnlyRepository = repository;
        }

        public async Task<List<TEntityDto>> GetAllAsync()
        {
            var entities = await ReadOnlyRepository.GetAllAsync();
            var result = entities.Select(entity => MapEntityToEntityDto(entity)).ToList();
            return result;
        }

        public async Task<TEntityDto> GetAsync(Guid id)
        {
            var entity = await ReadOnlyRepository.GetAsync(id);
            var result = MapEntityToEntityDto(entity);
            return result;
        }
        public abstract TEntityDto MapEntityToEntityDto(TEntity entity);

    }
}
