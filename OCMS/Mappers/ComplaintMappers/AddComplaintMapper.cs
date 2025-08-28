using OCMS.Common.CustomClasses;
using OCMS.Dtos.ComplaintDtos;
using OCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OCMS.Common.CustomClasses.Enums.ComplaintEnums;

namespace OCMS.Mappers.ComplaintMappers
{
    public static class AddComplaintMapper
    {
        public static Complaint AddComplaintMap(this AddComplaintDto complaint)
        {
            return new Complaint
            {
                ComplaintId = Guid.NewGuid(),
                UserId = complaint.UserId,
                Title = complaint.Title,
                Description = complaint.Description,
                CategoryId = complaint.CategoryId,
                ImageUrl = complaint.ImageUrl,
                Status = ComplaintStatus.Pending,
                Location = complaint.Location,
                IncidentDate = complaint.IncidentDate,
                TrackId = new Random().Next(1000, 9999),   //it will generate random track id of 4 number between 1000 to 9999
            };

        }
    }
}