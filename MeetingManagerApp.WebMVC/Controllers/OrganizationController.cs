using MeetingManagerApp.Models.Organization;
using MeetingManagerApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingManagerApp.WebMVC.Controllers
{
    public class OrganizationController : Controller
    {
        // GET: Organization
        public ActionResult Index()
        {
            return View(new OrganizationService().GetOrganizationList());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Organization";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrganizationCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (new OrganizationService().CreateOrganization(model))
            {
                TempData["SaveResult"] = "Organization established";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong - could not create a organization");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var organization = new OrganizationService().GetOrganizationDetailsById(id);
            return View(organization);
        }

        public ActionResult Edit(int id)
        {
            var organization = new OrganizationService().GetOrganizationDetailsById(id);
            return View(new OrganizationEdit
            {
                OrganizationId = organization.OrganizationId,
                Name = organization.Name
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrganizationEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.OrganizationId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            if (new OrganizationService().UpdateOrganization(model))
            {
                TempData["SaveResult"] = "Organization Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong - could not update organization");
            return View(model);
        }
    }
}