using System;
using System.Collections.Generic;
using System.Text;

namespace Subra.SSL_SMS.Framework
{
    public interface IContactService : IDisposable
    {
        (IList<Contact> records, int total, int totalDisplay) GetContacts(int pageIndex, int pageSize, string searchText, string sortText);
        void CreateContact(Contact contact);
        void EditContact(Contact contact);
        Contact GetContact(int id);
        Contact DeleteContact(int id);
        IList<Group> GetGroups();
    }
}
