using System;
using System.Collections.Generic;
using System.Text;
using AutomationCodeHive.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutomationHIVE.Data.Data.Migrations
{
    public class AutomationCodeHiveDbContext : IdentityDbContext
    {
        public AutomationCodeHiveDbContext(DbContextOptions<AutomationCodeHiveDbContext> options)
            : base(options)
        {
        }
        public DbSet<MentorModel> Mentors { get; set; }
    }
}
