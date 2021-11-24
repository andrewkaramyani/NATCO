using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet_Core.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>().HasData(
                new User {UserName="Ahmed",Password="Ahmed",Role="Admin" },
                new User {UserName="Andrew",Password= "Andrew", Role= "Viewer" },
                new User {UserName="John",Password= "John", Role= "Contributor" }
                );
            modelBuilder.Entity<Department>().HasData(
               new Department { Name = "IT" }
               );
        }
    }
}
