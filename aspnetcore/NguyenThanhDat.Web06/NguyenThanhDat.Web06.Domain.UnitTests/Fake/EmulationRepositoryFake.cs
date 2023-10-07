using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Domain.UnitTests.Fake
{
    public class EmulationRepositoryFake : IEmulationRepository
    {
        public int TotalCall { get; set; }
        public Task<int> CreateAsync(Emulation entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Emulation entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteManyAsync(List<Emulation> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Emulation?> FindAsync(Guid id)
        {
            throw new NotImplementedException();
        }   

        public Task<Emulation?> FindByCodeAsync(string code)
        {
            TotalCall++;
            return Task.FromResult<Emulation?>(null);
        }

        public Task<List<Emulation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Emulation> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Emulation>> GetByListIdAsync(List<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Emulation entity)
        {
            throw new NotImplementedException();
        }
    }
}
