using Intagleo.Domain;
using Intagleo.Models;
using Intagleo.Repository.Users;
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
    public class UserController : Controller
    {
        private readonly UserRepository _stdRepository;


        public UserController(UserRepository stdRepository)
        {
            _stdRepository = stdRepository;

        }

        [HttpGet(nameof(GetAllUsers))]
        public IEnumerable<User> GetAllUsers()
        {
            var response = _stdRepository.GetUsers();
            return response.ToList();
        }


        [HttpGet(nameof(EditUserById))]
        public User EditUserById(int id)
        {
            var response = _stdRepository.GetUserById(id);
            return response;
        }

        [HttpPost(nameof(AddUser))]
        public async Task<ResponseModel> AddUser([FromForm] User data, IFormFile image)
        {
            var response = await _stdRepository.InsertUser(data, image);
            return response;
        }

        [HttpPost(nameof(UpdateUser))]
        public async Task<ResponseModel> UpdateUser([FromForm] User data, IFormFile image)
        {
            var response = await _stdRepository.UpdateUser(data, image);
            return response;
        }

        [HttpPost(nameof(DeleteUser))]
        public async Task<ResponseModel> DeleteUser(int id)
        {
            var response = await _stdRepository.DeleteUser(id);
            return response;
        }
    }
}
