using OCMS.Common.CustomClasses;
using OCMS.Dtos.ComplaintDtos;
using OCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS.Mappers.ComplaintMappers
{
    public static class AddComplaintMapper
    {
        public static Complaint AddComplaintMap(this ComplaintDto complaint)
        {
            return new Complaint
            {
                ComplaintId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Title = complaint.Title,
                Description = complaint.Description,
                CategoryId = Guid.NewGuid(),
                ImageUrl = complaint.ImageUrl,
                Status = (Common.CustomClasses.Enums.ComplaintEnums.ComplaintStatus?)UserStatus.Pending,
                IncidentDate = DateTime.Now.Date,
                TrackId = complaint.TrackId,
            };

        }
    }
}