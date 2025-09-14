using OCMS.Common.CustomClasses.Data;
using OCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS.Repositories.CategoryRepos
{
    public class CategoryRepo
    {
        private readonly OcmsDbContext ocmsDbContext = new OcmsDbContext();

        public List<Category> GetAllRepo()
        {
            try
            {
                return ocmsDbContext.Categories.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}