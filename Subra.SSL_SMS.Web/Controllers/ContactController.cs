using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using Subra.SSL_SMS.Framework;
using Subra.SSL_SMS.Web.Models;

namespace Subra.SSL_SMS.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<ContactModel>();
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new CreateContactModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind(nameof(CreateContactModel.GroupId), nameof(CreateContactModel.ContatId))] CreateContactModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                    model.Response = new ResponseModel("Contacts Create Successfully!", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicatException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                }
                catch (Exception)
                {
                    model.Response = new ResponseModel("Contact creation failed!", ResponseType.Failure);
                }
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = new EditContactModel();
            model.LoadContact(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind(nameof(EditContactModel.Id), nameof(EditContactModel.ContatId), nameof(EditContactModel.GroupId))] EditContactModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("Contact Successfully updated!", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicatException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                }
                catch (Exception)
                {
                    model.Response = new ResponseModel("Contact updating failed!", ResponseType.Failure);
                }
            }

            return View(model);
        }

        public IActionResult GetContacts()
        {
            var tableModel = new DataTableAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<ContactModel>();
            var data = model.GetContacts(tableModel);
            return Json(data);
        }

    }
}