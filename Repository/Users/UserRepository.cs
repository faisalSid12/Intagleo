using Intagleo.Domain;
using Intagleo.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Intagleo.Repository.Users
{
    public class UserRepository : IUser
    {
        private ApplicationDbContext _dataContext;
        public UserRepository(ApplicationDbContext dataContext)
        {
            this._dataContext = dataContext;
        }
 
        public IEnumerable<User> GetUsers()
        {
            var list = _dataContext.Users.Where(x => x.IsActive == true).ToList();
            return list;
        }

        public User GetUserById(int UserId)
        {
            try
            {
                var getUserById = _dataContext.Users.Where(x => x.Id == UserId).FirstOrDefault();
                return getUserById;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<ResponseModel> DeleteUser(int User)
        {
            throw new NotImplementedException();
        }


        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public bool SaveImage(IFormFile image, string FileName)
        {
            try
            {
                //string uniqueFileName = Guid.NewGuid().ToString() + "_" + FileName;
                var imagePath = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot/images/Languages", FileName);
                image.CopyTo(new FileStream(imagePath, FileMode.Create));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<ResponseModel> InsertUser(User User_, IFormFile image)
        {
            try
            {

                User_.IsActive = true;
                User_.CreatedDate = DateTime.Now;


                if (image != null)
                {
                    string name = Guid.NewGuid().ToString() + "_" + image.FileName;
                    SaveImage(image, name);
                    User_.ImagePath = name;
                    var result = _dataContext.Users.Add(User_);
                    SaveChanges();
                    var response = new ResponseModel(true, "User Created Successfully");
                    return response;
                }
                else
                {
                    User_.ImagePath = null;
                    var result = _dataContext.Users.Add(User_);
                    SaveChanges();
                    var response = new ResponseModel(true, "User Created Successfully");
                    return response;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<ResponseModel> UpdateUser(User User_, IFormFile image)
        {
            try
            {

                User_.IsActive = true;
                User_.ModifiedDate = DateTime.Now;
                if (image != null)
                {
                    string name = Guid.NewGuid().ToString() + image.FileName;
                    SaveImage(image, name);
                    var lang = _dataContext.Users.Find(User_.Id);
                    lang.FirstName = User_.FirstName;
                    lang.LastName = User_.LastName;
                    lang.ImagePath = name;
                    SaveChanges();
                    var response = new ResponseModel(true, "User Update Successfully!");
                    return response;
                }
                else
                {
                    var lang = _dataContext.Users.Find(User_.Id);
                    lang.FirstName = User_.FirstName;
                    lang.LastName = User_.LastName;
                    lang.Address = User_.Address;
                    SaveChanges();
                    var response = new ResponseModel(true, "Language Update Successfully!");
                    return response;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
