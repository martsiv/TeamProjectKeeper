using data_access.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Repositories
{
    public interface IUoW
    {
        //For example:
        //IRepository<MyClass> MyClassRepo { get; }
        void Save();
    }
}
