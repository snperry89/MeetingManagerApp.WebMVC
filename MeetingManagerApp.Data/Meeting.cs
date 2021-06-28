using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingManagerApp.Data
{
    public class Meeting
    {
        // Defining Id or MeetingId as 'Key' is not necessary as entity will look for this type of naming convention to apply primary key
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
