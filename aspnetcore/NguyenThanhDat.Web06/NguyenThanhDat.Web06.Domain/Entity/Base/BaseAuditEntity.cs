using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Domain
{
    public abstract class BaseAuditEntity
    {
        /// <summary>
        /// Ngày tạo
        /// </summary>
        /// Created by: ntdat (11/08/2023)
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Được tạo bởi ai
        /// </summary>
        /// Created by: ntdat (11/08/2023)
        public string CreatedBy { get; set; }
        /// <summary>
        /// Sửa đổi bởi ai
        /// </summary>
        /// Created by: ntdat (11/08/2023)
        public string ModifiedBy { get; set; }
        /// <summary>
        /// Ngày sửa đổi
        /// </summary>
        /// Created by: ntdat (11/08/2023)
        public DateTime ModifiedDate { get; set; }
    }
}
