using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDomain.Models
{
    public class AppUser : IdentityUser
    {
        public  virtual ICollection<GeoLocation> GeoLocations { get; set; }
    }
}
