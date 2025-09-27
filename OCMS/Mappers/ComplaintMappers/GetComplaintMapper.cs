using OCMS.Dtos.ComplaintDtos;
using OCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS.Mappers.ComplaintMappers
{
    public static class GetComplaintMapper
    {

        public static GetComplaintDto GetComplaintMap(this Complaint complaint)
        {
            return new GetComplaintDto
            {
                ComplaintId = complaint.ComplaintId,
                Description = complaint.Description,
                ImageUrl = complaint.ImageUrl,
                Title = complaint.Title,
                IncidentDate = complaint.IncidentDate,
                Location = complaint.Location,
                CategoryId = complaint.CategoryId,
                Status = complaint.Status,
                UserId = complaint.UserId,
                TrackId = complaint.TrackId,
              


            };
        }
    }
}