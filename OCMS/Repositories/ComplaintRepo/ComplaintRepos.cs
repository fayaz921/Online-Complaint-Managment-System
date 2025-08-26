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
        public void AddComplaintRepo(Complaint complaint)
        {
            ocmsDbContext.Complaints.Add(complaint);
            ocmsDbContext.SaveChanges();
        }
    }
}