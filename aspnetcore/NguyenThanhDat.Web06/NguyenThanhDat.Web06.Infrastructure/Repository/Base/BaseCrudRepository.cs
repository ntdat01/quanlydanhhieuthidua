using Dapper;
using MySqlConnector;
using NguyenThanhDat.Web06.Application;
using NguyenThanhDat.Web06.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Infrastructure
{
    public abstract class BaseCrudRepository<TEntity> : BaseReadOnlyRepository<TEntity>, ICrudRepository<TEntity> where TEntity : IEntity
    {
        protected BaseCrudRepository(IUnitOfWork uow) : base(uow)
        {
        }

        public async Task<int> CreateAsync(TEntity entity)
        {
            var props = entity.GetType().GetProperties();
            var param = new DynamicParameters();
            var columns = new List<string>();
            var paramsName = new List<string>();
            foreach (var prop in props)
            {
                var propName = prop.Name;
                param.Add($"{propName}", prop.GetValue(entity));
                columns.Add(propName);
                paramsName.Add($"@{propName}");
            }
            var columnsString = string.Join(", ", columns);
            var paramsNameString = string.Join(", ", paramsName);
            var sql = $"INSERT INTO {TableName} ({columnsString}) VALUES ({paramsNameString})";
            var result = await Uow.Connection.ExecuteAsync(sql, param, transaction: Uow.Transaction);
            return result;
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            var props = entity.GetType().GetProperties();
            var param = new DynamicParameters();
            var valuePair = new List<string>();
            foreach (var prop in props)
            {
                var propName = prop.Name;
                param.Add($"{propName}", prop.GetValue(entity));
                valuePair.Add($"{propName} = @{propName}");
            }
            var valuePairString = string.Join(", ", valuePair);
            var sql = $"UPDATE {TableName} SET {valuePairString} WHERE {TableName}Id=@{TableName}Id";
            var result = await Uow.Connection.ExecuteAsync(sql, param, transaction: Uow.Transaction);
            return result;
        }
        public async Task<int> DeleteAsync(TEntity entity)
        {
            var sql = $"DELETE FROM {TableName} WHERE {TableName}Id = @id;";

            var param = new DynamicParameters();

            param.Add("@id", entity.GetId());

            var result = await Uow.Connection.ExecuteAsync(sql, param, transaction: Uow.Transaction);

            return result;
        }

        public async Task<int> DeleteManyAsync(List<TEntity> entities)
        {
            var sql = $"DELETE FROM {TableName} WHERE {TableName}Id IN @ids;";

            var param = new DynamicParameters();

            param.Add("ids", entities.Select(entity => entity.GetId()));

            var result = await Uow.Connection.ExecuteAsync(sql, param, transaction: Uow.Transaction);

            return result;
        }
    }

}
