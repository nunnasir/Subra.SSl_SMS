using System;
using System.Collections.Generic;
using System.Text;

namespace Subra.SSL_SMS.Framework
{
    public class GroupService : IGroupService
    {
        private ISmsUnitOfWork _smsUnitOfWork;

        public GroupService(ISmsUnitOfWork smsUnitOfWork)
        {
            _smsUnitOfWork = smsUnitOfWork;
        }

        public void CreateGroup(Group group)
        {
            var count = _smsUnitOfWork.GroupRepository.GetCount(g => g.Name == group.Name);
            if (count > 0)
                throw new DuplicatException("Group name already exist!", nameof(group.Name));

            _smsUnitOfWork.GroupRepository.Add(group);
            _smsUnitOfWork.Save();
        }

        public Group DeleteGroup(int id)
        {
            var group = _smsUnitOfWork.GroupRepository.GetById(id);
            _smsUnitOfWork.GroupRepository.Remove(group);
            _smsUnitOfWork.Save();
            return group;
        }

        public void Dispose()
        {
            _smsUnitOfWork?.Dispose();
        }

        public void EditGroup(Group group)
        {
            var count = _smsUnitOfWork.GroupRepository.GetCount(g => g.Name == group.Name && g.Id != group.Id);
            if (count > 0)
                throw new DuplicatException("Group name already exist!", nameof(group.Name));

            var existingGroup = _smsUnitOfWork.GroupRepository.GetById(group.Id);
            existingGroup.Name = group.Name;

            _smsUnitOfWork.Save();
        }

        public Group GetGroup(int id)
        {
            return _smsUnitOfWork.GroupRepository.GetById(id);
        }

        public (IList<Group> records, int total, int totalDisplay) GetGroups(int pageIndex, int pageSize, string searchText, string sortText)
        {
            if (searchText != "")
                return _smsUnitOfWork.GroupRepository.GetDynamic(
                    g => g.Name.Contains(searchText),
                    sortText, null, pageIndex, pageSize, false);
            else
                return _smsUnitOfWork.GroupRepository.GetDynamic(null, sortText, null,
                    pageIndex, pageSize, false);
        }
    }
}
