using Autofac;
using Subra.SSL_SMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Subra.SSL_SMS.Web.Models
{
    public class ContactBaseModel : AdminBaseModel, IDisposable
    {
        protected readonly IContactService _contactService;
        public ContactBaseModel(IContactService contactService)
        {
            _contactService = contactService;
        }

        public ContactBaseModel()
        {
            _contactService = Startup.AutofacContainer.Resolve<IContactService>();
        }

        public void Dispose()
        {
            _contactService?.Dispose();
        }
    }
}
