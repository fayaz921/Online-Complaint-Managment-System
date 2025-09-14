using OCMS.Common.CustomClasses;
using OCMS.Common.CustomClasses.Data;
using OCMS.Common.CustomClasses.Enums.ComplaintEnums;
using OCMS.Dtos;
using OCMS.Dtos.ComplaintDtos;
using OCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS.Repositories.ComplaintRepo
{

    public class ComplaintRepos
    {
        private readonly OcmsDbContext ocmsDbContext = new OcmsDbContext();
        public int AddComplaintRepo(Complaint complaint)
        {
            if (complaint != null)
            {
                ocmsDbContext.Complaints.Add(complaint);
                ocmsDbContext.SaveChanges();
                return (int)OperationStatus.Success;
            }
            return (int)OperationStatus.Failure;

        }

        public Complaint GetByIdrepo(Guid Id)
        {
            var complaint = ocmsDbContext.Complaints.Where(u => u.UserId == Id || u.ComplaintId == Id).FirstOrDefault();
            return complaint;
        }

        //public List<Complaint> GetAllComplaints()
        //{
        //    return ocmsDbContext.Complaints.ToList();
        //}
        public List<GetComplaintDto> GetAllComplaints()
        {
            var result = (from com in ocmsDbContext.Complaints
                          join cat in ocmsDbContext.Categories
                            on com.CategoryId equals cat.CategoryId into catg
                          from cat in catg.DefaultIfEmpty()
                          select new GetComplaintDto
                          {
                              ComplaintId = com.ComplaintId,
                              UserId = com.UserId,
                              Title = com.Title,
                              Description = com.Description,
                              Location = com.Location,
                              ImageUrl = com.ImageUrl,
                              Status = com.Status,
                              IncidentDate = com.IncidentDate,
                              CategoryId = com.CategoryId,
                              CategoryName = cat != null ? cat.CategoryName : null,
                              TrackId = com.TrackId,
                          }).ToList();

            return result;
        }

        public List<GetComplaintDto> GetAllComplaintsByrequesttype(ComplaintRequestType requestType)
        {
            if(requestType == ComplaintRequestType.AllComplaints)
            {
                return GetAllComplaints();
            }
            var status = (ComplaintStatus)requestType;

            var result = (from com in ocmsDbContext.Complaints
                          join cat in ocmsDbContext.Categories
                            on com.CategoryId equals cat.CategoryId into catg
                          from cat in catg.DefaultIfEmpty()
                          where com.Status == status
                          select new GetComplaintDto
                          {
                              ComplaintId = com.ComplaintId,
                              UserId = com.UserId,
                              Title = com.Title,
                              Description = com.Description,
                              Location = com.Location,
                              ImageUrl = com.ImageUrl,
                              Status = com.Status,
                              IncidentDate = com.IncidentDate,
                              CategoryId = com.CategoryId,
                              CategoryName = cat != null ? cat.CategoryName : null,
                              TrackId = com.TrackId,
                          }).ToList();

            return result;
        }


       

        public bool UpdateComplaintStatus(Guid complaintid, ComplaintStatus status)
        {
            var complaintstatus = ocmsDbContext.Complaints.FirstOrDefault(u => u.ComplaintId == complaintid);
            if (complaintstatus == null)
            {
                return false;
            }
            complaintstatus.Status = status;
            ocmsDbContext.Complaints.Update(complaintstatus); //
            ocmsDbContext.SaveChanges();
            return true;

        }


        public void RemoveComplaint(Complaint complaint)
        {
            ocmsDbContext.Complaints.Remove(complaint);
            ocmsDbContext.SaveChanges();
        }



    }
}