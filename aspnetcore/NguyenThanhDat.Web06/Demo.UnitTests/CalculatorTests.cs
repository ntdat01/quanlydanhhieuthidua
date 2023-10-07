using NguyenThanhDat.Web06;

namespace Demo.UnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        /// <summary>
        /// Hàm test tổng hai số nguyên
        /// </summary>
        /// <param name="x">toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <param name="expectedResult">Kết quả mong đợi</param>
        /// CreatedBy: ntdat (11/08/2023)
        [TestCase(1, 2, 3)]
        [TestCase(2, 3, 5)]
        [TestCase(-1, 7, 6)]
        [TestCase(int.MaxValue , int.MaxValue, int.MaxValue * (long)2)]
        public void Add_ValidInput_AddTwoNumber(int x, int y, long expectedResult)
        {
            // Arrange
           
            // Act
            var actuaResult = new Calculator().Add(x, y);
            // Assert
            Assert.That(actuaResult, Is.EqualTo(expectedResult));
        }
        /// <summary>
        /// Hàm test hiệu hai số nguyên
        /// </summary>
        /// <param name="x">toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <param name="expectedResult">Kết quả mong đợi</param>
        /// CreatedBy: ntdat (11/08/2023)
        [TestCase(1, 2, -1)]
        [TestCase(2, 3, -1)]
        [TestCase(-1, 7, -8)]
        [TestCase(int.MaxValue, int.MinValue, int.MaxValue * (long)2 + 1)]
        public void Sub_ValidInput_SubTwoNumber(int x, int y, long expectedResult)
        {
            // Arrange

            // Act
            var actuaResult = new Calculator().Sub(x, y);
            // Assert
            Assert.That(actuaResult, Is.EqualTo(expectedResult));
        }
        /// <summary>
        /// Hàm tets tích hai số nguyên
        /// </summary>
        /// <param name="x">toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <param name="expectedResult">Kết quả mong đợi</param>
        /// CreatedBy: ntdat (11/08/2023)
        [TestCase(1, 2, 2)]
        [TestCase(2, 3, 6)]
        [TestCase(-1, 7, -7)]
        [TestCase(int.MaxValue, int.MinValue, int.MaxValue * (long) int.MinValue)]
        public void Mul_ValidInput_SuccessResult(int x, int y, long expectedResult)
        {
            // Arrange

            // Act
            var actuaResult = new Calculator().Mul(x, y);
            // Assert
            Assert.That(actuaResult, Is.EqualTo(expectedResult));
        }
        /// <summary>
        /// Hàm test chia hai số nguyên
        /// </summary>
        /// <param name="x">toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <param name="expectedResult">Kết quả mong đợi</param>
        /// CreatedBy: ntdat (11/08/2023)
        public void Div_ZeroInput_ThrowExeption()
        {
            // Arrange
            var y = 0;
            var x = 1;
            var expectedMessage = "Không thể chia cho 0";
            //Act & Assert
            var exception = Assert.Throws<Exception>(()=>new Calculator().Div(x, y));
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }
        [TestCase(1, 2, 0.5f)]
        [TestCase(1, 3, 1/(float)3)]
        [TestCase(int.MaxValue, 3, int.MaxValue/(double)3)]
        public void Div_ValidInput_Success(int x, int y, double expectedResult)
        {
            //Act
            var actuaResult = new Calculator().Div(x, y);
            Assert.That( Math.Abs(actuaResult- expectedResult), Is.LessThan(10e-3));
        }
        /// <summary>
        /// hàm test tổng chuỗi các số nguyên 
        /// </summary>
        /// <param name="input">Chuỗi số nguyên</param>
        /// <param name="expectedResult">Kết quả mong đợi</param>
        /// CreatedBy: ntdat (13/08/2023)
        /// Chuỗi "" trả về 0
        [TestCase("", 0)]
        ///Chuỗi "1" trả về 1
        [TestCase("1", 1)]
        ///Chuỗi "1,2,3" trả về 6
        [TestCase("1,2,3", 6)]
        ///Chuỗi "1, 2, 3" trả về 6
        [TestCase("1, 2, 3", 6)]
        public void Add_ValidInput_SumNumbersString(string input, long expectedResult)
        {
            //Act
            var actuaResult = new Calculator().Add(input);

            //Assert 
            Assert.That(actuaResult, Is.EqualTo(expectedResult));
        }
        /// <summary>
        /// Hàm test tổng các số nguyên từ chuỗi có giá trị âm
        /// </summary>
        /// CreatedBy: ntdat (13/08/2023)
        [Test]
        public void Add_NegativeNumberInput_ThrowExeption()
        {
            // Arrage
            var input = "1,-2,-3";
            var expectedMessage = "Không chấp nhận toán tử âm: -2, -3";

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => new Calculator().Add(input));

            // Assert
            Assert.That(exception.Message, Is.EqualTo(expectedMessage));
        }
    }
}