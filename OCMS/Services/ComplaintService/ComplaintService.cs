using OCMS.Common.CustomClasses;
using OCMS.Dtos.ComplaintDtos;
using OCMS.Mappers.ComplaintMappers;
using OCMS.Models;
using OCMS.Repositories;
using OCMS.Repositories.ComplaintRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS.Services.ComplaintService
{
    public class ComplaintService
    {
        private readonly ComplaintRepos complaintrepo = new ComplaintRepos();

        public int AddComplaintService(AddComplaintDto complaintdto)
        {
            if (complaintdto != null)
            {
                complaintrepo.AddComplaintRepo(complaintdto.AddComplaintMap());
                return (int)OperationStatus.Success;

            }
            return (int)OperationStatus.Failure;

        }

        public GetComplaintDto GetbyIdsevice(Guid id)
        {
            return complaintrepo.GetByIdrepo(id).GetComplaintMap();
        }
    }
}