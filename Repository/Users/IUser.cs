using Intagleo.Domain;
using Intagleo.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intagleo.Repository.Users
{
    public interface IUser
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int UserId);
        public Task<ResponseModel> InsertUser(User User_, IFormFile image);
        public Task<ResponseModel> UpdateUser(User User_, IFormFile image);
        Task<ResponseModel> DeleteUser(int User);
        void SaveChanges();
    }
}
