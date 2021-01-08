using sample_Web_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_Web_API.Interfaces
{
   public interface ITokenService
    {
        string CreateToken(AppUser user); 
    }
}
