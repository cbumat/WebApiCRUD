using ApiCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCRUD.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetHotelById(string userId);
        void AddUser(string Name, string LastName, string Address);
        void UpdateUser(string Id, string Name, string LastName, string Address);
        void DeleteUser(string idUser);
    }
}