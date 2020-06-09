using Subra.SSL_SMS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subra.SSL_SMS.Framework
{
    public class SmsUnitOfWork : UnitOfWork, ISmsUnitOfWork
    {
        public IGroupRepository GroupRepository { get; set; }
        public IContactRepository ContactRepository { get; set; }
        public ISmsLogRepository SmsLogRepository { get; set; }
        public SmsUnitOfWork(FrameworkContext dbContext,
            IGroupRepository groupRepository,
            IContactRepository contactRepository,
            ISmsLogRepository smsLogRepository)
            : base(dbContext)
        {
            GroupRepository = groupRepository;
            ContactRepository = contactRepository;
            SmsLogRepository = smsLogRepository;
        }
    }
}
