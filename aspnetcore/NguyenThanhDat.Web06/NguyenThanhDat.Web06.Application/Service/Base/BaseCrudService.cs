using NguyenThanhDat.Web06.Domain;
using NguyenThanhDat.Web06.Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Application
{
    public abstract class BaseCrudService<TEntity, TEntityDto, TEntityCreateDto, TEntityUpdateDto> : BaseReadOnlyService<TEntity, TEntityDto>, ICrudService<TEntityDto, TEntityCreateDto, TEntityUpdateDto>
        where TEntityDto : class where TEntityCreateDto : class where TEntityUpdateDto : class
        where TEntity : IEntity
    {
        protected readonly ICrudRepository<TEntity> CrudRepository;
        private IEmulationRepository repository;

        protected BaseCrudService(ICrudRepository<TEntity> repository) : base(repository)
        {
            CrudRepository = repository;
        }

        public async Task<TEntityDto> CreateAsync(TEntityCreateDto entityCreateDto)
        {
            var entity = await MapEntityCreateDtoToEntity(entityCreateDto);
            await CrudRepository.CreateAsync(entity);
            var result = MapEntityToEntityDto(entity);
            return result;
        }
        public async Task<TEntityDto> UpdateAsync(Guid id, TEntityUpdateDto entityUpdateDto)
        {
            var entity = await MapEntityUpdateDtoToEntity(id,entityUpdateDto);
            await CrudRepository.UpdateAsync(entity);
            var result = MapEntityToEntityDto(entity);
            return result;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var entity = await CrudRepository.GetAsync(id);
            var result = await CrudRepository.DeleteAsync(entity);
            return result;
        }

        public async Task<int> DeleteManyAsync(List<Guid> ids)
        {
            var entities = await CrudRepository.GetByListIdAsync(ids);

            var entityIds = entities.Select(entity => entity.GetId()).ToList();

            var idsNotExist = new List<string>();

            ids.ForEach(id =>
            {
                if (!entityIds.Contains(id))
                {
                    idsNotExist.Add(id.ToString());
                }
            });
            if (idsNotExist.Count > 0)
            {
                throw new Exception("Có bản ghi không tồn tại");
            }
            var result = await CrudRepository.DeleteManyAsync(entities);
            return result;
        }
        public abstract Task<TEntity> MapEntityCreateDtoToEntity(TEntityCreateDto entityCreateDto);
        public abstract Task<TEntity> MapEntityUpdateDtoToEntity(Guid id, TEntityUpdateDto entityUpdateDto);
    }
}
