using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using NguyenThanhDat.Web06.Application;
using NguyenThanhDat.Web06.Controllers.Base;
using System.Data;

namespace NguyenThanhDat.Web06.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmulationsController : BaseCrudController<EmulationDto, EmulationCreateDto, EmulationUpdateDto>
    {
        private readonly IEmulationService _enulationService;
        public EmulationsController(IEmulationService emulationService) : base(emulationService)
        {
            _enulationService = emulationService;
        }

        [HttpGet]
        [Route("exist-code")]
        public async Task<bool> CheckExistCode(string code)
        {
            var result = await _enulationService.IsDuplicateAsync(code);

            return result;
        }
    }
}
