using System;
using System.Collections.Generic;
using System.Text;

namespace Subra.SSL_SMS.Framework
{
    public interface ISmsLogService : IDisposable
    {
        void CreateSmsLog(SmsLog smsLog);
        IList<string> GetContactsByGroup(int groupId);
        IList<Group> GetGroups();
    }
}
