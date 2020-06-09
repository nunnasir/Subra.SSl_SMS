using Autofac;
using Subra.SSL_SMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Subra.SSL_SMS.Web.Models
{
    public class SmsBaseModel : AdminBaseModel, IDisposable
    {
        protected readonly ISmsLogService _smsLogService;
        public SmsBaseModel(ISmsLogService smsLogService)
        {
            _smsLogService = smsLogService;
        }

        public SmsBaseModel()
        {
            _smsLogService = Startup.AutofacContainer.Resolve<ISmsLogService>();
        }

        public void Dispose()
        {
            _smsLogService?.Dispose();
        }
    }
}
