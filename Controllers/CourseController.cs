using Intagleo.Domain;
using Intagleo.Models;
using Intagleo.Repository.Courses;
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
    public class CourseController : ControllerBase
    {
        private readonly CourseRepository _courseRepository;


        public CourseController(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;

        }

        [HttpGet(nameof(GetAllCourses))]
        public IEnumerable<Course> GetAllCourses()
        {
            var response = _courseRepository.GetCourses();
            return response.ToList();
        }


        [HttpGet(nameof(EditCourseById))]
        public Course EditCourseById(int id)
        {
            var response = _courseRepository.GetCourseById(id);
            return response;
        }

        [HttpPost(nameof(AddCourse))]
        public async Task<ResponseModel> AddCourse([FromBody] Course input)
        {
            var response = await _courseRepository.InsertCourse(input);
            return response;
        }

        [HttpPost(nameof(UpdateCourse))]
        public async Task<ResponseModel> UpdateCourse([FromForm] Course input)
        {
            var response = await _courseRepository.UpdateCourse(input);
            return response;
        }

        [HttpPost(nameof(DeleteCourse))]
        public async Task<ResponseModel> DeleteCourse(int id)
        {
            var response = await _courseRepository.DeleteCourse(id);
            return response;
        }
    }
}

