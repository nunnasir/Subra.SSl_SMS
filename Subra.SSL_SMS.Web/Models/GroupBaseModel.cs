using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Subra.SSL_SMS.Framework;

namespace Subra.SSL_SMS.Web.Models
{
    public class GroupBaseModel : AdminBaseModel, IDisposable
    {
        protected readonly IGroupService _groupService;
        public GroupBaseModel(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public GroupBaseModel()
        {
            _groupService = Startup.AutofacContainer.Resolve<IGroupService>();
        }

        public void Dispose()
        {
            _groupService?.Dispose();
        }
    }
}
