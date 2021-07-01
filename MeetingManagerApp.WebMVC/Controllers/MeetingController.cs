using MeetingManagerApp.Data;
using MeetingManagerApp.Models.Meeting;
using MeetingManagerApp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeetingManagerApp.WebMVC.Controllers
{
    public class MeetingController : Controller
    {
        // GET: Meeting
        public ActionResult Index()
        {
            return View(CreateMeetingService().GetMeetingList());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Meeting";
            List<Organization> Organizations = (new OrganizationService()).GetOrganizations().ToList();
            //Organizations.Select(o => new SelectListItem() { });
            var query = from o in Organizations
                        select new SelectListItem()
                        {
                            Value = o.OrganizationId.ToString(),
                            Text = o.Name
                        };
            ViewBag.OrganizationId = query.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MeetingCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateMeetingService().CreateMeeting(model))
            {
                TempData["SaveResult"] = "Meeting established";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong - could not create a meeting");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var meeting = CreateMeetingService().GetMeetingDetailsById(id);
            return View(meeting);
        }

        public ActionResult Edit(int id)
        {
            var meeting = CreateMeetingService().GetMeetingDetailsById(id);

            List<Organization> Organizations = (new OrganizationService()).GetOrganizations().ToList();
            ViewBag.OrganizationId = Organizations.Select(o => new SelectListItem() 
            {
                Value = o.OrganizationId.ToString(),
                Text = o.Name,
                Selected = meeting.OrganizationId == o.OrganizationId
            });
            //var query = from o in Organizations
            //            select new SelectListItem()
            //            {
            //                Value = o.OrganizationId.ToString(),
            //                Text = o.Name
            //            };
            //ViewBag.OrganizationId = query.ToList();

            return View(new MeetingEdit
            {
                MeetingId = meeting.MeetingId,
                MuteRule = meeting.MuteRule,
                Description = meeting.Description,
                OrganizationId = meeting.OrganizationId
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MeetingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MeetingId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            if (CreateMeetingService().UpdateMeeting(model))
            {
                TempData["SaveResult"] = "Meeting Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Something went wrong - could not update meeting");
            return View(model);
        }
        // Need a meeting service to use to control meetings
        private MeetingService CreateMeetingService()
        {
            // This is how we get the currently logged in user
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MeetingService(userId);
            return service;
        }
    }
}