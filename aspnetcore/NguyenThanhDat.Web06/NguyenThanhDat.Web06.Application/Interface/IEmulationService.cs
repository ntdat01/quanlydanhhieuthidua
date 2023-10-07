using NguyenThanhDat.Web06.Application;
using NguyenThanhDat.Web06.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Application
{
    public interface IEmulationService : ICrudService<EmulationDto, EmulationCreateDto, EmulationUpdateDto>
    {
        Task<bool> IsDuplicateAsync(string code);
    }
}
