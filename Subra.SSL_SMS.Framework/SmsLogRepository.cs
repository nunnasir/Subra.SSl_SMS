using Subra.SSL_SMS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subra.SSL_SMS.Framework
{
    public class SmsLogRepository : Repository<SmsLog, int, FrameworkContext>, ISmsLogRepository
    {
        public SmsLogRepository(FrameworkContext context) : base(context)
        {
        }
    }
}
