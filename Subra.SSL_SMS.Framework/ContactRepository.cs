using Subra.SSL_SMS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subra.SSL_SMS.Framework
{
    public class ContactRepository : Repository<Contact, int, FrameworkContext>, IContactRepository
    {
        public ContactRepository(FrameworkContext context) : base(context) { }
    }
}
