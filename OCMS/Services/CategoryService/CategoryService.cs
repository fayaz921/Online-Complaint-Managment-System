using OCMS.Dtos.CategoryDtos;
using OCMS.Mappers.CategoryMappers;
using OCMS.Repositories.CategoryRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS.Services.CategoryService
{
    public class CategoryService
    {
        private readonly CategoryRepo categoryrepo = new CategoryRepo();

        public List<GetCategoryDto> GetAllService()
        {
            return categoryrepo.GetAllRepo().MapGetCategory();
        }
    }
}