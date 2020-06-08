using Autofac;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Subra.SSL_SMS.Framework;

namespace Subra.SSL_SMS.Web.Models
{
    public abstract class AdminBaseModel
    {
        public MenuModel MenuModel { get; set; }
        public ResponseModel Response
        {
            get
            {
                if (_httpContextAccessor.HttpContext.Session.IsAvailable
                    && _httpContextAccessor.HttpContext.Session.Keys.Contains(nameof(Response)))
                {
                    var response = _httpContextAccessor.HttpContext.Session.Get<ResponseModel>(nameof(Response));
                    _httpContextAccessor.HttpContext.Session.Remove(nameof(Response));

                    return response;
                }
                else
                    return null;
            }
            set
            {
                _httpContextAccessor.HttpContext.Session.Set(nameof(Response),
                    value);
            }
        }

        protected IHttpContextAccessor _httpContextAccessor;
        public AdminBaseModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            SetupMenu();
        }

        public AdminBaseModel()
        {
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
            SetupMenu();
        }

        private void SetupMenu()
        {
            MenuModel = new MenuModel
            {
                MenuItems = new List<MenuItem>()
                {
                    {
                        new MenuItem
                        {
                            Title = "Manage Group",
                            Icon = "fa-group",
                            Childs = new List<MenuChildItem>
                            {
                                new MenuChildItem { Title = "Group List", Url = "/Group" },
                                new MenuChildItem { Title = "Add Group", Url = "/Group/Create" },
                                new MenuChildItem { Title = "Contact List", Url = "/Contact" },
                                new MenuChildItem { Title = "Add Group Contacts", Url = "/Contact/Create" },
                            }
                        }
                    },
                    {
                        new MenuItem
                        {
                            Title = "Send SMS",
                            Icon = "fa-envelope",
                            Childs = new List<MenuChildItem>
                            {
                                new MenuChildItem { Title = "Group SMS", Url = "/GroupSms" },
                                new MenuChildItem { Title = "Bulk SMS", Url = "/BulkSms" },
                            }
                        }
                    },
                }
            };
        }
    }
}
