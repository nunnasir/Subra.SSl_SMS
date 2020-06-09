using Subra.SSL_SMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Subra.SSL_SMS.Web.Models
{
    public class ContactModel : ContactBaseModel
    {
        public ContactModel(IContactService contactService) : base(contactService) { }
        public ContactModel() : base() { }

        internal object GetContacts(DataTableAjaxRequestModel tableModel)
        {
            var data = _contactService.GetContacts(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "ContatId", "Group", "CreateUser", "CreateDate" }));

            return new
            {
                recrecordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.ContatId,
                            record.Group.Name,
                            record.CreateUser,
                            record.CreateDate.ToString("dd/MM/yyyy"),
                            record.Id.ToString()
                        }).ToArray()
            };
        }

        internal string Delete(int id)
        {
            var deleteContact = _contactService.DeleteContact(id);
            return deleteContact.ContatId;
        }
    }
}
