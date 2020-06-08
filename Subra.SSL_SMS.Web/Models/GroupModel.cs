using Subra.SSL_SMS.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Subra.SSL_SMS.Web.Models
{
    public class GroupModel : GroupBaseModel
    {
        public GroupModel(IGroupService groupService) : base(groupService) { }
        public GroupModel() : base() { }

        internal object GetGroups(DataTableAjaxRequestModel tableModel)
        {
            var data = _groupService.GetGroups(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Name" }));

            return new
            {
                recrecordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.Id.ToString()
                        }).ToArray()
            };
        }

        internal string Delete(int id)
        {
            var deleteGroup = _groupService.DeleteGroup(id);
            return deleteGroup.Name;
        }

    }
}
