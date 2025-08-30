using OCMS.Common.CustomClasses;
using OCMS.Common.CustomClasses.Data;
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

    }
}