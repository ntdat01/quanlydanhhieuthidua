using Dapper;
using MySqlConnector;
using NguyenThanhDat.Web06.Application;
using NguyenThanhDat.Web06.Domain;
using NguyenThanhDat.Web06.Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Infrastructure
{
    public abstract class BaseReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : IEntity
    {
        protected readonly IUnitOfWork Uow;
        protected virtual string TableName { get; set; } = typeof(TEntity).Name;
        protected BaseReadOnlyRepository(IUnitOfWork uow)
        {
            Uow = uow;
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            var sql = $"SELECT * FROM {TableName}";

            var result = await Uow.Connection.QueryAsync<TEntity>(sql, transaction: Uow.Transaction);
            return result.ToList();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            var entity = await FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException();
            }
            return entity;
        }
        public async Task<TEntity?> FindAsync(Guid id)
        {
        
            var sql = $"SELECT * FROM {TableName} WHERE {TableName}Id = @id;";

            var param = new DynamicParameters();

            param.Add("@id", id);

            var result = await Uow.Connection.QuerySingleAsync<TEntity>(sql, param, transaction: Uow.Transaction);

            return result;
        }

        public async Task<List<TEntity>> GetByListIdAsync(List<Guid> ids)
        {
            
            var sql = $"SELECT * FROM {TableName} WHERE {TableName}Id IN @Ids;";

            var param = new DynamicParameters();
            param.Add("@Ids", ids);

            var result = await Uow.Connection.QueryAsync<TEntity>(sql, param, transaction: Uow.Transaction);
            return result.ToList();
        }

        public Task<(List<TEntity>, List<Guid>)> GetListByIdsAsync(List<Guid> ids)
        {
            throw new NotImplementedException();
        }
    }
}
