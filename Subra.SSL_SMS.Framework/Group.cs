﻿using Subra.SSL_SMS.Data;
using System;
using System.Collections.Generic;

namespace Subra.SSL_SMS.Framework
{
    public class Group : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Contact> Contacts { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
