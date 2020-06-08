using System;
using System.Collections.Generic;
using System.Text;

namespace Subra.SSL_SMS.Framework
{
    public class MenuItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public IList<MenuChildItem> Childs { get; set; }
    }
}
