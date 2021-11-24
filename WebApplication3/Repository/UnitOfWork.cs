using AspNet_Core.Data;
using AspNet_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet_Core.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext context ;
        public GenericRepository<Employee> EmployeeRepository;
        public GenericRepository<SubSection> SubSectionRepository;
        public GenericRepository<Section> SectionRepository;
        public GenericRepository<Department> DepartmentRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        public GenericRepository<Employee> employeeRepository
        {
            get
            {

                if (this.EmployeeRepository == null)
                {
                    this.EmployeeRepository = new GenericRepository<Employee>(context);
                }
                return EmployeeRepository;
            }
        }
        public GenericRepository<SubSection> subSectionRepository
        {
            get
            {

                if (this.SubSectionRepository == null)
                {
                    this.SubSectionRepository = new GenericRepository<SubSection>(context);
                }   
                return SubSectionRepository;
            }
        }
        public GenericRepository<Section> sectionRepository
        {
            get
            {

                if (this.SectionRepository == null)
                {
                    this.SectionRepository = new GenericRepository<Section>(context);
                }
                return SectionRepository;
            }
        }
        public GenericRepository<Department> departmentRepository
        {
            get
            {

                if (this.DepartmentRepository == null)
                {
                    this.DepartmentRepository = new GenericRepository<Department>(context);
                }
                return DepartmentRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
