using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ASP_Bank.Auth;

namespace ASP_Bank.ContextFolder
{
    public class AuthContext:IdentityDbContext<User>
    {
        public AuthContext(DbContextOptions options) : base(options) { }

    }
}
