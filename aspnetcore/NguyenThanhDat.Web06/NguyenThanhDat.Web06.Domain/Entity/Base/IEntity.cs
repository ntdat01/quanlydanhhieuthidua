using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenThanhDat.Web06.Domain
{
    public interface IEntity
    {
        Guid GetId();
        void SetId(Guid id);
    }
}
