using System;
using System.Collections.Generic;
using System.Text;

namespace Subra.SSL_SMS.Framework
{
    public class DuplicateException : Exception
    {
        public string DuplicateItemName { get; private set; }
        public DuplicateException(string message, string itemName) : base(message)
        {
            DuplicateItemName = itemName;
        }
    }
}
