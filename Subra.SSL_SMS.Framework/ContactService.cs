using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
            var duplicate = 0;
            var save = 0;
            foreach (var itemValue in contact.ContatId.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var item = makeValidContact(itemValue);

                var count = _smsUnitOfWork.ContactRepository.GetCount(c => c.ContatId == item && c.GroupId == contact.GroupId);
                if (count > 0)
                {
                    duplicate++;
                }
                else
                {
                    var newContact = new Contact
                    {
                        ContatId = item,
                        GroupId = contact.GroupId,
                        CreateUser = "Nasir Uddin", // Dynamic
                        CreateDate = DateTime.Now
                    };
                    _smsUnitOfWork.ContactRepository.Add(newContact);

                    save++;
                }
            }
            if (save == 0)
                throw new DuplicatException("Contact already exist in this group", nameof(contact.ContatId));

            _smsUnitOfWork.Save();
        }

        private string makeValidContact(string itemValue)
        {
            var item = Regex.Replace(itemValue, @"\s", "");
            if (item.Length == 11)
                return $"88{item}";
            if (item.Length == 10)
                return $"880{item}";
            return item;
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

        // Need To be Update
        public void EditContact(Contact contact)
        {
            var duplicate = 0;
            var save = 0;
            foreach (var itemValue in contact.ContatId.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var item = makeValidContact(itemValue);

                var count = _smsUnitOfWork.ContactRepository.GetCount(c => c.ContatId == item && c.GroupId == contact.GroupId && c.Id != contact.Id);
                if (count > 0)
                {
                    duplicate++;
                }
                else
                {
                    var existingContact = _smsUnitOfWork.ContactRepository.Get(c => c.Id == contact.Id).FirstOrDefault();
                    if (existingContact != null)
                    {
                        existingContact.ContatId = item;
                        existingContact.GroupId = contact.GroupId;
                    }

                    else
                    {
                        var newContact = new Contact
                        {
                            ContatId = item,
                            GroupId = contact.GroupId
                        };
                        _smsUnitOfWork.ContactRepository.Add(newContact);
                    }

                    save++;
                }
            }

            if(save == 0)
                throw new DuplicatException("Contact already exist in this group", nameof(contact.ContatId));

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
                    c => c.ContatId.Contains(searchText) || c.Group.Name.Contains(searchText) || c.CreateUser.Contains(searchText),
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
