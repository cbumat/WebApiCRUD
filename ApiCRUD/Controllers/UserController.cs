using ApiCRUD.Models;
using ApiCRUD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiCRUD.Controllers
{
    public class UserController : ApiController
    {
        IUserRepository repo;

        public UserController(IUserRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("api/Users")]
        public List<User> GetUser()
        {
            return this.repo.GetUsers();
        }

        [HttpGet]
        [Route("api/Users/{idUser}")]
        public User GetUserById(string idUser)
        {
            return this.repo.GetHotelById(idUser);
        }

        [HttpPost]
        [Route("api/AddUser")]
        public void AddUser(string Name, string LastName, string Address)
        {
            this.repo.AddUser(Name, LastName, Address);
        }

        [HttpPut]
        [Route("api/UpdateUser/{idUser}")]
        public void UpdateUser(string Id, string Name, string LastName, string Address)
        {
            this.repo.UpdateUser(Id, Name, LastName, Address);
        }

        [HttpDelete]
        [Route("api/DeleteUser/{idUser}")]
        public void DeleteUser(string userId)
        {
            this.repo.DeleteUser(userId);
        }
    }
}
