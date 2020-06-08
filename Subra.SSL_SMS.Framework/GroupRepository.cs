using Subra.SSL_SMS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subra.SSL_SMS.Framework
{
    public class GroupRepository : Repository<Group, int, FrameworkContext>, IGroupRepository
    {
        public GroupRepository(FrameworkContext context) : base(context) { }
    }
}
