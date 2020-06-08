using System;
using System.Collections.Generic;
using System.Text;

namespace Subra.SSL_SMS.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
