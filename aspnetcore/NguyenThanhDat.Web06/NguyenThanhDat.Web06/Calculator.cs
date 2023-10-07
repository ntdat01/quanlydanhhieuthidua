namespace NguyenThanhDat.Web06
{
    public class Calculator
    {
        /// <summary>
        /// Hàm cộng 2 số nguyên
        /// </summary>
        /// <param name="x"> Toán hạng 1</param>
        /// <param name="y"> Toán hạng 2</param>
        /// <returns>Tổng 2 số nguyên</returns>
        /// CreatedBy: ntdat (11/08/2023)
        public long Add(int x, int y)
        {
            return x + (long)y;
        }

        /// <summary>
        /// Hàm hiệu hai số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Hiệu 2 số</returns>
        /// CreatedBy: ntdat (11/08/2023)
        public long Sub(int x, int y)
        {
            return x - (long)y;
        }

        /// <summary>
        /// Hàm tích hai số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Tích 2 số</returns>
        /// CreatedBy: ntdat (11/08/2023)
        public long Mul(int x, int y)
        {
            return x * (long)y;
        }

        /// <summary>
        /// Hàm chia hai số nguyên
        /// </summary>
        /// <param name="x">Toán hạng 1</param>
        /// <param name="y">Toán hạng 2</param>
        /// <returns>Thương số</returns>
        /// CreatedBy: ntdat (11/08/2023)
        public double Div(int x, int y)
        {
            if (y == 0)
            {
                throw new Exception("Không thể chia cho 0");
            }
            return x / (double)y;

        }

        /// <summary>
        /// Hàm tính tổng các số nguyên được truyền từ một chuỗi
        /// </summary>
        /// <param name="input">Chuỗi các số nguyên</param>
        /// <returns>Tổng các số nguyên</returns>
        /// CreatedBy: ntdat (13/08/2023)
        public long Add(string input)
        {
            /// Chuỗi rỗng trả về 0
            if (string.IsNullOrWhiteSpace(input))
            {
                return 0;
            }
            long sum = 0;
            /// Tách chuỗi thành một mảng
            var numbersString = input.Split(',');
            /// Khởi tạo một danh sách List các phần tử
            List<int> numbersInt = new List<int>();
            List<string> numbersNegative = new List<string>();
            foreach (var number in numbersString)
            {
                /// Loại bỏ khoảng trắng 2 đầu
                var numberValue = int.Parse(number.Trim());
                if (numberValue < 0)
                {
                    numbersNegative.Add(number);
                }
                numbersInt.Add(numberValue);
            }
            ///Kiểm tra có phần tử âm hay không
            if (numbersNegative.Count > 0)
            {
                throw new Exception($"Không chấp nhận toán tử âm: {string.Join(", ", numbersNegative)}");
            }
            numbersInt.ForEach(numberValue => { sum += numberValue; });
            return sum;
        }
    }
}
