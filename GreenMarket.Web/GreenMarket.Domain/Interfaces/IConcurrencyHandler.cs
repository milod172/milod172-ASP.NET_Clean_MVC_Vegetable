using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenMarket.Domain.Interfaces
{
    public interface IConcurrencyHandler<TEntity>
    {
        void SetRowVersion(TEntity entity, byte[] version);

        bool IsDbUpdateConcurrencyException(Exception ex);
    }
}
