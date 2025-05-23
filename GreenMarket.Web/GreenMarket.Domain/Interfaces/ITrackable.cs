using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMarket.Domain.Interfaces
{
    public interface ITrackable
    {
        byte[] RowVersion { get; set; }

        DateTime CreatedTime { get; set; }

        DateTime? UpdatedTime { get; set; }
    }

}
