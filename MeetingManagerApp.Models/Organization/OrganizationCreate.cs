using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingManagerApp.Models.Organization
{
    public class OrganizationCreate
    {
        [Required]
        [MaxLength(256)]
        [RegularExpression(@"[^/]+")]
        public string Name { get; set; }
    }
}
