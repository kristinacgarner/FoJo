using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoJo.Business.Models.Config
{
    public class FoJoConfig
    {
        public IdentityConfig Identity { get; set; }
    }
    public class IdentityConfig
    {
        public PasswordOptions Password { get; set; }

    }
   
}
