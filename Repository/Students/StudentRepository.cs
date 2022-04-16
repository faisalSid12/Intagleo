using Intagleo.Domain;
using Intagleo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intagleo.Repository.Students
{
    public class StudentRepository : IStudent
    {
        private ApplicationDbContext _dataContext;
        public StudentRepository(ApplicationDbContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public Student GetStudentById(int StudentId)
        {
            try
            {
                var getStudentById = _dataContext.Students.Where(x => x.Id == StudentId).FirstOrDefault();
                return getStudentById;

            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        public IEnumerable<Student> GetStudents()
        {
            var list = _dataContext.Students.Where(x => x.IsActive == true).ToList();
            return list;
        }
        public async Task<ResponseModel> InsertStudent(Student Student_)
        {
            try
            {
                Student_.IsActive = true;
                Student_.CreatedDate = DateTime.Now;
                var result = _dataContext.Students.Add(Student_);
                SaveChanges();
                var response = new ResponseModel(true, "Student Created Successfully!");
                return response;

                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }
        public async Task<ResponseModel> UpdateStudent(Student Student_)
        {
            try
            {
                Student_.IsActive = true;
                Student_.ModifiedDate = DateTime.Now;
                var result = _dataContext.Students.Update(Student_);
                SaveChanges();
                var response = new ResponseModel(true, "Student Updated Successfully!");
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public async Task<ResponseModel> DeleteStudent(int StudentId)
        {
            try
            {
                Student Student_ = _dataContext.Students.Find(StudentId);
                Student_.IsActive = false;

                _dataContext.Students.Update(Student_);
                SaveChanges();
                var response = new ResponseModel(true, "Student Deleted Successfully!");
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
