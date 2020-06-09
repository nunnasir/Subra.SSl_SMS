using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Subra.SSL_SMS.Framework
{
    public class SmsLogService : ISmsLogService
    {
        private ISmsUnitOfWork _smsUnitOfWork;
        public SmsLogService(ISmsUnitOfWork smsUnitOfWork)
        {
            _smsUnitOfWork = smsUnitOfWork;
        }

        public void CreateSmsLog(SmsLog smsLog)
        {
            _smsUnitOfWork.SmsLogRepository.Add(smsLog);
            _smsUnitOfWork.Save();
        }

        public void Dispose()
        {
            _smsUnitOfWork?.Dispose();
        }

        public IList<Group> GetGroups()
        {
            return _smsUnitOfWork.GroupRepository.GetAll();
        }

        public IList<string> GetContactsByGroup(int groupId)
        {
            return _smsUnitOfWork.ContactRepository.Get(g => g.GroupId == groupId).Select(c => c.ContatId).ToList();
        }
    }
}
