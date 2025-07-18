﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.BL.Helpers;
using WebApplication7.BL.Interface;
using WebApplication7.DAL.Database;
using WebApplication7.DAL.Entities;
using WebApplication7.Models;

namespace WebApplication7.BL.Repository
{
    public class EmployeeRep : IEmployeeRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        public EmployeeRep(DbContainer db, IMapper _Mapper)
        {
            this.db = db;
            mapper = _Mapper;
        }

        public IQueryable<EmployeeVM> Get()
        {
            IQueryable<EmployeeVM> data = GetAllEmps();
            return data;
        }


        public EmployeeVM GetById(int id)
        {
            EmployeeVM data = GetEmployeeByID(id);
            return data;
        }


        public void Add(EmployeeVM emp)
        {
            // Mapping
            var data = mapper.Map<Employee>(emp);

            data.PhotoName = UploadFileHelper.SaveFile(emp.PhotoUrl, "Photos");
            data.CvName = UploadFileHelper.SaveFile(emp.CvUrl, "Docs");

            db.Employee.Add(data);
            db.SaveChanges();
        }

        public void Edit(EmployeeVM emp)
        {
            // Mapping
            var data = mapper.Map<Employee>(emp);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var DeletedObject = db.Employee.Find(id);
            db.Employee.Remove(DeletedObject);

            UploadFileHelper.RemoveFile("Photos/", DeletedObject.PhotoName);
            UploadFileHelper.RemoveFile("Docs/", DeletedObject.CvName);

            db.SaveChanges();
        }



        // Refactor
        private EmployeeVM GetEmployeeByID(int id)
        {
            return db.Employee.Where(a => a.Id == id)
                                    .Select(a => new EmployeeVM { Id = a.Id, Name = a.Name, Salary = a.Salary, Address = a.Address, HireDate = a.HireDate, IsActive = a.IsActive, Email = a.Email, Notes = a.Notes, DepartmentName = a.Department.DepartmentName, DistrictName = a.District.DistrictName, DepartmentId = a.DepartmentId, DistrictId = a.DistrictId, PhotoName = a.PhotoName, CvName = a.CvName })
                                    .FirstOrDefault();
        }

        private IQueryable<EmployeeVM> GetAllEmps()
        {
            return db.Employee
                       .Select(a => new EmployeeVM { Id = a.Id, Name = a.Name, Salary = a.Salary, Address = a.Address, HireDate = a.HireDate, IsActive = a.IsActive, Email = a.Email, Notes = a.Notes, DepartmentName = a.Department.DepartmentName, DistrictName = a.District.DistrictName, DepartmentId = a.DepartmentId, DistrictId = a.DistrictId, PhotoName = a.PhotoName, CvName = a.CvName });
        }
    }
}
