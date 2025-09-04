using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS.Common.CustomClasses
{
    public enum OperationStatus
    {
        Success=1,
        Failure=2,
        NotFound=3,
        EmailDuplicate=-1,
        ModelValidation=4
    }
}