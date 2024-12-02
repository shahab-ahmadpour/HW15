using HW_Week15.Contract.RepositoryInterface;
using HW_Week15.Contract.ServiceInterface;
using HW_Week15.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<User> GetAllUsers() => _userRepository.GetAllUsers();

    public User GetUserById(int id) => _userRepository.GetUserById(id);

    public void AddUser(User user) => _userRepository.AddUser(user);

    public void UpdateUser(User user) => _userRepository.UpdateUser(user);

    public void DeleteUser(int id) => _userRepository.DeleteUser(id);
}
