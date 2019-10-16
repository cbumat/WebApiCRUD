using ApiCRUD.Data;
using ApiCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCRUD.Repositories
{
    public class UserRepository:IUserRepository
    {
        UserContext context;

        public UserRepository()
        {

            this.context = new UserContext();
        }
        public List<User> GetUsers()
        {
            var result = (from data in context.Users
                            orderby data.Id descending
                            select data);
            return result.ToList();
        }

        public User GetHotelById(string userId)
        {
            var result = (from data in context.Users
                            where data.Id == userId
                            select data).FirstOrDefault();
            return result;
        }

        public void AddUser(string Name, string LastName, string Address)
        {
            var userIds = (from data in context.Users
                           select data.Id).ToList();

            User user = new User();

            if (userIds.Count() == 0)
            {
                user.Id = 0.ToString();
            }
            else
            {
                var userIdsToInt = userIds.Select(int.Parse).ToList();

                user.Id = (userIdsToInt.Max() + 1).ToString();
            }

            user.Name = Name;
            user.LastName = LastName;
            user.Address = Address;
            user.CreateDate = DateTime.Now;

            context.Users.Add(user);
            context.SaveChanges();
        }

        public void UpdateUser(string Id, string Name, string LastName, string Address)
        {
            User user = this.GetHotelById(Id);

            user.Name = Name;
            user.LastName = LastName;
            user.Address = Address;
            user.UpdateDate = DateTime.Now;

            this.context.SaveChanges();
        }

        public void DeleteUser(string idUser)
        {
            User user = this.GetHotelById(idUser);
            this.context.Users.Remove(user);
            this.context.SaveChanges();
        }
    }
}