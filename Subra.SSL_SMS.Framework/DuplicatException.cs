using System;
using System.Collections.Generic;
using System.Text;

namespace Subra.SSL_SMS.Framework
{
    public class DuplicatException : Exception
    {
        public string DuplicateItemName { get; private set; }
        public DuplicatException(string message, string itemName) : base(message)
        {
            DuplicateItemName = itemName;
        }
    }
}
