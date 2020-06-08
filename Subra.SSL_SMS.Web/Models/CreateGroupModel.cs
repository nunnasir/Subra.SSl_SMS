using Subra.SSL_SMS.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Subra.SSL_SMS.Web.Models
{
    public class CreateGroupModel : GroupBaseModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        public CreateGroupModel(IGroupService groupService) : base(groupService) { }
        public CreateGroupModel() : base() { }

        public void Create()
        {
            var group = new Group
            {
                Name = this.Name
            };
            _groupService.CreateGroup(group);
        }

    }
}
