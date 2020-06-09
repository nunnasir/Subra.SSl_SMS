using Microsoft.AspNetCore.Mvc.Rendering;
using Subra.SSL_SMS.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Subra.SSL_SMS.Web.Models
{
    public class CreateContactModel : ContactBaseModel
    {
        [Required]
        public int GroupId { get; set; }
        [Required]
        [ValidateContactIds]
        public string ContatId { get; set; }

        public CreateContactModel(IContactService contactService) : base(contactService) { }
        public CreateContactModel() : base() { }

        public void Create()
        {
            var contact = new Contact
            {
                ContatId = this.ContatId,
                GroupId = this.GroupId
            };
            _contactService.CreateContact(contact);
        }

        public IList<SelectListItem> GetGroupList()
        {
            List<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in _contactService.GetGroups())
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

    }
}
