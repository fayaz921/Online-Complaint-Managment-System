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

        public void AddComplaintService(AddComplaintDto complaintdto)
        {
            //var complaint = complaintdto.AddComplaintMap();  //mapper from complaint to complaintdto 

            //complaintrepo.AddComplaintRepo(complaint);

           
            var complaint = complaintdto.AddComplaintMap();  //mapper from complaint to complaintdto 

            complaintrepo.AddComplaintRepo(complaint);

        }

        //public Complaint Checkuserstatus(Guid Userid,UserStatus userStatus)
        //{
        //    var UserStatus = complaintrepo.GetByIdrepo(Userid);
           
        //}
    }
}