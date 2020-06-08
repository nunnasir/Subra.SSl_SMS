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
        public SmsUnitOfWork(FrameworkContext dbContext,
            IGroupRepository groupRepository,
            IContactRepository contactRepository)
            : base(dbContext)
        {
            GroupRepository = groupRepository;
            ContactRepository = contactRepository;
        }
    }
}
