using AutomationCodeHive.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationCodeHive.Data
{
    public class AutomationCodeHiveDbContext : DbContext
    {
        public AutomationCodeHiveDbContext(DbContextOptions<AutomationCodeHiveDbContext> options)
            :base(options)
        {

        }
        public DbSet<MentorModel2> Mentors { get; set; }

    }
}
