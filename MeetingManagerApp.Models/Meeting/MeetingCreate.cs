using MeetingManagerApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingManagerApp.Models.Meeting
{
    public class MeetingCreate
    {
        [MaxLength(8000)]
        public string Description { get; set; }

        [Required]
        public MuteRule MuteRule { get; set; }

        public int OrganizationId { get; set; }

        // public SelectList OrganizationOptions { get; set; }

    }
}
