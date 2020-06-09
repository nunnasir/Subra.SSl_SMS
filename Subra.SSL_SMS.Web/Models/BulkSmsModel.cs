using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Subra.SSL_SMS.Web.Models
{
    public class BulkSmsModel : SmsBaseModel
    {
        [Required]
        [ValidateContactIds]
        public string ContatId { get; set; }
        [Required]
        public string Messages { get; set; }

        public void SendSms()
        {
            //var contact = new Contact
            //{
            //    ContatId = this.ContatId,
            //    GroupId = this.GroupId
            //};
            //_contactService.CreateContact(contact);
        }
    }
}
