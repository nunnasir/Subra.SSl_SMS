using Microsoft.AspNetCore.Mvc.Rendering;
using Subra.SSL_SMS.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Subra.SSL_SMS.Web.Models
{
    public class EditContactModel : ContactBaseModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string ContatId { get; set; }
        [Required]
        public int GroupId { get; set; }

        public EditContactModel(IContactService contactService) : base(contactService) { }
        public EditContactModel() : base() { }

        public void Edit()
        {
            var contact = new Contact
            {
                Id = this.Id,
                ContatId = this.ContatId,
                GroupId = this.GroupId
            };

            _contactService.EditContact(contact);
        }

        public void LoadGroup(int id)
        {
            var contact = _contactService.GetContact(id);
            if (contact != null)
            {
                this.Id = contact.Id;
                this.ContatId = contact.ContatId;
                this.GroupId = contact.GroupId;
            }
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
