using Subra.SSL_SMS.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Subra.SSL_SMS.Web.Models
{
    public class EditGroupModel : GroupBaseModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        public EditGroupModel(IGroupService groupService) : base(groupService) { }
        public EditGroupModel() : base() { }

        public void Edit()
        {
            var group = new Group
            {
                Id = this.Id,
                Name = this.Name
            };

            _groupService.EditGroup(group);
        }

        public void LoadGroup(int id)
        {
            var group = _groupService.GetGroup(id);
            if (group != null)
            {
                this.Id = group.Id;
                this.Name = group.Name;
            }
        }
    }
}
