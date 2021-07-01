using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingManagerApp.Models.Organization
{
    public class OrganizationEdit
    {
        public int OrganizationId { get; set; }

        [Required]
        [MaxLength(256)]
        [RegularExpression(@"[^/s]+")]
        public string Name { get; set; }
    }
}
