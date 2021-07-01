using MeetingManagerApp.Data;
using MeetingManagerApp.Models.Organization;
using MeetingManagerApp.WebMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingManagerApp.Services
{
    public class OrganizationService
    {
        public bool CreateOrganization(OrganizationCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newOrganization = new Organization()
                {
                    Name = model.Name
                };

                ctx.Organizations.Add(newOrganization);
                return ctx.SaveChanges() == 1;
            }
        }
        public OrganizationDetail GetOrganizationDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var organization = ctx.Organizations.Single(o => o.OrganizationId == id);
                return new OrganizationDetail
                {
                    OrganizationId = organization.OrganizationId,
                };
            }
        }

        public IEnumerable<OrganizationListItem> GetOrganizationList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                // foreach meeting it finds we want to create a new meetinglistItem
                var query = ctx.Organizations.Select(o => new OrganizationListItem
                {
                    Name = o.Name
                });

                return query.ToArray();
            }
        }

        public IEnumerable<Organization> GetOrganizations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Organizations.ToList();
            }
        }

        public bool UpdateOrganization(OrganizationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var organization = ctx.Organizations.Single(o => o.OrganizationId == model.OrganizationId);
                organization.Name = model.Name;

                return ctx.SaveChanges() == 1;

            }
        }
    }
}
