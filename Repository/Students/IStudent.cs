using Intagleo.Domain;
using Intagleo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intagleo.Repository.Students
{
    public interface IStudent
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int StudentId);
        Task<ResponseModel> InsertStudent(Student Student_);
        Task<ResponseModel> UpdateStudent(Student Student_);
        Task<ResponseModel> DeleteStudent(int Student);
        void SaveChanges();
    }
}
