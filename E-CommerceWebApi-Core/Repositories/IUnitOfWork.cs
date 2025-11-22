using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebApi_Core.Repositories
{
    public interface IUnitOfWork
    {
     
        Task<bool> Complete();
    }
}
