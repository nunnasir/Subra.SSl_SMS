using Subra.SSL_SMS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subra.SSL_SMS.Framework
{
    public interface ISmsLogRepository : IRepository<SmsLog, int, FrameworkContext>
    {

    }
}
