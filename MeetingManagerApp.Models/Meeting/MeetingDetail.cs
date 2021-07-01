using MeetingManagerApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingManagerApp.Models
{
    public class MeetingDetail
    {
        public int MeetingId { get; set; }

        public string Description { get; set; }

        public MuteRule MuteRule { get; set; }

        public int OrganizationId { get; set; }

    }
}
