using OCMS.Dtos.ComplaintDtos;
using OCMS.Mappers.ComplaintMappers;
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

        public void AddComplaintService(ComplaintDto complaintdto)
        {
            var complaint = complaintdto.AddComplaintMap();  //mapper from complaint to complaintdto 

            complaintrepo.AddComplaintRepo(complaint);

        }
    }
}