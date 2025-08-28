using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS.Dtos.CategoryDtos
{
    public class GetCategoryDto
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}