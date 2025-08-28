using OCMS.Dtos.CategoryDtos;
using OCMS.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace OCMS.Mappers.CategoryMappers
{
    public static class GetCategoryMapper
    {
        public static List<GetCategoryDto> MapGetCategory(this List<Category> categories)
        {
            if(categories == null || categories.Count == 0)
                return new List<GetCategoryDto>();


            return categories.Select(u => new GetCategoryDto
            {
                CategoryId = u.CategoryId,
                CategoryName = u.CategoryName,

            }).ToList();
        }
    }
}