using NguyenThanhDat.Web06.Domain.UnitTests.Fake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Domain.UnitTests.Service
{
    [TestFixture]
    public class EmulationManagerTests
    {
        [Test]
        //tên hàm, dữ liệu đầu vào, đầu ra
        public async Task CheckDuplicateCodeAsync_EmulationNotExist_Success()
        {
            // Arrange (chuẩn bị kịch bản)

            string code = "DH-Hello";
            
            var emulationRepositoryFake = new EmulationRepositoryFake();

            var emulationManager = new EmulationManager(emulationRepositoryFake);

            // Act

            await emulationManager.CheckDuplicateCodeAsync(code);

            // Assert

            Assert.That(emulationRepositoryFake.TotalCall, Is.EqualTo(1));
        }

        [Test]
        //tên hàm, dữ liệu đầu vào, đầu ra
        public async Task CheckDuplicateCodeAsync_EmulationExist_Exception()
        {
            // Arrange (chuẩn bị kịch bản)

            string code = "DH-Tontai";

            var emulationRepositoryFake = new EmulationRepositoryFake2();

            var emulationManager = new EmulationManager(emulationRepositoryFake);

            // Act
            var handler = async () => await emulationManager.CheckDuplicateCodeAsync(code);
            

            // Assert

            Assert.ThrowsAsync<ConflictException>(async()=>await handler());
            Assert.That(emulationRepositoryFake.TotalCall, Is.EqualTo(1));
        }
    }
}
