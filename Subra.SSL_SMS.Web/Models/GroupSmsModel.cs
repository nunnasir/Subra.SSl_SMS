using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subra.SSL_SMS.Web.Models
{
    public class GroupSmsModel : SmsBaseModel
    {
        [Required]
        public int GroupId { get; set; }
        [Required]
        [ValidateContactIds]
        public string ContatId { get; set; }
        [Required]
        public string Messages { get; set; }

        public void SendSms()
        {
            
        }

        public IList<SelectListItem> GetGroupList()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in _smsLogService.GetGroups())
            {
                var group = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };
                listItems.Add(group);
            }
            return listItems;
        }

        public string ContactList(int groupId)
        {
            StringBuilder contacts = new StringBuilder();
            foreach (var item in _smsLogService.GetContactsByGroup(groupId))
            {
                if (contacts.ToString().Length > 0)
                    contacts.Append(", ");
                contacts.Append(item);
            }
            return contacts.ToString();
        }

    }
}
