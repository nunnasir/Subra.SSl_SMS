using System;
using System.Collections.Generic;
using System.Text;

namespace Subra.SSL_SMS.Framework
{
    public interface IGroupService : IDisposable
    {
        (IList<Group> records, int total, int totalDisplay) GetGroups(int pageIndex, int pageSize, string searchText, string sortText);
        void CreateGroup(Group group);
        void EditGroup(Group group);
        Group GetGroup(int id);
        Group DeleteGroup(int id);
    }
}
