using Final.DAL.Entities;
using Final.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Service
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers().ToList();
        }
        

        public User? GetUserById(int id)
        {
            if(id <= 0)
            {
                throw new ArgumentException(nameof(id), "id cannot be negativ");
            }
            return _userRepository.GetAllUsers()
                .FirstOrDefault(u => u.Id == id);
        }
        public User? GetUserByName(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name), "name is cannot be null");
            }
            return _userRepository.GetAllUsers()
                .FirstOrDefault(u => u.Name == name);
        }

        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }


        public void AddRangeUser(List<User> users) 
        {
            _userRepository.AddRange(users);
        }


        public void UpdateUser(User user)
        {
            _userRepository.Update(user);

        }

        public void DeleteUser(User user)
        {
            _userRepository.Delete(user);
        }

        public void DeleteRangeUser(List<User> users) 
        {
            _userRepository.DeleteRange(users);
        }
    }
}
