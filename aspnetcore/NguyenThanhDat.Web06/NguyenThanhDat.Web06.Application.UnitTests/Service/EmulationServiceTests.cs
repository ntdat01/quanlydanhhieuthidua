using AutoMapper;
using NguyenThanhDat.Web06.Domain;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Application.UnitTests
{
    [TestFixture]
    public class EmulationServiceTests
    {
        private IEmulationRepository _emulationRepository { get; set; }
        private IMapper _mapper { get; set; }
        private IEmulationManager _emulationManager { get; set; }
        private EmulationService _emulationService { get; set; }

        /// <summary>
        /// Thiết lập các đối tượng chung
        /// </summary>
        /// Created by: ntdat (25/08/2023)
        [SetUp]
        public void SetUp()
        {
            _emulationRepository = Substitute.For<IEmulationRepository>();
            _mapper = Substitute.For<IMapper>();
            _emulationManager = Substitute.For<IEmulationManager>();
            _emulationService = new EmulationService(_emulationRepository, _mapper, _emulationManager);
        }

        /// <summary>
        /// Test DuplicateCode
        /// Đầu vào không tồn tại Emulation
        /// Đầu ra dự kiến là False
        /// </summary>
        /// Created by: ntdat (25/08/2023)
        [Test]
        /// Tên hàm, dữ liệu đầu vào, đầu ra
        public async Task IsDuplicateCodeAsync_EmulationNotExist_ReturnFalse()
        {
            /// Arrange (chuẩn bị kịch bản)

            var code = "DH-Khongtontai";

            _emulationRepository.FindByCodeAsync(code).ReturnsNull();

            var actualResult = await _emulationService.IsDuplicateAsync(code);

            /// Assert
            Assert.That(actualResult, Is.False);
            await _emulationRepository.Received(1).FindByCodeAsync(code);
        }

        /// <summary>
        /// Test DuplicateCode
        /// Trường hợp đầu vào là Emulaton
        /// Đầu ra dự kiến là True
        /// </summary>
        /// Created by: ntdat (25/08/2023)
        ///
        [Test]
        /// Tên hàm, dữ liệu đầu vào, đầu ra
        public async Task IsDuplicateCodeAsync_EmulationNotExist_ReturnTrue()
        {
            /// Arrange (chuẩn bị kịch bản)

            var code = "DH-Khongtontai";

            var emulation = new Emulation();

            _emulationRepository.FindByCodeAsync(code).Returns(emulation);

            /// Act

            var actualResult = await _emulationService.IsDuplicateAsync(code);

            /// Assert
            Assert.That(actualResult, Is.True);
            await _emulationRepository.Received(1).FindByCodeAsync(code);
        }

        /// <summary>
        /// Test Delete Many
        /// Đầu vào là List 10 id
        /// Đầu ra dự kiến là xóa 10 bản ghi
        /// </summary>
        /// Created by: ntdat (25/08/2023)
        [Test]
        public async Task DeleteManyAsync_List10Ids_Delete10Entity()
        {
            /// Arrange
            var ids = new List<Guid>();

            for (int i = 0; i < 10; i++)
            {
                ids.Add(Guid.NewGuid());
            }

            var emulations = ids.Select(id => new Emulation()
            {
                EmulationId = id,
            }).ToList();
            _emulationRepository.GetListByIdsAsync(ids).Returns((emulations, new List<Guid>()));
            _emulationRepository.DeleteManyAsync(emulations).Returns(emulations.Count);
            var expectedResult = 10;

            /// Act
            var actualResult = await _emulationService.DeleteManyAsync(ids);

            /// Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));

            await _emulationRepository.Received(1).DeleteManyAsync(Arg.Any<List<Emulation>>());
        }
        /// <summary>
        /// Test Delete Many
        /// Đầu vào là List 10 id
        /// Đầu ra dự kiến là Exception
        /// </summary>
        /// Created by: ndat (25/08/2023)
        [Test]
        public async Task DeleteManyAsync_List10Ids8Entity_Exception()
        {
            /// Arrange
            var successIds = new List<Guid>();
            var errorIds = new List<Guid>();
            var ids = new List<Guid>();

            for (int i = 0; i < 8; i++)
            {
                successIds.Add(Guid.NewGuid());
            }

            for (int i = 0; i < 2; i++)
            {
                errorIds.Add(Guid.NewGuid());
            }
            ids = successIds.Concat(errorIds).ToList();
            var emulations = successIds.Select(id => new Emulation()
            {
                EmulationId = id,
            }).ToList();
            _emulationRepository.GetListByIdsAsync(ids).Returns((emulations, errorIds));
            var expectedMessageResult = $"Không tìm thấy: {string.Join(", ", errorIds)}";

            /// Act
            var handler = async () => await _emulationService.DeleteManyAsync(ids);

            /// Assert
            var exception = Assert.ThrowsAsync<Exception>(async () => await handler());
            Assert.That(exception.Message, Is.EqualTo(expectedMessageResult));

            await _emulationRepository.Received(1).DeleteManyAsync(Arg.Any<List<Emulation>>());
        }
    }
}
