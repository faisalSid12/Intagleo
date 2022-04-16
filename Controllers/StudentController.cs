using Intagleo.Domain;
using Intagleo.Models;
using Intagleo.Repository.Students;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intagleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository _stdRepository;


        public StudentController(StudentRepository stdRepository)
        {
            _stdRepository = stdRepository;

        }

        [HttpGet(nameof(GetAllStudents))]
        public IEnumerable<Student> GetAllStudents()
        {
            var response = _stdRepository.GetStudents();
            return response.ToList();
        }


        [HttpGet(nameof(EditStudentById))]
        public Student EditStudentById(int id)
        {
            var response = _stdRepository.GetStudentById(id);
            return response;
        }

        [HttpPost(nameof(AddStudent))]
        public async Task<ResponseModel> AddStudent([FromBody] Student input)
        {
            var response = await _stdRepository.InsertStudent(input);
            return response;
        }

        [HttpPost(nameof(UpdateStudent))]
        public async Task<ResponseModel> UpdateStudent([FromForm] Student input)
        {
            var response = await _stdRepository.UpdateStudent(input);
            return response;
        }

        [HttpPost(nameof(DeleteStudent))]
        public async Task<ResponseModel> DeleteStudent(int id)
        {
            var response = await _stdRepository.DeleteStudent(id);
            return response;
        }
    }
}
