using OCMS.Common.CustomClasses.Enums.ComplaintEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OCMS.Dtos.ComplaintDtos
{
    public class AddComplaintDto
    {
      
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public ComplaintStatus? Status { get; set; }

        public DateTime? IncidentDate { get; set; }

        public int TrackId { get; set; }
    }
}