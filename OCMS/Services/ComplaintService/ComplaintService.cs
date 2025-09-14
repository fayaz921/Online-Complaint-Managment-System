using OCMS.Common.CustomClasses;
using OCMS.Common.CustomClasses.Data;
using OCMS.Common.CustomClasses.Enums.ComplaintEnums;
using OCMS.Dtos.ComplaintDtos;
using OCMS.Mappers.ComplaintMappers;
using OCMS.Models;
using OCMS.Repositories;
using OCMS.Repositories.CategoryRepos;
using OCMS.Repositories.ComplaintRepo;
using OCMS.Services.CategoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS.Services.ComplaintService
{

    public class ComplaintService : Category
    {
        private readonly ComplaintRepos complaintrepo = new ComplaintRepos();
        private readonly CategoryRepo categoryRepo = new CategoryRepo();
        public int AddComplaintService(AddComplaintDto complaintdto)
        {
            try
            {
                if (complaintdto != null)
                {
                    complaintrepo.AddComplaintRepo(complaintdto.AddComplaintMap());
                    return (int)OperationStatus.Success;

                }
                return (int)OperationStatus.Failure;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public GetComplaintDto GetbyIdsevice(Guid id)
        {
            try
            {
                return complaintrepo.GetByIdrepo(id).GetComplaintMap();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<GetComplaintDto> GetAllComplaints()
        {
            //var result = (from com in complaintrepo.GetAllComplaints()
            //              join cat in categoryRepo.GetAllRepo()
            //              on com.CategoryId equals cat.CategoryId into catg
            //              from cat in catg.DefaultIfEmpty()
            //              select new GetComplaintDto
            //              {
            //                  ComplaintId = com.ComplaintId,
            //                  UserId = com.UserId,
            //                  Title = com.Title,
            //                  Description = com.Description,
            //                  Location = com.Location,
            //                  ImageUrl = com.ImageUrl,
            //                  Status = com.Status,
            //                  IncidentDate = com.IncidentDate,
            //                  CategoryId = com.CategoryId,
            //                  CategoryName = cat != null ? cat.CategoryName : null,
            //                  TrackId = com.TrackId,
            //              }).ToList();

            //return result;
            try
            {
                return complaintrepo.GetAllComplaints();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<GetComplaintDto> GetComplaintsByRequestType(ComplaintRequestType requestType)
        {
            try
            {
                return complaintrepo.GetAllComplaintsByrequesttype(requestType);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool UpdateComplaintStatus(Guid complaintid, ComplaintStatus complaintStatus)
        {
            try
            {
                return complaintrepo.UpdateComplaintStatus(complaintid, complaintStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int Removeservice(Guid complaintid)
        {
            try
            {
                var complaint = complaintrepo.GetByIdrepo(complaintid);           //get user from repo
                if (complaint == null)                                  //if id is null return false and stop here, so user will not be deleted
                {
                    return (int)OperationStatus.Failure;
                }

                //remove user 
                complaintrepo.RemoveComplaint(complaint);

                return (int)OperationStatus.Success;
            }
            catch (Exception)
            {
                throw;
            }

        }



    }
}