using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSPattern.Library.NoMediatR
{
    public interface ICommandHandler<T, U>
    {
        T Handle(U request);
    }
}
