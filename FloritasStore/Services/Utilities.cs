using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FloritasStore.Services
{
    public class Utilities
    {
        public static int ConvertCompany(ClaimsPrincipal user)
        {
            return Convert.ToInt32(user.FindFirstValue("Company"));
        }
        
    }
}
