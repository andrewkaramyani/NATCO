using AspNet_Core.Data;
using AspNet_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet_Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
         GenericRepository<Employee> EmployeeRepository { get; }
         GenericRepository<SubSection> SubSectionRepository { get; }
        GenericRepository<Section> SectionRepository { get; }
        GenericRepository<Department> DepartmentRepository { get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
