using OCMS.Common.CustomClasses.Enums.ComplaintEnums;
using System;
using System.ComponentModel.DataAnnotations;

namespace OCMS.Models
{
    public class Complaint
    {
    
        [Key]
        public Guid ComplaintId { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
        public Guid CategoryId { get; set; }
        public string ImageUrl { get; set; }  = string.Empty;
        public ComplaintStatus? Status { get; set; }

        public string Location { get; set; } = string.Empty;

        public DateTime? IncidentDate { get; set; }

        public int TrackId { get; set; } 

    }
}