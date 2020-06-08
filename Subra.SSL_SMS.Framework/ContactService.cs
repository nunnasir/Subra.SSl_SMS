using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Subra.SSL_SMS.Framework
{
    public class ContactService : IContactService
    {
        private ISmsUnitOfWork _smsUnitOfWork;
        public ContactService(ISmsUnitOfWork smsUnitOfWork)
        {
            _smsUnitOfWork = smsUnitOfWork;
        }

        public void CreateContact(Contact contact)
        {
            var count = _smsUnitOfWork.ContactRepository.GetCount(c => c.ContatId == contact.ContatId && c.GroupId == contact.GroupId);
            if (count > 0)
                throw new DuplicatException("Contact Id already exist in this group!", nameof(contact.ContatId));

            _smsUnitOfWork.ContactRepository.Add(contact);
            _smsUnitOfWork.Save();
        }

        public Contact DeleteContact(int id)
        {
            var contact = _smsUnitOfWork.ContactRepository.GetById(id);
            _smsUnitOfWork.ContactRepository.Remove(contact);
            _smsUnitOfWork.Save();
            return contact;
        }

        public void Dispose()
        {
            _smsUnitOfWork?.Dispose();
        }

        public void EditContact(Contact contact)
        {
            var count = _smsUnitOfWork.ContactRepository.GetCount(c => c.ContatId == contact.ContatId && c.GroupId == contact.GroupId && c.Id != contact.Id);
            if (count > 0)
                throw new DuplicatException("Contact Id already exist in this group", nameof(contact.ContatId));

            var existingContact = _smsUnitOfWork.ContactRepository.GetById(contact.Id);
            existingContact.ContatId = contact.ContatId;
            existingContact.GroupId = contact.GroupId;

            _smsUnitOfWork.Save();
        }

        public Contact GetContact(int id)
        {
            return _smsUnitOfWork.ContactRepository.GetById(id);
        }

        public (IList<Contact> records, int total, int totalDisplay) GetContacts(int pageIndex, int pageSize, string searchText, string sortText)
        {
            if (searchText != "")
                return _smsUnitOfWork.ContactRepository.GetDynamic(
                    c => c.ContatId.Contains(searchText) || c.Group.Name.Contains(searchText),
                    sortText, c => c.Include(g => g.Group), pageIndex, pageSize, false);
            else
                return _smsUnitOfWork.ContactRepository.GetDynamic(null, sortText,
                    c => c.Include(g => g.Group),
                    pageIndex, pageSize, false);
        }

        public IList<Group> GetGroups()
        {
            return _smsUnitOfWork.GroupRepository.GetAll();
        }

    }
}
