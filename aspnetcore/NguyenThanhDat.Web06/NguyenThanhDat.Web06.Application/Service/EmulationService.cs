using AutoMapper;
using NguyenThanhDat.Web06.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Application
{
    public class EmulationService : BaseCrudService<Emulation, EmulationDto, EmulationCreateDto, EmulationUpdateDto>, IEmulationService
    {
        private readonly IEmulationRepository _emulationRepository;
        private readonly IMapper _mapper;
        private readonly IEmulationManager _emulationManager;

        public EmulationService(IEmulationRepository emulationRepository, IMapper mapper, IEmulationManager emulationManager) : base(emulationRepository)
        {
            _emulationRepository = emulationRepository;
            _mapper = mapper;
            _emulationManager = emulationManager;
        }

        public async Task<bool> IsDuplicateAsync(string code)
        {
           
            var emulation = await _emulationRepository.FindByCodeAsync(code);

            if (emulation == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override async Task<Emulation> MapEntityCreateDtoToEntity(EmulationCreateDto entityCreateDto)
        {
            await _emulationManager.CheckDuplicateCodeAsync(entityCreateDto.EmulationCode);  
            var emulationCreate = _mapper.Map<Emulation>(entityCreateDto);
            emulationCreate.EmulationId = Guid.NewGuid();
            emulationCreate.CreatedDate = DateTime.Now;
            return emulationCreate;
        }
        public override async Task<Emulation> MapEntityUpdateDtoToEntity(Guid id, EmulationUpdateDto entityUpdateDto)
        {
            var emulation = await _emulationRepository.GetAsync(id);
            if(emulation.EmulationCode != entityUpdateDto.EmulationCode)
            {
            await _emulationManager.CheckDuplicateCodeAsync(entityUpdateDto.EmulationCode);
            }    

            var emulationUpdate = _mapper.Map<Emulation>(entityUpdateDto);
            emulationUpdate.EmulationId = id;
            emulationUpdate.ModifiedBy = "NTDat";
            emulationUpdate.ModifiedDate = DateTime.Now;

            return emulationUpdate;
        }

        public override EmulationDto MapEntityToEntityDto(Emulation entity)
        {
            var entityDto = _mapper.Map<EmulationDto>(entity);
            return entityDto;
        }
    }
}
