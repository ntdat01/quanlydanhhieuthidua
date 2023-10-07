using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Domain
{
    public class EmulationManager:IEmulationManager
    {
        private readonly IEmulationRepository _emulationRepository;

        public EmulationManager(IEmulationRepository emulationRepository)
        {
            _emulationRepository = emulationRepository;
        }

        public async Task CheckDuplicateCodeAsync(string code)
        {
            Emulation? emulation = null;
            emulation = await _emulationRepository.FindByCodeAsync(code);
            if (emulation is not null)
            {
                throw new ConflictException("Trùng mã nhân viên");
            }
        }   
    }
}
