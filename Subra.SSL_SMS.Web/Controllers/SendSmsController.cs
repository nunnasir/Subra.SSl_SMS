using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using Subra.SSL_SMS.Web.Models;

namespace Subra.SSL_SMS.Web.Controllers
{
    public class SendSmsController : Controller
    {
        public IActionResult BulkSms()
        {
            var model = new BulkSmsModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BulkSms([Bind(nameof(BulkSmsModel.ContatId), nameof(BulkSmsModel.Messages))] BulkSmsModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.SendSms();
                    model.Response = new ResponseModel("SMS send Successfully!", ResponseType.Success);
                    return RedirectToAction("BulkSms");
                }
                catch (Exception)
                {
                    model.Response = new ResponseModel("SMS send failed!", ResponseType.Failure);
                }
            }
            return View(model);
        }

        public IActionResult GroupSms()
        {
            var model = new GroupSmsModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GroupSms([Bind(nameof(GroupSmsModel.GroupId), nameof(GroupSmsModel.ContatId), nameof(GroupSmsModel.Messages))] GroupSmsModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.SendSms();
                    model.Response = new ResponseModel("SMS send Successfully!", ResponseType.Success);
                    return RedirectToAction("GroupSms");
                }
                catch (Exception)
                {
                    model.Response = new ResponseModel("SMS send failed!", ResponseType.Failure);
                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult LoadContactList(int groupId)
        {
            var model = Startup.AutofacContainer.Resolve<GroupSmsModel>();
            var contacts = model.ContactList(groupId);
            return Json(contacts);
        }


    }
}