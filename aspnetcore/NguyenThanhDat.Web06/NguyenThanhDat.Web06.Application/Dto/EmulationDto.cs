using NguyenThanhDat.Web06.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Application
{
    public class EmulationDto
    {
        /// <summary>
        /// Id của danh hiệu thi đua
        /// </summary>
        /// Created by: ntdat (11/08/2023)
        public Guid EmulationId { get; set; }

        /// <summary>
        /// Mã danh hiệu thi đua
        /// </summary>
        /// Created by: ntdat (11/08/2023)
        public string EmulationCode { get; set; }

        /// <summary>
        /// Tên danh hiệu thi đua
        /// </summary>
        /// Created by: ntdat (11/08/2023)
        public string EmulationName { get; set; }

        /// <summary>
        /// Cấp khen thưởng
        /// </summary>
        /// Created by: ntdat (11/08/2023)
        public RewardLevel RewardLevel { get; set; }

        /// <summary>
        /// Đối tượng khen thưởng
        /// </summary>
        /// Created by: ntdat (11/08/2023)
        public RewardObject RewardObject { get; set; }

        /// <summary>
        /// Mã loại phong trào áp dụng
        /// </summary>
        /// Created by: ntdat (11/08/2023)
        public MovementType MovementType { get; set; }

        /// <summary>
        /// Mã trạng thái sử dụng
        /// </summary>
        /// Created by: ntdat (11/08/2023)
        public Inactive Inactive { get; set; }

        /// <summary>
        /// Mã tài nguyên sử dụng
        /// </summary>
        /// Created by: ntdat (11/08/2023)
        public IsSystem IsSystem { get; set; }

        /// <summary>
        /// Ghi chú
        /// </summary>
        /// Created by: ntdat (11/08/2023)
        public string? EmulationNote { get; set; }
    }
}
