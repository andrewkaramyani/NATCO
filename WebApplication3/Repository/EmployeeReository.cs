﻿using AspNet_Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Repository;

namespace AspNet_Core.Models
{
    public class EmployeeReository : Repository<Employee>,IEmployeeReository
    {
        public EmployeeReository(AppDbContext context) : base(context)
        {
        }
        public AppDbContext Context
        {
            get { return Context as AppDbContext; }
        }
    }
}
