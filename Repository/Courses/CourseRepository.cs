using Intagleo.Domain;
using Intagleo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intagleo.Repository.Courses
{
    public class CourseRepository : ICourse
    {
        private ApplicationDbContext _dataContext;
        public CourseRepository(ApplicationDbContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task<ResponseModel> DeleteCourse(int CourseId)
        {
            try
            {
                Course Course_ = _dataContext.Courses.Find(CourseId);
                Course_.IsActive = false;

                _dataContext.Courses.Update(Course_);
                SaveChanges();
                var response = new ResponseModel(true, "Course Deleted Successfully!");
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Course GetCourseById(int CourseId)
        {
            try
            {
                var getCourseById = _dataContext.Courses.Where(x => x.Id == CourseId).FirstOrDefault();
                return getCourseById;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Course> GetCourses()
        {
            var list = _dataContext.Courses.Where(x => x.IsActive == true).ToList();
            return list;
        }

        public async Task<ResponseModel> InsertCourse(Course Course_)
        {
            try
            {
                Course_.IsActive = true;
                Course_.CreatedDate = DateTime.Now;
                var result = _dataContext.Courses.Add(Course_);
                SaveChanges();
                var response = new ResponseModel(true, "Course Created Successfully!");
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

        public async Task<ResponseModel> UpdateCourse(Course Course_)
        {
            try
            {
                Course_.IsActive = true;
                Course_.ModifiedDate = DateTime.Now;
                var result = _dataContext.Courses.Update(Course_);
                SaveChanges();
                var response = new ResponseModel(true, "Course Updated Successfully!");
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
