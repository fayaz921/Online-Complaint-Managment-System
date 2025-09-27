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
            try
            {
                if (complaint != null)
                {
                    ocmsDbContext.Complaints.Add(complaint);
                    ocmsDbContext.SaveChanges();
                    return (int)OperationStatus.Success;
                }
                return (int)OperationStatus.Failure;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Complaint GetByIdrepo(Guid Id)
        {
            try
            {
                var complaint = ocmsDbContext.Complaints.Where(u => u.UserId == Id || u.ComplaintId == Id).FirstOrDefault();
                return complaint;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public List<Complaint> GetAllComplaints()
        //{
        //    return ocmsDbContext.Complaints.ToList();
        //}
        public List<GetComplaintDto> GetAllComplaints()
        {
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        public List<GetComplaintDto> GetAllComplaintsByrequesttype(ComplaintRequestType requestType)
        {
            try
            {
                if (requestType == ComplaintRequestType.AllComplaints)
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
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateComplaintStatus(Guid complaintid, ComplaintStatus status)
        {
            try
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
            catch (Exception)
            {
                throw;
            }

        }


        public void RemoveComplaint(Complaint complaint)
        {
            try
            {
                ocmsDbContext.Complaints.Remove(complaint);
                ocmsDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public Complaint GetComplaintbyTrackId(int trackid)
        //{
        //    try
        //    {
        //        return ocmsDbContext.Complaints.Where(t => t.TrackId == trackid).FirstOrDefault();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        public GetComplaintDto GetComplaintbyTrackId(int trackid)
        {
            try
            {
                var complaint = (from c in ocmsDbContext.Complaints
                                 join cat in ocmsDbContext.Categories
                                     on c.CategoryId equals cat.CategoryId into catJoin
                                 from cat in catJoin.DefaultIfEmpty()
                                 where c.TrackId == trackid
                                 select new GetComplaintDto
                                 {
                                     ComplaintId = c.ComplaintId,
                                     UserId = c.UserId,
                                     Title = c.Title,
                                     Description = c.Description,
                                     CategoryId = c.CategoryId,
                                     CategoryName = cat.CategoryName, // ✅ joined value
                                     ImageUrl = c.ImageUrl,
                                     Status = c.Status,
                                     Location = c.Location,
                                     IncidentDate = c.IncidentDate,
                                     TrackId = c.TrackId
                                 }).FirstOrDefault();

                return complaint;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}