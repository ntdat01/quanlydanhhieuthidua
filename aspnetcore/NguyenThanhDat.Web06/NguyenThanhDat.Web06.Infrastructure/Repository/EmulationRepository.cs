using Dapper;
using MySqlConnector;
using NguyenThanhDat.Web06.Application;
using NguyenThanhDat.Web06.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace NguyenThanhDat.Web06.Infrastructure.Repository
{
    public class EmulationRepository : BaseCrudRepository<Emulation>, IEmulationRepository
    {
        public EmulationRepository(IUnitOfWork uow) : base(uow)
        {
        }

        public async Task<Emulation?> FindByCodeAsync(string code)
        {
            var sql = $"SELECT * FROM Emulation WHERE EmulationCode = @code;";

            var param = new DynamicParameters();
            param.Add("@code", code);

            var result = await Uow.Connection.QuerySingleOrDefaultAsync<Emulation>(sql, param, transaction: Uow.Transaction);

            return result;
        }
    }
}
