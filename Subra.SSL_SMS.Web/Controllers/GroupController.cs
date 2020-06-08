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
    public class GroupController : Controller
    {
        public IActionResult Index()
        {
            var model = Startup.AutofacContainer.Resolve<GroupModel>();
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new CreateGroupModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind(nameof(CreateGroupModel.Name))] CreateGroupModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Create();
                    model.Response = new ResponseModel("New group Create Successfully!", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicatException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                }
                catch (Exception)
                {
                    model.Response = new ResponseModel("Group creation failed!", ResponseType.Failure);
                }
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = new EditGroupModel();
            model.LoadGroup(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind(nameof(EditGroupModel.Id), nameof(EditGroupModel.Name))] EditGroupModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Edit();
                    model.Response = new ResponseModel("Group Successfully updated!", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (DuplicatException ex)
                {
                    model.Response = new ResponseModel(ex.Message, ResponseType.Failure);
                }
                catch (Exception)
                {
                    model.Response = new ResponseModel("Group updating failed!", ResponseType.Failure);
                }
            }

            return View(model);
        }

        public IActionResult GetGroups()
        {
            var tableModel = new DataTableAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<GroupModel>();
            var data = model.GetGroups(tableModel);
            return Json(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteGroup(int id)
        {
            if (ModelState.IsValid)
            {
                var model = new GroupModel();
                try
                {
                    var title = model.Delete(id);
                    model.Response = new ResponseModel($"Group '{title}' sussessfully deleted!", ResponseType.Success);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    model.Response = new ResponseModel("Group Deletion Failed!", ResponseType.Failure);
                }
            }
            return RedirectToAction("Index");
        }

    }
}