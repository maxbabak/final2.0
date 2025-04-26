using Final.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DAL.Repository
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

      
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }


        public void AddRange(List<User> users)
        {
            _context.Users.AddRange(users);
            _context.SaveChanges();
        }


        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(User user) 
        { 
            _context.Remove(user);
            _context.SaveChanges();
        }


        public void DeleteRange(List<User> users)
        {
            _context.Remove(users);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsersWithLoans()
        {
            throw new NotImplementedException();
        }
    }
}
