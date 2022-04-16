using Intagleo.Domain;
using Intagleo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intagleo.Repository.Courses
{
    interface ICourse
    {
        IEnumerable<Course> GetCourses();
        Course GetCourseById(int CourseId);
        Task<ResponseModel> InsertCourse(Course Course_);
        Task<ResponseModel> UpdateCourse(Course Course_);
        Task<ResponseModel> DeleteCourse(int CourseId);
        void SaveChanges();
    }
}
