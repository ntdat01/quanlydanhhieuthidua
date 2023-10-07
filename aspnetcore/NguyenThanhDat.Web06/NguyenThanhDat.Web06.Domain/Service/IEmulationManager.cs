using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Domain
{
    public interface IEmulationManager
    {
        Task CheckDuplicateCodeAsync(string code);
    }
}
